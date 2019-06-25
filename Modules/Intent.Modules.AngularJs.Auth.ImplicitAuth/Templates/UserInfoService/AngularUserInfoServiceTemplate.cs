﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.AngularJs.Auth.ImplicitAuth.Templates.UserInfoService
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
    
    #line 1 "C:\Dev\Intent.Modules\Modules\Intent.Modules.AngularJs.Auth.ImplicitAuth\Templates\UserInfoService\AngularUserInfoServiceTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class AngularUserInfoServiceTemplate : IntentProjectItemTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(" \r\n");
            
            #line 13 "C:\Dev\Intent.Modules\Modules\Intent.Modules.AngularJs.Auth.ImplicitAuth\Templates\UserInfoService\AngularUserInfoServiceTemplate.tt"




            
            #line default
            #line hidden
            this.Write("\'use strict\';\r\n\r\nnamespace App.Auth {\r\n        export class UserInfoService {\r\n  " +
                    "      static $inject = [\"OidcTokenManager\"];\r\n\r\n        constructor(\r\n          " +
                    "  private tokenManager: Oidc.OidcTokenManager) {\r\n\r\n            this.tryLoadFrom" +
                    "Storage();\r\n        }\r\n\r\n        userInfo: UserInfo = new UserInfo();\r\n\r\n       " +
                    " public loadFromProfile = (profile: any): void => {\r\n            this.userInfo.i" +
                    "sAuthenticated = true;\r\n            this.userInfo.userName = profile.name;\r\n    " +
                    "        this.userInfo.fullName = profile.given_name + \" \" + profile.family_name;" +
                    "\r\n            this.userInfo.roles = Array.isArray(profile.role) ? profile.role :" +
                    " [profile.role];\r\n            this.userInfo.userId = profile.sub;\r\n        }\r\n\r\n" +
                    "        public logOut() {\r\n            this.tokenManager.redirectForLogout();\r\n " +
                    "       }\r\n\r\n        private tryLoadFromStorage = () => {\r\n            if (!this." +
                    "tokenManager.expired)\r\n                this.loadFromProfile(this.tokenManager.pr" +
                    "ofile);\r\n        };\r\n\r\n    }\r\n\r\n    angular.module(\"Auth\").service(\"UserInfoServ" +
                    "ice\", UserInfoService);\r\n\r\n    export class UserInfo {\r\n        public isAuthent" +
                    "icated = false;\r\n        public userId: string = \"\";\r\n        public userName: s" +
                    "tring = \"\";\r\n        public fullName: string = \"\";\r\n        public roles: string" +
                    "[] = [];\r\n\r\n        constructor() { }\r\n\r\n        public load = (userInfo: UserIn" +
                    "fo) => {\r\n            this.isAuthenticated = true;\r\n            this.userId = us" +
                    "erInfo.userId;\r\n            this.userName = userInfo.userName;\r\n            this" +
                    ".fullName = userInfo.fullName;\r\n            this.roles = userInfo.roles;\r\n      " +
                    "  }\r\n\r\n        public clear = () => {\r\n            this.isAuthenticated = false;" +
                    "\r\n            this.userName = \"\";\r\n            this.fullName = \"\";\r\n            " +
                    "this.roles = [];\r\n            this.userId = \"\";\r\n        }\r\n\r\n        public has" +
                    "Authorization = (): boolean => {\r\n            return this.isAuthenticated; // Ex" +
                    "tent this for your app...\r\n        }\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}