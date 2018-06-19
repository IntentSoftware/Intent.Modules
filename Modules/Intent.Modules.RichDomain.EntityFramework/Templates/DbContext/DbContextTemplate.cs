﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.RichDomain.EntityFramework.Templates.DbContext
{
    using Intent.SoftwareFactory.MetaModels.UMLModel;
    using Intent.Modules.RichDomain;
    using Intent.SoftwareFactory.Templates;
    using System;
    using System.IO;
    using System.Diagnostics;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules\Modules\Intent.Modules.RichDomain.EntityFramework\Templates\DbContext\DbContextTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class DbContextTemplate : IntentRoslynProjectItemTemplateBase<IEnumerable<Class>>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(" \r\n\r\nusing System.Data.Entity;\r\nusing System.Data.Entity.ModelConfiguration.Conve" +
                    "ntions;\r\nusing Intent.Framework.EntityFramework;\r\n\r\n[assembly: DefaultIntentMana" +
                    "ged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 22 "C:\Dev\Intent.Modules\Modules\Intent.Modules.RichDomain.EntityFramework\Templates\DbContext\DbContextTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public class ");
            
            #line 24 "C:\Dev\Intent.Modules\Modules\Intent.Modules.RichDomain.EntityFramework\Templates\DbContext\DbContextTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(BoundedContextName));
            
            #line default
            #line hidden
            this.Write("DbContext : DbContextEx\r\n    {\r\n        public ");
            
            #line 26 "C:\Dev\Intent.Modules\Modules\Intent.Modules.RichDomain.EntityFramework\Templates\DbContext\DbContextTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(BoundedContextName));
            
            #line default
            #line hidden
            this.Write("DbContext()\r\n            : base(\"");
            
            #line 27 "C:\Dev\Intent.Modules\Modules\Intent.Modules.RichDomain.EntityFramework\Templates\DbContext\DbContextTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(BoundedContextName));
            
            #line default
            #line hidden
            this.Write("DB\")\r\n        {\r\n\r\n        } \r\n\r\n        protected override void OnModelCreating(" +
                    "DbModelBuilder modelBuilder)\r\n        {\r\n            base.OnModelCreating(modelB" +
                    "uilder);\r\n            \r\n            modelBuilder.HasDefaultSchema(\"");
            
            #line 36 "C:\Dev\Intent.Modules\Modules\Intent.Modules.RichDomain.EntityFramework\Templates\DbContext\DbContextTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(BoundedContextName));
            
            #line default
            #line hidden
            this.Write("\");\r\n            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention" +
                    ">();\r\n");
            
            #line 38 "C:\Dev\Intent.Modules\Modules\Intent.Modules.RichDomain.EntityFramework\Templates\DbContext\DbContextTemplate.tt"
 foreach (var model in Model) {
	   if (!model.IsEntity()) {
			continue;
       }

            
            #line default
            #line hidden
            this.Write("            modelBuilder.Configurations.Add(new ");
            
            #line 43 "C:\Dev\Intent.Modules\Modules\Intent.Modules.RichDomain.EntityFramework\Templates\DbContext\DbContextTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Mapping());\r\n");
            
            #line 44 "C:\Dev\Intent.Modules\Modules\Intent.Modules.RichDomain.EntityFramework\Templates\DbContext\DbContextTemplate.tt"
 }
            
            #line default
            #line hidden
            this.Write("        }\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
