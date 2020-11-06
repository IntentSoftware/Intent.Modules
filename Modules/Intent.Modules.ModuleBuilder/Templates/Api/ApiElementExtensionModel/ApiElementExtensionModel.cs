// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.ModuleBuilder.Templates.Api.ApiElementExtensionModel
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
    
    #line 1 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiElementExtensionModel\ApiElementExtensionModel.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class ApiElementExtensionModel : CSharpTemplateBase<ElementExtensionModel>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing Inten" +
                    "t.Metadata.Models;\r\n");
            
            #line 15 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiElementExtensionModel\ApiElementExtensionModel.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.Format("using {0};", GetBaseElementModel().ParentModule.ApiNamespace)));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 19 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiElementExtensionModel\ApiElementExtensionModel.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    [IntentManaged(Mode.Merge)]\r\n    public class ");
            
            #line 22 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiElementExtensionModel\ApiElementExtensionModel.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" : ");
            
            #line 22 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiElementExtensionModel\ApiElementExtensionModel.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetBaseElementModel().ApiModelName));
            
            #line default
            #line hidden
            this.Write("\r\n    {\r\n        [IntentManaged(Mode.Ignore)]\r\n        public ");
            
            #line 25 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiElementExtensionModel\ApiElementExtensionModel.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("(IElement element) : base(element)\r\n        {\r\n        }\r\n\r\n");
            
            #line 29 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiElementExtensionModel\ApiElementExtensionModel.tt"
  if (Model.MenuOptions != null) {
        foreach(var creationOption in Model.MenuOptions.ElementCreations) { 
            
            #line default
            #line hidden
            this.Write("        public ");
            
            #line 31 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiElementExtensionModel\ApiElementExtensionModel.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(FormatForCollection(creationOption.ApiModelName, creationOption.AllowMultiple())));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 31 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiElementExtensionModel\ApiElementExtensionModel.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetCreationOptionName(creationOption)));
            
            #line default
            #line hidden
            this.Write(" => _element.ChildElements\r\n            .Where(x => x.SpecializationType == ");
            
            #line 32 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiElementExtensionModel\ApiElementExtensionModel.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(creationOption.ApiModelName));
            
            #line default
            #line hidden
            this.Write(".SpecializationType)\r\n            .Select(x => new ");
            
            #line 33 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiElementExtensionModel\ApiElementExtensionModel.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(creationOption.ApiModelName));
            
            #line default
            #line hidden
            this.Write("(x))\r\n");
            
            #line 34 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiElementExtensionModel\ApiElementExtensionModel.tt"
          if (creationOption.GetOptionSettings().AllowMultiple()) { 
            
            #line default
            #line hidden
            this.Write("            .ToList();\r\n");
            
            #line 36 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiElementExtensionModel\ApiElementExtensionModel.tt"
          } else { 
            
            #line default
            #line hidden
            this.Write("            .SingleOrDefault();\r\n");
            
            #line 38 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiElementExtensionModel\ApiElementExtensionModel.tt"
          } 
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 40 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiElementExtensionModel\ApiElementExtensionModel.tt"
      } 
            
            #line default
            #line hidden
            
            #line 41 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\Api\ApiElementExtensionModel\ApiElementExtensionModel.tt"
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
