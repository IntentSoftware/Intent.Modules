﻿using Intent.SoftwareFactory.Engine;
using Intent.SoftwareFactory.Templates;
using Intent.SoftwareFactory.Templates.Registrations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templates.Registrations.Templates.NoModel
{
    [Description("Templates.Registrations.NoModel Template")]
    public class Registration : NoModelTemplateRegistrationBase
    {
        public override string TemplateId
        {
            get
            {
                return Template.Identifier;
            }
        }

        public override ITemplate CreateTemplateInstance(IProject project)
        {
            return new Template(project);
        }
    }
}
