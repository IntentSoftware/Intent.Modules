﻿using System.ComponentModel;
using Intent.SoftwareFactory.Engine;
using Intent.SoftwareFactory.Templates;
using Intent.SoftwareFactory.Templates.Registrations;

namespace Intent.Modules.AspNetCore.Docker.Templates.DockerFile
{
    [Description(DockerfileTemplate.Identifier)]
    public class DockerfileTemplateRegistration : NoModelTemplateRegistrationBase
    {
        public override string TemplateId => DockerfileTemplate.Identifier;

        public override ITemplate CreateTemplateInstance(IProject project)
        {
            return new DockerfileTemplate(project);
        }
    }
}
