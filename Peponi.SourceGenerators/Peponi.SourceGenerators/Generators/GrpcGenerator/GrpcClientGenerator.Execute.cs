﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Peponi.SourceGenerators.SemanticTarget;
using Peponi.SourceGenerators.SourceWriter;
using System.Text;

namespace Peponi.SourceGenerators.GrpcGenerator;

public sealed partial class GrpcClientGenerator
{
    private static void Execute(SourceProductionContext context, ObjectDeclarationTarget objectTarget, ProtobufInfo protoTarget)
    {
        if (objectTarget == null) return;
        else if (protoTarget == null || protoTarget.ProtobufDatas.Count == 0) return;

        var codeFileName = $"{objectTarget.NamespaceName}.{objectTarget.TypeName}.GrpcClient.g.cs";

        var codeBuilder = new CodeBuilder();

        codeBuilder.WriteHeaderComment();

        codeBuilder.WriteNullableDisable();

        codeBuilder.WriteGrpcClientUsings(protoTarget);

        codeBuilder.WriteNamespace(objectTarget.NamespaceName);

        codeBuilder.Indent++;

        codeBuilder.WriteNotifyObjectType(objectTarget);

        codeBuilder.Indent++;

        codeBuilder.WriteGrpcClientMembers(protoTarget);

        codeBuilder.CloseAllIndents();

        context.AddSource(codeFileName, SourceText.From(codeBuilder.ToString(), Encoding.UTF8));
    }
}