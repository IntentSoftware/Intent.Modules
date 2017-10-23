﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 14.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.IdentityServer.Templates.AspNetIdentityModel
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
    
    #line 1 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.IdentityServer\Templates\AspNetIdentityModel\AspNetIdentityModelTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class AspNetIdentityModelTemplate : IntentRoslynProjectItemTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(" \r\n");
            
            #line 13 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.IdentityServer\Templates\AspNetIdentityModel\AspNetIdentityModelTemplate.tt"




            
            #line default
            #line hidden
            this.Write(@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using IdSvr3 = IdentityServer3.Core;
using Intent.CodeGen;

[assembly: DefaultIntentManaged(Mode.Fully)]

namespace ");
            
            #line 29 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.IdentityServer\Templates\AspNetIdentityModel\AspNetIdentityModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write(@"
{
    public class User : IdentityUser
    {
        public User()
        {
        }

        public User(string userName, string firstName, string lastName, string email) : base(userName)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Role : IdentityRole
    {
        public Role()
        {
        }

        public Role(string roleName) : base(roleName)
        {
        }
    }

    public class ");
            
            #line 59 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.IdentityServer\Templates\AspNetIdentityModel\AspNetIdentityModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DB_CONTEXT_NAME));
            
            #line default
            #line hidden
            this.Write(" : IdentityDbContext<User, Role, string, IdentityUserLogin, IdentityUserRole, Ide" +
                    "ntityUserClaim>\r\n    {\r\n        public ");
            
            #line 61 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.IdentityServer\Templates\AspNetIdentityModel\AspNetIdentityModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DB_CONTEXT_NAME));
            
            #line default
            #line hidden
            this.Write("()\r\n            : base(\"IdentityDB\")\r\n        {\r\n        }\r\n    }\r\n\r\n    public c" +
                    "lass UserStore : UserStore<User, Role, string, IdentityUserLogin, IdentityUserRo" +
                    "le, IdentityUserClaim>\r\n    {\r\n        public UserStore(");
            
            #line 69 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.IdentityServer\Templates\AspNetIdentityModel\AspNetIdentityModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DB_CONTEXT_NAME));
            
            #line default
            #line hidden
            this.Write(@" ctx)
            : base(ctx)
        {
        }
    }

    public class UserManager : UserManager<User, string>
    {
        public UserManager(UserStore store)
            : base(store)
        {
            this.ClaimsIdentityFactory = new ClaimsFactory();
        }
    }

    public class ClaimsFactory : ClaimsIdentityFactory<User, string>
    {
        public ClaimsFactory()
        {
            this.UserIdClaimType = IdSvr3.Constants.ClaimTypes.Subject;
            this.UserNameClaimType = IdSvr3.Constants.ClaimTypes.PreferredUserName;
            this.RoleClaimType = IdSvr3.Constants.ClaimTypes.Role;
        }

        public override async System.Threading.Tasks.Task<System.Security.Claims.ClaimsIdentity> CreateAsync(UserManager<User, string> manager, User user, string authenticationType)
        {
            var ci = await base.CreateAsync(manager, user, authenticationType);
            if (!String.IsNullOrWhiteSpace(user.FirstName))
            {
                ci.AddClaim(new Claim(""given_name"", user.FirstName));
            }
            if (!String.IsNullOrWhiteSpace(user.LastName))
            {
                ci.AddClaim(new Claim(""family_name"", user.LastName));
            }
            return ci;
        }
    }

    public class RoleStore : RoleStore<Role>
    {
        public RoleStore(");
            
            #line 110 "C:\Dev\Intent\IntentArchitect\Modules\Intent.Modules.IdentityServer\Templates\AspNetIdentityModel\AspNetIdentityModelTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DB_CONTEXT_NAME));
            
            #line default
            #line hidden
            this.Write(" ctx)\r\n            : base(ctx)\r\n        {\r\n        }\r\n    }\r\n\r\n    public class R" +
                    "oleManager : RoleManager<Role>\r\n    {\r\n        public RoleManager(RoleStore stor" +
                    "e)\r\n            : base(store)\r\n        {\r\n        }\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
