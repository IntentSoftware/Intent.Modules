﻿using Intent.SoftwareFactory;
using Intent.SoftwareFactory.Engine;
using Intent.Templates
using Intent.SoftwareFactory.Templates.Registrations;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modelers.Services;
using Intent.Modelers.Services.Api;
using Intent.Modules.Common;
using Intent.Modules.Common.Registrations;
using IApplication = Intent.SoftwareFactory.Engine.IApplication;

namespace Intent.Modules.Application.Contracts.Templates.DTO
{
    [Description(DTOTemplate.IDENTIFIER)]
    public class Registrations : ModelTemplateRegistrationBase<IDTOModel>
    {
        private readonly ServicesMetadataProvider _metaDataManager;

        public Registrations(ServicesMetadataProvider metaDataManager)
        {
            _metaDataManager = metaDataManager;

        }

        public override string TemplateId => DTOTemplate.IDENTIFIER;

        public override ITemplate CreateTemplateInstance(IProject project, IDTOModel model)
        {
            return new DTOTemplate(project, model);
        }

        public override IEnumerable<IDTOModel> GetModels(IApplication application)
        {
            return _metaDataManager.GetDTOs(application);
        }
    }
}

