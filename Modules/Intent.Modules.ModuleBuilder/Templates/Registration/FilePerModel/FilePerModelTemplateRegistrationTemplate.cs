// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.ModuleBuilder.Templates.Registration.FilePerModel
{
    using Intent.Modules.Common.Templates;
    using Intent.Metadata.Models;
    using Intent.Modules.ModuleBuilder.Helpers;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Registration\FilePerModel\FilePerModelTemplateRegistrationTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class FilePerModelTemplateRegistrationTemplate : IntentRoslynProjectItemTemplateBase<IClass>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(@"
using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.Modules.Common.Registrations;
using Intent.RoslynWeaver.Attributes;
using Intent.SoftwareFactory.Engine;
using Intent.SoftwareFactory.Templates;
");
            
            #line 16 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Registration\FilePerModel\FilePerModelTemplateRegistrationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DependencyUsings));
            
            #line default
            #line hidden
            this.Write("\r\n[assembly: DefaultIntentManaged(Mode.Merge)]\r\n\r\nnamespace ");
            
            #line 19 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Registration\FilePerModel\FilePerModelTemplateRegistrationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n\t[IntentManaged(Mode.Merge, Body = Mode.Merge, Signature = Mode.Fully)]\r\n   " +
                    " public class ");
            
            #line 22 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Registration\FilePerModel\FilePerModelTemplateRegistrationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" : ModelTemplateRegistrationBase<");
            
            #line 22 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Registration\FilePerModel\FilePerModelTemplateRegistrationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.GetTargetModel()));
            
            #line default
            #line hidden
            this.Write(">\r\n    {\r\n        private readonly IMetaDataManager _metaDataManager;\r\n\r\n        " +
                    "public ");
            
            #line 26 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Registration\FilePerModel\FilePerModelTemplateRegistrationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("(IMetaDataManager metaDataManager)\r\n        {\r\n            _metaDataManager = met" +
                    "aDataManager;\r\n        }\r\n\r\n        public override string TemplateId =>  ");
            
            #line 31 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Registration\FilePerModel\FilePerModelTemplateRegistrationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetTemplateNameForTemplateId()));
            
            #line default
            #line hidden
            this.Write(".TemplateId;\r\n\r\n        public override ITemplate CreateTemplateInstance(IProject" +
                    " project, ");
            
            #line 33 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Registration\FilePerModel\FilePerModelTemplateRegistrationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.GetTargetModel()));
            
            #line default
            #line hidden
            this.Write(" model)\r\n        {\r\n\t\t\treturn new ");
            
            #line 35 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Registration\FilePerModel\FilePerModelTemplateRegistrationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetTemplateNameForTemplateId()));
            
            #line default
            #line hidden
            this.Write("(project, model);\r\n        }\r\n\r\n\t    [IntentManaged(Mode.Merge, Body = Mode.Ignor" +
                    "e, Signature = Mode.Fully)]\r\n        public override IEnumerable<");
            
            #line 39 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Registration\FilePerModel\FilePerModelTemplateRegistrationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.GetTargetModel()));
            
            #line default
            #line hidden
            this.Write(@"> GetModels(Intent.SoftwareFactory.Engine.IApplication application)
        {
            // Filter classes by SpecializationType if necessary (e.g. .Where(x => x.SpecializationType == ""Service"") for services only)
            return _metaDataManager.GetClassModels(application, """);
            
            #line 42 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Registration\FilePerModel\FilePerModelTemplateRegistrationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.GetModelerName()));
            
            #line default
            #line hidden
            this.Write("\"); \r\n        }\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
