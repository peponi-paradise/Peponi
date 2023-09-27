using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Peponi.CodeGenerators.Diagnostics;
using Peponi.CodeGenerators.SemanticTarget;

namespace Peponi.CodeGenerators.NotifyInterfaceGenerator;

[Generator]
public sealed partial class NotifyInterfaceGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var syntaxProvider = context.SyntaxProvider.CreateSyntaxProvider(
            predicate: static (s, _) => IsValidTarget(s),
            transform: static (context, _) => GetNotifyTarget(context));

        var errorInfos = syntaxProvider.Where(static item => item.Error is not null);
        context.RegisterSourceOutput(errorInfos, static (productionContext, target) => DiagnosticMapper.Report(productionContext, target.Error!));

        var targetInfos = syntaxProvider.Where(static item => item.Target is not null);
        context.RegisterSourceOutput(targetInfos, static (productionContext, target) => Execute(productionContext, target.Target));
    }

    private static bool IsValidTarget(SyntaxNode node) => node is ClassDeclarationSyntax or RecordDeclarationSyntax or StructDeclarationSyntax { AttributeLists: { Count: > 0 } };

    private static (ObjectDeclarationTarget? Target, Diagnostic? Error) GetNotifyTarget(GeneratorSyntaxContext context)
    {
        var typeSymbol = Creater.GetTypeSymbol(context);
        if (typeSymbol is null) return (null, null);

        AttributeData? attributeData = Creater.GetAttribute(typeSymbol, "Peponi.CodeGenerators.NotifyInterfaceAttribute");
        if (attributeData is null) return (null, null);
        else
        {
            ObjectType? objectType = Creater.GetObjectType(typeSymbol);
            if (objectType is null) return (null, DiagnosticMapper.Create(typeSymbol, NotifyInterfaceErrors.CouldNotFindTypeObject));

            var modifier = Creater.GetAccessibilityString(typeSymbol.DeclaredAccessibility);
            if (string.IsNullOrEmpty(modifier)) return (null, DiagnosticMapper.Create(typeSymbol, NotifyInterfaceErrors.CouldNotFindTypeModifier));

            return (new ObjectDeclarationTarget(
                typeSymbol!.Name,
                modifier,
                typeSymbol.ContainingNamespace.ToDisplayString(),
                (ObjectType)objectType!,
                NotifyType.Notify,
                typeSymbol.IsStatic!,
                typeSymbol.IsSealed,
                typeSymbol.IsAbstract
                ), null);
        }
    }
}