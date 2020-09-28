﻿using System;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modules.Common.TypeResolution;

namespace Intent.Modules.Common.Types.TypeResolvers
{
    public class CSharpTypeResolver : TypeResolverBase, ITypeResolver
    {
        public CSharpTypeResolver()
        {
        }

        public override string DefaultCollectionFormat { get; set; } = "IEnumerable<{0}>";

        protected override string ResolveType(ITypeReference typeInfo, string collectionFormat = null)
        {
            var result = typeInfo.Element.Name;
            if (typeInfo.Element.Stereotypes.Any(x => x.Name == "C#"))
            {
                string typeName = typeInfo.Element.GetStereotypeProperty<string>("C#", "Type", typeInfo.Element.Name);
                string @namespace = typeInfo.Element.GetStereotypeProperty<string>("C#", "Namespace");

                result = !string.IsNullOrWhiteSpace(@namespace) ? $"{@namespace}.{typeName}" : typeName;

                if (typeInfo.IsNullable && (typeInfo.Element.SpecializationType.Equals("Enum",StringComparison.InvariantCultureIgnoreCase) || (typeInfo.Element.GetStereotypeProperty("C#", "IsPrimitive", false))))
                {
                    result += "?";
                }
            }
            else
            {
                switch (typeInfo.Element.Name)
                {
                    case "bool":
                        result = "bool";
                        break;
                    case "date":
                    case "datetime":
                        result = "System.DateTime";
                        break;
                    case "char":
                        result = "char";
                        break;
                    case "byte":
                        result = "byte";
                        break;
                    case "decimal":
                        result = "decimal";
                        break;
                    case "double":
                        result = "double";
                        break;
                    case "float":
                        result = "float";
                        break;
                    case "short":
                        result = "short";
                        break;
                    case "int":
                        result = "int";
                        break;
                    case "long":
                        result = "long";
                        break;
                    case "datetimeoffset":
                        result = "System.DateTimeOffset";
                        break;
                    case "binary":
                        result = "byte[]";
                        break;
                    case "object":
                        result = "object";
                        break;
                    case "guid":
                        result = "System.Guid";
                        break;
                    case "string":
                        result = "string";
                        break;
                }

                if (typeInfo.IsNullable && typeInfo.Element.SpecializationType.Equals("Enum", StringComparison.InvariantCultureIgnoreCase))
                {
                    result += "?";
                }
            }

            if (typeInfo.GenericTypeParameters.Any())
            {
                var genericTypeParameters = typeInfo.GenericTypeParameters
                    .Select(x => Get(x, collectionFormat))
                    .Aggregate((x, y) => x + ", " + y);
                result += $"<{genericTypeParameters}>";
            }

            if (typeInfo.IsCollection)
            {
                result = string.Format(collectionFormat ?? DefaultCollectionFormat, result);
            }

            return result;
        }
    }
}
