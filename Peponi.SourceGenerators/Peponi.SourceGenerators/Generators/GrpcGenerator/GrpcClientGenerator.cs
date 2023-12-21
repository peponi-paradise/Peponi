using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Peponi.SourceGenerators.Diagnostics;
using Peponi.SourceGenerators.SemanticTarget;

namespace Peponi.SourceGenerators.GrpcGenerator;

[Generator]
public sealed partial class GrpcClientGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var syntaxProvider = context.SyntaxProvider.CreateSyntaxProvider(
            predicate: static (s, _) => IsValidTarget(s),
            transform: static (context, _) => GetGrpcClientTarget(context));

        var errorInfos = syntaxProvider.Where(static item => item.Error is not null);
        context.RegisterSourceOutput(errorInfos, static (productionContext, target) => DiagnosticMapper.Report(productionContext, target.Error!));

        var targetInfos = syntaxProvider.Where(static item => item.Target.ObjectTarget is not null && item.Target.ProtobufTarget is not null);
        context.RegisterSourceOutput(targetInfos, static (productionContext, targetInfo) => Execute(productionContext, targetInfo.Target.ObjectTarget, targetInfo.Target.ProtobufTarget));
    }

    private static bool IsValidTarget(SyntaxNode node) => node is ClassDeclarationSyntax { AttributeLists: { Count: > 0 } };

    private static ((ObjectDeclarationTarget ObjectTarget, ProtobufInfo ProtobufTarget) Target, Diagnostic Error) GetGrpcClientTarget(GeneratorSyntaxContext context)
    {
        var typeSymbol = Creater.GetTypeSymbol(context);
        if (typeSymbol is null) return ((null, default)!, null)!;

        AttributeData? attributeData = Creater.GetAttribute(typeSymbol, "Peponi.SourceGenerators.GrpcClientAttribute");
        if (attributeData is null) return ((null, default)!, null)!;
        else
        {
            ObjectType? objectType = Creater.GetObjectType(typeSymbol);
            if (objectType is null)
            {
                // return (null, DiagnosticMapper.Create(typeSymbol, CouldNotFindTypeObject));
                return ((null, default)!, null)!;
            }

            var modifier = Creater.GetAccessibilityString(typeSymbol.DeclaredAccessibility);
            if (string.IsNullOrEmpty(modifier))
            {
                // return (null, DiagnosticMapper.Create(typeSymbol, CouldNotFindTypeModifier));
                return ((null, default)!, null)!;
            }

            GrpcClientMode clientMode = (GrpcClientMode)Creater.GetConstructorArgument(attributeData, 0)?.Value!;
            string remote = Creater.GetConstructorArgumentString(attributeData, 1)!;
            string protoRootPath = Creater.GetConstructorArgumentString(attributeData, 2)!;

            // Read protos

            ProtobufInfo protobufTarget = new(clientMode, remote, new());

            try
            {
                DirectoryInfo dirInfo = new(protoRootPath);

                foreach (var file in dirInfo.EnumerateFiles("*", SearchOption.AllDirectories))
                {
                    if (Path.GetExtension(file.FullName).ToLower() == ".proto")
                    {
                        var textDatas = File.ReadAllLines(file.FullName);

                        bool packageDetected = false;
                        bool csNamespaceDetected = false;
                        string packageName = string.Empty;
                        string csNamespace = string.Empty;
                        List<string> serviceNames = new();

                        foreach (var textData in textDatas)
                        {
                            if (textData.StartsWith("package"))
                            {
                                packageDetected = true;
                                packageName = textData.Split(' ')[1].Split(';')[0];
                                packageName = GetPascalCase(packageName);
                            }
                            else if (textData.StartsWith("option csharp_namespace ="))
                            {
                                csNamespaceDetected = true;
                                csNamespace = textData.Split('=')[1].Split(' ')[1].Split(';')[0].Split('"')[1];
                            }
                            else if (textData.StartsWith("service"))
                            {
                                serviceNames.Add(textData.Split(' ')[1].Split('{')[0]);
                            }
                        }

                        string finalNamespace = string.Empty;
                        if (csNamespaceDetected) finalNamespace = csNamespace;
                        else if (packageDetected) finalNamespace = packageName;

                        if (!string.IsNullOrWhiteSpace(finalNamespace) && serviceNames.Count > 0)
                        {
                            if (protobufTarget.ProtobufDatas.FindIndex(x => x.Namespace == finalNamespace) is var index && index != -1)
                            {
                                protobufTarget.ProtobufDatas[index].ServiceNames.AddRange(serviceNames);
                            }
                            else
                            {
                                protobufTarget.ProtobufDatas.Add(new(finalNamespace, serviceNames));
                            }
                        }
                    }
                }

                if (protobufTarget.ProtobufDatas.Count == 0)
                {
                    // return ((null, default)!, DiagnosticMapper.Create(typeSymbol, NoProtobufFoundError));
                    return ((null, default)!, null)!;
                }
            }
            catch
            {
                //return ((null, default)!, DiagnosticMapper.Create(typeSymbol, ProtobufResolveError));
                return ((null, default)!, null)!;
            }

            return ((new ObjectDeclarationTarget(
                typeSymbol!.Name,
                modifier,
                typeSymbol.ContainingNamespace.ToDisplayString(),
                (ObjectType)objectType!,
                NotifyType.None,
                typeSymbol.IsStatic!,
                typeSymbol.IsSealed,
                typeSymbol.IsAbstract
                ), protobufTarget), null)!;

            string GetPascalCase(string input)
            {
                if (char.IsLower(input[0])) return char.ToUpper(input[0]) + input.Substring(1);
                else return input;
            }
        }
    }
}