﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.Application.Contracts.Mappings.Templates.MappingProfile
{
    using System.Collections.Generic;
    using Intent.Modelers.Services.Api;
    using Intent.Modules.Common.Templates;
    using Intent.Modules.Common.CSharp.Templates;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Application.Contracts.Mappings\Templates\MappingProfile\MappingProfileTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class MappingProfileTemplate : CSharpTemplateBase<IList<DTOModel>>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(" \r\n");
            
            #line 8 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Application.Contracts.Mappings\Templates\MappingProfile\MappingProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DependencyUsings));
            
            #line default
            #line hidden
            this.Write("\r\nusing System.Runtime.Serialization;\r\nusing AutoMapper;\r\n\r\n[assembly: DefaultInt" +
                    "entManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 14 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Application.Contracts.Mappings\Templates\MappingProfile\MappingProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public class ");
            
            #line 16 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Application.Contracts.Mappings\Templates\MappingProfile\MappingProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" : Profile\r\n    {\r\n        public ");
            
            #line 18 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Application.Contracts.Mappings\Templates\MappingProfile\MappingProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(@"()
        {
            // The intent is to have a separate method for each mapping profile, this allows independent use of profiles if desired,
            // for example for unit testing. Rather than try and make unique method names for the different profiles to create, we
            // instead configure each method to have the same name, but with different type overloads. We then use the default keyword
            // when calling the method to be passing in the correct type so that the compiler chooses the correct overload.
            
");
            
            #line 25 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Application.Contracts.Mappings\Templates\MappingProfile\MappingProfileTemplate.tt"

    foreach (var model in Model) {

            
            #line default
            #line hidden
            this.Write("            Configure(this, default(");
            
            #line 28 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Application.Contracts.Mappings\Templates\MappingProfile\MappingProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(NormalizeNamespace(GetSourceType(model))));
            
            #line default
            #line hidden
            this.Write("), default(");
            
            #line 28 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Application.Contracts.Mappings\Templates\MappingProfile\MappingProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(NormalizeNamespace(GetContractType(model))));
            
            #line default
            #line hidden
            this.Write("));\r\n");
            
            #line 29 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Application.Contracts.Mappings\Templates\MappingProfile\MappingProfileTemplate.tt"

    }

            
            #line default
            #line hidden
            this.Write("        }\r\n");
            
            #line 33 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Application.Contracts.Mappings\Templates\MappingProfile\MappingProfileTemplate.tt"

    foreach (var model in Model)
    {

            
            #line default
            #line hidden
            this.Write("\r\n        public static IMappingExpression<");
            
            #line 38 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Application.Contracts.Mappings\Templates\MappingProfile\MappingProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(NormalizeNamespace(GetSourceType(model))));
            
            #line default
            #line hidden
            this.Write(", ");
            
            #line 38 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Application.Contracts.Mappings\Templates\MappingProfile\MappingProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(NormalizeNamespace(GetContractType(model))));
            
            #line default
            #line hidden
            this.Write("> Configure(IProfileExpression cfg, ");
            
            #line 38 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Application.Contracts.Mappings\Templates\MappingProfile\MappingProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(NormalizeNamespace(GetSourceType(model))));
            
            #line default
            #line hidden
            this.Write(" sourceType, ");
            
            #line 38 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Application.Contracts.Mappings\Templates\MappingProfile\MappingProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(NormalizeNamespace(GetContractType(model))));
            
            #line default
            #line hidden
            this.Write(" destinationType)\r\n        {\r\n            return cfg.CreateMap<");
            
            #line 40 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Application.Contracts.Mappings\Templates\MappingProfile\MappingProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(NormalizeNamespace(GetSourceType(model))));
            
            #line default
            #line hidden
            this.Write(", ");
            
            #line 40 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Application.Contracts.Mappings\Templates\MappingProfile\MappingProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(NormalizeNamespace(GetContractType(model))));
            
            #line default
            #line hidden
            this.Write(">()\r\n");
            
            #line 41 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Application.Contracts.Mappings\Templates\MappingProfile\MappingProfileTemplate.tt"

        foreach (var field in model.Fields)
        {
            if (field.Mapping != null && field.Name.ToPascalCase() != GetPath(field.Mapping.Path))
            {

            
            #line default
            #line hidden
            this.Write("                .ForMember(dest => dest.");
            
            #line 47 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Application.Contracts.Mappings\Templates\MappingProfile\MappingProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(field.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write(", opt => opt.MapFrom(src => src.");
            
            #line 47 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Application.Contracts.Mappings\Templates\MappingProfile\MappingProfileTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetPath(field.Mapping.Path)));
            
            #line default
            #line hidden
            this.Write("))\r\n");
            
            #line 48 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Application.Contracts.Mappings\Templates\MappingProfile\MappingProfileTemplate.tt"

            }
        }

            
            #line default
            #line hidden
            this.Write("                ;\r\n        }\r\n");
            
            #line 54 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Application.Contracts.Mappings\Templates\MappingProfile\MappingProfileTemplate.tt"

    } //foreach

            
            #line default
            #line hidden
            this.Write("    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
