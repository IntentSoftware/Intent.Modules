﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.AngularJs.Templates.ViewModel
{
    using Intent.Modules.Common.Templates;
    using System;
    using System.IO;
    using System.Diagnostics;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules\Modules\Intent.Modules.AngularJs\Templates\ViewModel\AngularJsViewModelTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class AngularJsViewModelTemplate : IntentTypescriptProjectItemTemplateBase<ViewStateModel>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(" \r\n");
            
            #line 13 "C:\Dev\Intent.Modules\Modules\Intent.Modules.AngularJs\Templates\ViewModel\AngularJsViewModelTemplate.tt"




            
            #line default
            #line hidden
            this.Write("// NOTE: NB! This is an R&D Module.\r\nnamespace ");
            
            #line 18 "C:\Dev\Intent.Modules\Modules\Intent.Modules.AngularJs\Templates\ViewModel\AngularJsViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write(" {\r\n    export class ");
            
            #line 19 "C:\Dev\Intent.Modules\Modules\Intent.Modules.AngularJs\Templates\ViewModel\AngularJsViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" {\r\n\r\n        constructor(state: I");
            
            #line 21 "C:\Dev\Intent.Modules\Modules\Intent.Modules.AngularJs\Templates\ViewModel\AngularJsViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("State) {\r\n        }\r\n        \r\n        dispose = () => {\r\n        }\r\n    }\r\n\r\n   " +
                    " export interface I");
            
            #line 28 "C:\Dev\Intent.Modules\Modules\Intent.Modules.AngularJs\Templates\ViewModel\AngularJsViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("State {\r\n");
            
            #line 29 "C:\Dev\Intent.Modules\Modules\Intent.Modules.AngularJs\Templates\ViewModel\AngularJsViewModelTemplate.tt"
	foreach(var command in Model.Commands) {
            
            #line default
            #line hidden
            this.Write("\t\t");
            
            #line 30 "C:\Dev\Intent.Modules\Modules\Intent.Modules.AngularJs\Templates\ViewModel\AngularJsViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(command.Name));
            
            #line default
            #line hidden
            this.Write("Command: ICommand;\r\n");
            
            #line 31 "C:\Dev\Intent.Modules\Modules\Intent.Modules.AngularJs\Templates\ViewModel\AngularJsViewModelTemplate.tt"
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