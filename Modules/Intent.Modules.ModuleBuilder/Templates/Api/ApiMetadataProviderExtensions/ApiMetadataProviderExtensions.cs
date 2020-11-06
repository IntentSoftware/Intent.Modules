// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.ModuleBuilder.Templates.Api.ApiMetadataProviderExtensions
{
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Modules.Common.CSharp.Templates;
    using Intent.Templates;
    using Intent.Metadata.Models;
    using Intent.Modules.ModuleBuilder.Api;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiMetadataProviderExtensions\ApiMetadataProviderExtensions.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class ApiMetadataProviderExtensions : CSharpTemplateBase<IList<ElementSettingsModel>>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System.Collections.Generic;\r\nusing System.Linq;\r\nusing Intent.Engine;\r\nusin" +
                    "g Intent.Metadata.Models;\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnam" +
                    "espace ");
            
            #line 18 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiMetadataProviderExtensions\ApiMetadataProviderExtensions.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public static class ");
            
            #line 20 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiMetadataProviderExtensions\ApiMetadataProviderExtensions.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("\r\n    {\r\n");
            
            #line 22 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiMetadataProviderExtensions\ApiMetadataProviderExtensions.tt"
  foreach(var elementSettings in Model) { 
            
            #line default
            #line hidden
            this.Write("        public static IList<");
            
            #line 23 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiMetadataProviderExtensions\ApiMetadataProviderExtensions.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetClassName(elementSettings)));
            
            #line default
            #line hidden
            this.Write("> Get");
            
            #line 23 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiMetadataProviderExtensions\ApiMetadataProviderExtensions.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetClassName(elementSettings).ToPluralName()));
            
            #line default
            #line hidden
            this.Write("(this IDesigner designer)\r\n        {\r\n            return designer.GetElementsOfTy" +
                    "pe(");
            
            #line 25 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiMetadataProviderExtensions\ApiMetadataProviderExtensions.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetClassName(elementSettings)));
            
            #line default
            #line hidden
            this.Write(".SpecializationTypeId)\r\n                .Select(x => new ");
            
            #line 26 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiMetadataProviderExtensions\ApiMetadataProviderExtensions.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetClassName(elementSettings)));
            
            #line default
            #line hidden
            this.Write("(x))\r\n                .ToList();\r\n        }\r\n\r\n");
            
            #line 30 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiMetadataProviderExtensions\ApiMetadataProviderExtensions.tt"
  } 
            
            #line default
            #line hidden
            this.Write("    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
