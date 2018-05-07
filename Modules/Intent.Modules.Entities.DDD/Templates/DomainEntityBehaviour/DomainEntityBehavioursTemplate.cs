﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 14.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.Entities.DDD.Templates.DomainEntityBehaviour
{
    using Intent.MetaModel.Domain;
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
    
    #line 1 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\DomainEntityBehaviour\DomainEntityBehavioursTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class DomainEntityBehavioursTemplate : IntentRoslynProjectItemTemplateBase<IClass>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 13 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\DomainEntityBehaviour\DomainEntityBehavioursTemplate.tt"




            
            #line default
            #line hidden
            this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\n");
            
            #line 20 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\DomainEntityBehaviour\DomainEntityBehavioursTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DependencyUsings));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)] \r\n\r\nnamespace ");
            
            #line 24 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\DomainEntityBehaviour\DomainEntityBehavioursTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public class ");
            
            #line 26 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\DomainEntityBehaviour\DomainEntityBehavioursTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("\r\n    {\r\n\t\tprivate ");
            
            #line 28 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\DomainEntityBehaviour\DomainEntityBehavioursTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassStateName));
            
            #line default
            #line hidden
            this.Write(" _state;\r\n\r\n        public ");
            
            #line 30 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\DomainEntityBehaviour\DomainEntityBehavioursTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 30 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\DomainEntityBehaviour\DomainEntityBehavioursTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassStateName));
            
            #line default
            #line hidden
            this.Write(" state)\r\n        {\r\n\t\t\t_state = state;\r\n        }\r\n\r\n");
            
            #line 35 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\DomainEntityBehaviour\DomainEntityBehavioursTemplate.tt"
 foreach (var operation in Model.Operations)
    {
        string returnType = operation.ReturnType != null ? Types.Get( operation.ReturnType.Type) : "void";
        string parameterDefinitions = operation.Parameters.Any() ? operation.Parameters.Select(x => Types.Get(x.Type) + " " + x.Name.ToCamelCase()).Aggregate((x, y) => x + ", " + y) : "";
        string parameterNames = operation.Parameters.Any() ? operation.Parameters.Select(x => x.Name.ToCamelCase()).Aggregate((x, y) => x + ", " + y) : "";
		if (!operation.IsAbstract)
		{
            
            #line default
            #line hidden
            this.Write("        public ");
            
            #line 42 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\DomainEntityBehaviour\DomainEntityBehavioursTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(returnType));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 42 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\DomainEntityBehaviour\DomainEntityBehavioursTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(operation.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 42 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\DomainEntityBehaviour\DomainEntityBehavioursTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(parameterDefinitions));
            
            #line default
            #line hidden
            this.Write(")\r\n        {\r\n            ");
            
            #line 44 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\DomainEntityBehaviour\DomainEntityBehavioursTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(operation.ReturnType != null ? "return " : ""));
            
            #line default
            #line hidden
            this.Write("_state.");
            
            #line 44 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\DomainEntityBehaviour\DomainEntityBehavioursTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(operation.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 44 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\DomainEntityBehaviour\DomainEntityBehavioursTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(parameterNames));
            
            #line default
            #line hidden
            this.Write(")\r\n        }\r\n");
            
            #line 46 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\DomainEntityBehaviour\DomainEntityBehavioursTemplate.tt"
		}
    }

            
            #line default
            #line hidden
            this.Write("    }\r\n\r\n\tpublic static class ");
            
            #line 51 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\DomainEntityBehaviour\DomainEntityBehavioursTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassStateName));
            
            #line default
            #line hidden
            this.Write("Extensions\r\n    {\r\n        public static ");
            
            #line 53 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\DomainEntityBehaviour\DomainEntityBehavioursTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" Behaviours(this I");
            
            #line 53 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\DomainEntityBehaviour\DomainEntityBehavioursTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassStateName));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 53 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\DomainEntityBehaviour\DomainEntityBehavioursTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassStateName.ToCamelCase()));
            
            #line default
            #line hidden
            this.Write(")\r\n        {\r\n            return new ");
            
            #line 55 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\DomainEntityBehaviour\DomainEntityBehavioursTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("((");
            
            #line 55 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\DomainEntityBehaviour\DomainEntityBehavioursTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassStateName));
            
            #line default
            #line hidden
            this.Write(")");
            
            #line 55 "C:\Dev\Intent.OpenSource\Modules\Intent.Modules.Entities.DDD\Templates\DomainEntityBehaviour\DomainEntityBehavioursTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassStateName.ToCamelCase()));
            
            #line default
            #line hidden
            this.Write(");\r\n        }\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}