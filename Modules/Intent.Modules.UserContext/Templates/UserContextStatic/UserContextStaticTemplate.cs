﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.UserContext.Templates.UserContextStatic
{
    using Intent.Modules.Common.CSharp.Templates;
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
    
    #line 1 "C:\Dev\Intent.Modules\Modules\Intent.Modules.UserContext\Templates\UserContextStatic\UserContextStaticTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class UserContextStaticTemplate : CSharpTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(" \r\n");
            
            #line 14 "C:\Dev\Intent.Modules\Modules\Intent.Modules.UserContext\Templates\UserContextStatic\UserContextStaticTemplate.tt"




            
            #line default
            #line hidden
            this.Write("using Intent.Framework;\r\n[assembly: DefaultIntentManaged(Mode.Merge)]\r\n\r\nnamespac" +
                    "e ");
            
            #line 21 "C:\Dev\Intent.Modules\Modules\Intent.Modules.UserContext\Templates\UserContextStatic\UserContextStaticTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write(@"
{
    public class UserContext : IUserContextData
    {
        [IntentManaged(Mode.Ignore, Signature = Mode.Fully)]
        public static IUserContextData Current => ServiceCallContext.Instance.Get<IUserContextData>();

		[IntentInitialGen]
		public UserContext(bool isAuthenticated, string userId, string userName, string givenName, string familyName, string email)
        {
            IsAuthenticated = isAuthenticated;
            UserId = userId;
            UserName = userName;
            GivenName = givenName;
            FamilyName = familyName;
            Email = email;
        }

        public bool IsAuthenticated { get; }
        public string UserId { get; }
        public string UserName { get; }
        public string GivenName { get; }
        public string FamilyName { get; }
        public string Email { get; }
        public string FullName => $""{GivenName} {FamilyName}"".Trim();
    }
}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
