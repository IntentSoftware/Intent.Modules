﻿using Intent.SoftwareFactory.Engine;
using Intent.Templates
using Intent.SoftwareFactory.Templates.Registrations;
using System.ComponentModel;
using Intent.Modules.Common.Registrations;

namespace Intent.Modules.HttpServiceProxy.Templates.Exception
{
    [Description(WebApiClientServiceProxyRemoteExceptionTemplate.IDENTIFIER)]
    public class WebApiClientServiceProxyRemoteExceptionTemplateRegistration : NoModelTemplateRegistrationBase
    {
        public override string TemplateId => WebApiClientServiceProxyRemoteExceptionTemplate.IDENTIFIER;

        public override ITemplate CreateTemplateInstance(IProject project)
        {
            return new WebApiClientServiceProxyRemoteExceptionTemplate(project);
        }
    }
}

