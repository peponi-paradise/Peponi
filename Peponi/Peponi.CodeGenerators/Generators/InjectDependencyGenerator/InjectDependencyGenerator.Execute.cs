﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Peponi.CodeGenerators.SemanticTarget;
using Peponi.CodeGenerators.SourceWriter;
using System.Collections.Immutable;
using System.Text;

namespace Peponi.CodeGenerators.InjectDependencyGenerator;

public sealed partial class InjectDependencyGenerator
{
    private static void Execute(SourceProductionContext context, (ObjectDeclarationTarget ObjectTarget, ImmutableArray<InjectDependencyTarget> InjectTarget) target)
    {
        if (target.ObjectTarget is null || target.InjectTarget.Count() == 0) return;

        var codeFileName = $"{target.ObjectTarget.NamespaceName}.{target.ObjectTarget.TypeName}.InjectDependency.g.cs";

        var codeBuilder = new CodeBuilder();

        codeBuilder.WriteHeader();

        codeBuilder.WriteNullable();

        codeBuilder.WriteNamespace(target.ObjectTarget.NamespaceName);

        codeBuilder.Indent++;

        codeBuilder.WriteNotifyObjectType(target.ObjectTarget);

        codeBuilder.Indent++;

        codeBuilder.WriteDependencyMembers(target.ObjectTarget, target.InjectTarget);

        while (codeBuilder.Indent > 0)
        {
            codeBuilder.Indent--;
            if (codeBuilder.Indent != 0) codeBuilder.AppendLine("}");
            else codeBuilder.Append("}");
        }

        context.AddSource(codeFileName, SourceText.From(codeBuilder.ToString(), Encoding.UTF8));
    }
}