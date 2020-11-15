using System.Collections.Generic;
using System.Linq;
using Intent.Engine;
using Intent.Modules.Common;
using Intent.Modules.Common.CSharp;
using Intent.Modules.Common.CSharp.Templates;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.Types.Api;
using Intent.Modules.ModuleBuilder.Api;
using Intent.Modules.ModuleBuilder.Templates.IModSpec;

namespace Intent.Modules.ModuleBuilder.Templates.FileTemplatePartial
{
    partial class FileTemplatePartialTemplate : CSharpTemplateBase<FileTemplateModel>, IHasTemplateDependencies
    {
        public const string TemplateId = "Intent.ModuleBuilder.ProjectItemTemplate.Partial";

        public FileTemplatePartialTemplate(string templateId, IOutputTarget project, FileTemplateModel model) : base(templateId, project, model)
        {
            AddNugetDependency(NugetPackages.IntentModulesCommon);
        }

        public string TemplateName => Model.Name.EndsWith("Template") ? Model.Name : $"{Model.Name}Template";
        public IList<string> OutputFolders => Model.GetFolderPath().Select(x => x.Name).Concat(new[] { Model.Name }).ToList();
        public string FolderPath => string.Join("/", OutputFolders);
        public string FolderNamespace => string.Join(".", OutputFolders);

        protected override CSharpFileConfig DefineFileConfig()
        {
            return new CSharpFileConfig(
                className: $"{TemplateName}",
                @namespace: $"{OutputTarget.GetNamespace()}.{FolderNamespace}",
                fileName: $"{TemplateName}Partial",
                relativeLocation: $"{FolderPath}");
        }

        public string GetTemplateId()
        {
            return $"{Project.ApplicationName()}.{FolderNamespace}";
        }

        public override void BeforeTemplateExecution()
        {
            Project.Application.EventDispatcher.Publish(new TemplateRegistrationRequiredEvent(
                modelId: Model.Id,
                templateId: GetTemplateId(),
                templateType: "File Template",
                role: GetRole(),
                location: Model.GetLocation()));

            if (Model.GetModelType() != null)
            {
                Project.Application.EventDispatcher.Publish(new ModuleDependencyRequiredEvent(
                    moduleId: Model.GetModelType().ParentModule.Name,
                    moduleVersion: Model.GetModelType().ParentModule.Version));
            }
        }

        private string GetRole()
        {
            return Model.GetRole() ?? GetTemplateId();
        }

        private string GetModelType()
        {
            return Model.GetModelName();
        }

        private string GetTemplateBaseClass()
        {
            return nameof(IntentTemplateBase);
        }
    }
}