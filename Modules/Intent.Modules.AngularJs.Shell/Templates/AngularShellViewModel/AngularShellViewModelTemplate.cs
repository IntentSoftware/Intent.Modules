﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 14.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.AngularJs.Shell.Templates.AngularShellViewModel
{
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
    
    #line 1 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.AngularJs.Shell\Templates\AngularShellViewModel\AngularShellViewModelTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class AngularShellViewModelTemplate : IntentProjectItemTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(" \r\n");
            
            #line 13 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.AngularJs.Shell\Templates\AngularShellViewModel\AngularShellViewModelTemplate.tt"




            
            #line default
            #line hidden
            this.Write("\r\nnamespace App {\r\n    export class ShellViewModel {\r\n\r\n        applicationName: " +
                    "string = \"");
            
            #line 21 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.AngularJs.Shell\Templates\AngularShellViewModel\AngularShellViewModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Project.Application.ApplicationName));
            
            #line default
            #line hidden
            this.Write("\";\r\n        userName: string = \"User Name\";\r\n\r\n        logOut = () => {\r\n        " +
                    "    alert(\'Not implemented...\');\r\n        }\r\n\r\n\t\tdispose = () => {\r\n\t\t}\r\n    }\r\n" +
                    "}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
