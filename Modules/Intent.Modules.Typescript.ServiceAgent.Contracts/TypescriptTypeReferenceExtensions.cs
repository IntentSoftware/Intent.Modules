using System;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.TypeResolution;
using Intent.Modules.Constants;
using Intent.Modules.Typescript.ServiceAgent.Contracts.Templates.TypescriptDTO;
using Intent.Engine;
using Intent.Modelers.Services.Api;
using Intent.Templates;

namespace Intent.Modules.Typescript.ServiceAgent.Contracts
{
    public static class TypescriptTypeReferenceExtensions
    {
        public static string ConvertType<T>(this T template, ITypeReference typeInfo)
            where T : IProjectItemTemplate, IRequireTypeResolver
        {
            var result = template.GetQualifiedName(typeInfo);
            if (typeInfo.IsCollection)
            {
                result = "" + result + "[]";
            }
            return result;
        }

        [Obsolete("Should use Types.Get(...) system")]
        public static string GetQualifiedName<T>(this T template, ITypeReference typeInfo)
            where T : IProjectItemTemplate, IRequireTypeResolver
        {
            string result = typeInfo.Name;
            if (typeInfo.SpecializationType == "DTO")
            {
                var templateInstance = template.Project.FindTemplateInstance<IHasClassDetails>(TemplateDependency.OnModel<IDTOModel>(TypescriptDtoTemplate.LocalIdentifier, (x) => x.Id == typeInfo.Id))
                    ?? template.Project.FindTemplateInstance<IHasClassDetails>(TemplateDependency.OnModel<IDTOModel>(TypescriptDtoTemplate.RemoteIdentifier, (x) => x.Id == typeInfo.Id));
                if (templateInstance != null)
                {
                    return $"{templateInstance.Namespace}.{templateInstance.ClassName}";
                }
            }
            else if (typeInfo.HasStereotype(StandardStereotypes.TypescriptType))
            {
                return typeInfo.GetStereotypeProperty<string>(StandardStereotypes.TypescriptType, "TypeName");
            }

            return template.Types.Get(typeInfo);
        }
    }
}