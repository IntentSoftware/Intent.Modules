using System.Collections.Generic;
using System.Linq;
using Intent.Engine;
using Intent.ModuleBuilder.Api;
using Intent.Modules.Common.CSharp.Templates;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.Types.Api;
using Intent.Modules.ModuleBuilder.Templates.IModSpec;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.CSharp.Templates.CSharpTemplatePartial", Version = "1.0")]

namespace Intent.Modules.ModuleBuilder.Templates.TemplateDecoratorContract
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    partial class TemplateDecoratorContractTemplate : CSharpTemplateBase<TemplateDecoratorContractModel>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Intent.ModuleBuilder.Templates.TemplateDecoratorContract";

        [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
        public TemplateDecoratorContractTemplate(IOutputTarget outputTarget, TemplateDecoratorContractModel model) : base(TemplateId, outputTarget, model)
        {
        }

        protected override CSharpFileConfig DefineFileConfig()
        {
            return new CSharpFileConfig(
                className: $"{Model.Name}",
                @namespace: $"{string.Join(".", new[] { OutputTarget.GetNamespace() }.Concat(Model.Template.GetParentFolderNames()))}.{Model.Template.Name}",
                relativeLocation: $"{string.Join("/", Model.Template.GetParentFolderNames().Concat(new[] { Model.Template.Name }))}");
        }
    }
}