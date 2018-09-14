﻿using Intent.SoftwareFactory.Engine;
using Intent.SoftwareFactory.Templates;
using Intent.SoftwareFactory.Templates.Registrations;
using System.ComponentModel;

namespace Intent.Modules.HttpServiceProxy.Templates.HttpClientServiceImplementation
{
    [Description(HttpClientServiceImplementationTemplate.IDENTIFIER)]
    public class Registrations : NoModelTemplateRegistrationBase
    {
        public override string TemplateId => HttpClientServiceImplementationTemplate.IDENTIFIER;

        public override ITemplate CreateTemplateInstance(IProject project)
        {
            return new HttpClientServiceImplementationTemplate(project);
        }
    }
}
