using System;
using System.IO;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Intent.RoslynWeaver.Attributes;
using Intent.Engine;
using Intent.Templates;
using System.Collections.Generic;
using System.Linq;
using Intent.Modules.Angular.Api;
using Intent.Modules.Angular.Editor;
using Intent.Modules.Angular.Templates.Model.FormGroupTemplate;
using Intent.Modules.Angular.Templates.Model.ModelTemplate;
using Intent.Modules.Angular.Templates.Proxies.AngularDTOTemplate;
using Intent.Modules.Angular.Templates.Proxies.AngularServiceProxyTemplate;
using Intent.Modules.Angular.Templates.Shared.IntentDecoratorsTemplate;
using Intent.Modules.Common.Plugins;
using Intent.Modules.Common.TypeScript.Templates;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("ModuleBuilder.Typescript.Templates.TypescriptTemplatePartial", Version = "1.0")]

namespace Intent.Modules.Angular.Templates.Component.AngularComponentTsTemplate
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    partial class AngularComponentTsTemplate : TypeScriptTemplateBase<ComponentModel>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Angular.Templates.Component.AngularComponentTsTemplate";

        public AngularComponentTsTemplate(IProject project, ComponentModel model) : base(TemplateId, project, model)
        {
            AddTypeSource(ModelTemplate.TemplateId);
            AddTypeSource(FormGroupTemplate.TemplateId);
            AddTypeSource(AngularDTOTemplate.TemplateId);
            AddTypeSource(AngularServiceProxyTemplate.TemplateId);
            AddTemplateDependency(IntentDecoratorsTemplate.TemplateId);
            InjectedServices = Model.GetAngularComponentSettings().InjectServices()?.ToList() ?? new List<IElement>();
        }

        public string ComponentName
        {
            get
            {
                if (Model.Name.EndsWith("Component", StringComparison.InvariantCultureIgnoreCase))
                {
                    return Model.Name.Substring(0, Model.Name.Length - "Component".Length);
                }
                return Model.Name;
            }
        }

        public string ModuleName { get; private set; }

        public override void BeforeTemplateExecution()
        {
            Types.AddClassTypeSource(TypescriptTypeSource.InProject(Project, AngularDTOTemplate.TemplateId, "{0}[]"));

            if (File.Exists(GetMetadata().GetFullLocationPathWithFileName()))
            {
                return;
            }

            // New Component:
            Project.Application.EventDispatcher.Publish(AngularComponentCreatedEvent.EventId,
                new Dictionary<string, string>()
                {
                    {AngularComponentCreatedEvent.ModuleId, Model.Module.Id },
                    {AngularComponentCreatedEvent.ModelId, Model.Id},
                });
        }

        public IList<IElement> InjectedServices { get; }

        public string GetImports()
        {
            if (!InjectedServices.Any())
            {
                return "";
            }
            return @"
" + string.Join(@"
", InjectedServices.Where(x => x.SpecializationType == AngularServiceModel.SpecializationType).Select(x => $"import {{ {x.Name} }} from '{new AngularServiceModel(x).GetAngularServiceSettings().Location()}'"));
        }

        public string GetConstructorParams()
        {
            return string.Join(", ", InjectedServices.Select(x => $"private {x.Name.ToCamelCase()}: {GetTypeName(x)}"));
        }

        public string GetParameters(ComponentCommandModel command)
        {
            return string.Join(", ", command.Parameters.Select(x => x.Name.ToCamelCase() + (x.TypeReference.IsNullable ? "?" : "") + ": " + Types.Get(x.TypeReference, "{0}[]")));
        }

        public string GetReturnType(ComponentCommandModel command)
        {
            return command.ReturnType != null ? Types.Get(command.ReturnType) : "void";
        }

        [IntentManaged(Mode.Merge, Body = Mode.Ignore, Signature = Mode.Fully)]
        public override ITemplateFileConfig DefineDefaultFileMetadata()
        {
            var moduleTemplate = Project.FindTemplateInstance<Module.AngularModuleTemplate.AngularModuleTemplate>(Module.AngularModuleTemplate.AngularModuleTemplate.TemplateId, Model.Module);
            return new TypescriptDefaultFileMetadata(
                overwriteBehaviour: OverwriteBehaviour.Always,
                codeGenType: CodeGenType.Basic,
                fileName: $"{ComponentName.ToKebabCase()}.component",
                fileExtension: "ts",
                defaultLocationInProject: $"ClientApp/src/app/{moduleTemplate.ModuleName.ToKebabCase()}/{ComponentName.ToKebabCase()}",
                className: "${ComponentName}Component"
            );
        }
    }
}