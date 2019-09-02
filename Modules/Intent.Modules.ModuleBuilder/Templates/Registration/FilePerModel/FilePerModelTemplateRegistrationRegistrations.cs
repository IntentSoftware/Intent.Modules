using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.Modules.Common.Registrations;
using Intent.Modules.ModuleBuilder.Helpers;
using Intent.SoftwareFactory.Engine;
using Intent.SoftwareFactory.Templates;

namespace Intent.Modules.ModuleBuilder.Templates.Registration.FilePerModel
{
    public class FilePerModelTemplateRegistrationRegistrations : ModelTemplateRegistrationBase<IClass>
    {
        private readonly IMetaDataManager _metaDataManager;

        public FilePerModelTemplateRegistrationRegistrations(IMetaDataManager metaDataManager)
        {
            _metaDataManager = metaDataManager;
        }

        public override string TemplateId => FilePerModelTemplateRegistrationTemplate.TemplateId;

        public override ITemplate CreateTemplateInstance(IProject project, IClass model)
        {
            return new FilePerModelTemplateRegistrationTemplate(project, model);
        }

        public override IEnumerable<IClass> GetModels(Intent.SoftwareFactory.Engine.IApplication applicationManager)
        {
            return _metaDataManager.GetClassModels(applicationManager, "Module Builder")
                .Where(x => (x.IsCSharpTemplate() || x.IsFileTemplate()) && x.GetCreationMode() == CreationMode.FilePerModel)
                .ToList();
        }
    }
}