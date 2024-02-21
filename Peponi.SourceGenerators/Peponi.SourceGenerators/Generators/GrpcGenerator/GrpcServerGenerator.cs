using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Peponi.SourceGenerators.Diagnostics;
using Peponi.SourceGenerators.SemanticTarget;

namespace Peponi.SourceGenerators.GrpcGenerator;

[Generator]
public sealed partial class GrpcServerGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var syntaxProvider = context.SyntaxProvider.CreateSyntaxProvider(
            predicate: static (s, _) => IsValidTarget(s),
            transform: static (context, _) => GetGrpcServerTarget(context));

        var errorInfos = syntaxProvider.Where(static item => item.Error is not null);
        context.RegisterSourceOutput(errorInfos, static (productionContext, target) => DiagnosticMapper.Report(productionContext, target.Error!));

        var serverInfos = syntaxProvider.Where(static item => item.Info is not null).Collect();

        context.RegisterSourceOutput(serverInfos, static (productionContext, targetInfos) => ExecuteCore(productionContext, targetInfos));
    }

    private static bool IsValidTarget(SyntaxNode node) => node is ClassDeclarationSyntax { AttributeLists: { Count: > 0 } };

    private static (GrpcServerInfo Info, Diagnostic Error) GetGrpcServerTarget(GeneratorSyntaxContext context)
    {
        var typeSymbol = Creater.GetTypeSymbol(context);
        if (typeSymbol is null) return (null, default)!;

        AttributeData? attributeData = Creater.GetAttribute(typeSymbol, "Peponi.SourceGenerators.GrpcServerAttribute");
        if (attributeData is null) return (null, default)!;
        else
        {
            ObjectType? objectType = Creater.GetObjectType(typeSymbol);
            if (objectType is null)
            {
                return (null!, DiagnosticMapper.Create(typeSymbol, GrpcServerErrors.CouldNotFindTypeObject));
            }

            var modifier = Creater.GetAccessibilityString(typeSymbol.DeclaredAccessibility);
            if (string.IsNullOrEmpty(modifier))
            {
                return (null!, DiagnosticMapper.Create(typeSymbol, GrpcServerErrors.CouldNotFindTypeModifier));
            }

            GrpcServerMode serverMode = (GrpcServerMode)Creater.GetConstructorArgument(attributeData, 0)?.Value!;

            string baseNamespace = string.Empty;
            string baseName = string.Empty;
            if (typeSymbol.BaseType != null)
            {
                foreach (var member in typeSymbol.BaseType.ContainingType.MemberNames)
                {
                    if (member == "BindService")
                    {
                        baseNamespace = typeSymbol.BaseType.ContainingType.ContainingNamespace.Name;
                        baseName = typeSymbol.BaseType.ContainingType.Name;
                    }
                }
            }
            if (string.IsNullOrEmpty(baseName))
            {
                return (null!, DiagnosticMapper.Create(typeSymbol, GrpcServerErrors.CouldNotFindProperTarget));
            }

            GrpcServerInfo protobufTarget = new(serverMode, typeSymbol.ContainingNamespace.ToDisplayString(), typeSymbol.Name, baseNamespace, baseName);

            return (protobufTarget, null)!;
        }
    }
}