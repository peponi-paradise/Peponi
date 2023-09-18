﻿using Peponi.CodeGenerators.SemanticTarget;

namespace Peponi.CodeGenerators.SourceWriter;

internal static partial class SourceWriterExtension
{
    internal static void WriteObjectType(this CodeBuilder builder, ObjectDeclarationTarget target)
    {
        if (target.ObjectType == ObjectType.Struct && target.NotifyType == NotifyType.Notify)
        {
            builder.AppendLine("[StructLayout(LayoutKind.Auto)]");
        }
        builder.Append($"{target.TypeModifier} ", true);
        if (target.IsStatic) builder.Append("static ");
        if (target.IsSealed && target.ObjectType != ObjectType.Struct) builder.Append("sealed ");
        if (target.IsAbstract) builder.Append("abstract ");
        builder.Append("partial ");
        if (target.ObjectType == ObjectType.Class) builder.Append("class ");
        else if (target.ObjectType == ObjectType.Record) builder.Append("record ");
        else builder.Append("struct ");
        builder.Append(target.TypeName);
        if (target.NotifyType == NotifyType.Notify) builder.Append(" : INotifyPropertyChanged");
        builder.NewLine();
        builder.AppendLine("{");
    }

    internal static void WriteModelInjectType(this CodeBuilder builder, ObjectDeclarationTarget target)
    {
        if (target.ObjectType == ObjectType.Struct && target.NotifyType == NotifyType.Notify)
        {
            builder.AppendLine("[StructLayout(LayoutKind.Auto)]");
        }
        builder.Append($"{target.TypeModifier} ", true);
        if (target.IsStatic) builder.Append("static ");
        if (target.IsSealed && target.ObjectType != ObjectType.Struct) builder.Append("sealed ");
        if (target.IsAbstract) builder.Append("abstract ");
        builder.Append("partial ");
        if (target.ObjectType == ObjectType.Class) builder.Append("class ");
        else if (target.ObjectType == ObjectType.Record) builder.Append("record ");
        else builder.Append("struct ");
        builder.Append(target.TypeName);
        builder.NewLine();
        builder.AppendLine("{");
    }
}