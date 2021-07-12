// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.ModuleBuilder.Templates.TemplateExtensions
{
    using Intent.Modules.Common.Templates;
    using Intent.Modules.Common.CSharp.Templates;
    using Intent.Metadata.Models;
    using Intent.Templates;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\TemplateExtensions\TemplateExtensionsTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class TemplateExtensionsTemplate : CSharpTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\n");
            this.Write("using Intent.Modules.Common.Templates;\r\n\r\n[assembly: DefaultIntentManaged(Mode.Me" +
                    "rge)]\r\n\r\nnamespace ");
            
            #line 10 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\TemplateExtensions\TemplateExtensionsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public static class ");
            
            #line 12 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\TemplateExtensions\TemplateExtensionsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("\r\n    {\r\n");
            
            #line 14 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\TemplateExtensions\TemplateExtensionsTemplate.tt"
  foreach(var template in Templates) { 
            
            #line default
            #line hidden
            this.Write("        public static string Get");
            
            #line 15 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\TemplateExtensions\TemplateExtensionsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(((IHasName)GetTemplate<ITemplateWithModel>(template.SourceTemplateId, template.ModelId).Model).Name));
            
            #line default
            #line hidden
            this.Write("Name<T>(this IntentTemplateBase<T> template) where T: ");
            
            #line 15 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\TemplateExtensions\TemplateExtensionsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(template.ModelType));
            
            #line default
            #line hidden
            this.Write("\r\n        {\r\n            return template.GetTypeName(");
            
            #line 17 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\TemplateExtensions\TemplateExtensionsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetTypeName(template.SourceTemplateId, template.ModelId)));
            
            #line default
            #line hidden
            this.Write(".TemplateId, template.Model);\r\n        }\r\n\r\n");
            
            #line 20 "C:\Dev\Intent.Modules\Modules\Intent.Modules.ModuleBuilder\Templates\TemplateExtensions\TemplateExtensionsTemplate.tt"
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
