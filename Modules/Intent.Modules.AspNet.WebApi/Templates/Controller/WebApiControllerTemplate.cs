﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.AspNet.WebApi.Templates.Controller
{
    using Intent.SoftwareFactory.Templates;
    using Intent.MetaModel.Service;
    using System;
    using System.IO;
    using System.Diagnostics;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class WebApiControllerTemplate : IntentRoslynProjectItemTemplateBase<IServiceModel>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(" \r\n");
            
            #line 14 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"


            
            #line default
            #line hidden
            this.Write("\r\nusing System;\r\nusing System.Linq;\r\nusing System.Collections.Generic;\r\nusing Sys" +
                    "tem.Transactions;\r\nusing System.Web;\r\nusing System.Web.Http;\r\n");
            
            #line 23 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DependencyUsings));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 27 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    [RoutePrefix(\"api/");
            
            #line 29 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name.ToLower()));
            
            #line default
            #line hidden
            this.Write("\")]\r\n    public class ");
            
            #line 30 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" : ApiController\r\n    {\r\n        private readonly ");
            
            #line 32 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetServiceInterfaceName()));
            
            #line default
            #line hidden
            this.Write(" _appService;");
            
            #line 32 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DeclarePrivateVariables()));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n        public ");
            
            #line 34 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" (");
            
            #line 34 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetServiceInterfaceName()));
            
            #line default
            #line hidden
            this.Write(" appService");
            
            #line 34 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ConstructorParams()));
            
            #line default
            #line hidden
            this.Write("\r\n            )\r\n        {\r\n            _appService = appService ?? throw new Arg" +
                    "umentNullException(nameof(appService));");
            
            #line 37 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ConstructorInit()));
            
            #line default
            #line hidden
            this.Write("\r\n        }\r\n\r\n");
            
            #line 40 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
  foreach (var operation in Model.Operations)
    {

            
            #line default
            #line hidden
            this.Write("        [AcceptVerbs(\"");
            
            #line 43 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetHttpVerb(operation).ToString().ToUpper()));
            
            #line default
            #line hidden
            this.Write("\")]\r\n        ");
            
            #line 44 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetSecurityAttribute(operation)));
            
            #line default
            #line hidden
            this.Write("\r\n        [Route(\"");
            
            #line 45 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(operation.Name.ToLower()));
            
            #line default
            #line hidden
            this.Write("\")]\r\n        public ");
            
            #line 46 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetOperationReturnType(operation)));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 46 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(operation.Name));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 46 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetOperationParameters(operation)));
            
            #line default
            #line hidden
            this.Write(")\r\n        {");
            
            #line 47 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(BeginOperation(operation)));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 48 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
      if (operation.ReturnType != null)
        {

            
            #line default
            #line hidden
            this.Write("            ");
            
            #line 50 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetOperationReturnType(operation)));
            
            #line default
            #line hidden
            this.Write(" result = default(");
            
            #line 50 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetOperationReturnType(operation)));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 51 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
      }
            
            #line default
            #line hidden
            this.Write("            TransactionOptions tso = new TransactionOptions();\r\n            tso.I" +
                    "solationLevel = IsolationLevel.");
            
            #line 53 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture("ReadCommitted"));
            
            #line default
            #line hidden
            this.Write(";\r\n\r\n            try\r\n            {");
            
            #line 56 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(BeforeTransaction(operation)));
            
            #line default
            #line hidden
            this.Write("\r\n                using (TransactionScope ts = new TransactionScope(TransactionSc" +
                    "opeOption.Required, tso))\r\n                {");
            
            #line 58 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(BeforeCallToAppLayer(operation)));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 59 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"

        if (operation.ReturnType != null)
        {

            
            #line default
            #line hidden
            this.Write("                    var appServiceResult = _appService.");
            
            #line 62 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(operation.Name));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 62 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetOperationCallParameters(operation)));
            
            #line default
            #line hidden
            this.Write(");\r\n                    result = appServiceResult;\r\n");
            
            #line 64 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
      }
        else
        {

            
            #line default
            #line hidden
            this.Write("                        _appService.");
            
            #line 67 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(operation.Name));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 67 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetOperationCallParameters(operation)));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 68 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
      }

            
            #line default
            #line hidden
            
            #line 69 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AfterCallToAppLayer(operation)));
            
            #line default
            #line hidden
            this.Write("\r\n                    ts.Complete();\r\n                }");
            
            #line 71 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AfterTransaction(operation)));
            
            #line default
            #line hidden
            this.Write("\r\n            }\r\n            catch (Exception e) \r\n            {");
            
            #line 74 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(OnExceptionCaught(operation)));
            
            #line default
            #line hidden
            this.Write("\r\n            }\r\n\r\n");
            
            #line 77 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
        if (operation.ReturnType != null)
        {

            
            #line default
            #line hidden
            this.Write("            return result;\r\n");
            
            #line 80 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
      }
            
            #line default
            #line hidden
            this.Write("\r\n        }\r\n\r\n");
            
            #line 84 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
    }

        // Source code of base class: http://aspnetwebstack.codeplex.com/SourceControl/latest#src/System.Web.Http/ApiController.cs
        // As dispose is not virtual, looking at the source code, this looks like a better hook in point

            
            #line default
            #line hidden
            this.Write("        protected override void Dispose(bool disposing)\r\n        {\r\n            b" +
                    "ase.Dispose(disposing);\r\n\r\n            //dispose all resources\r\n            _app" +
                    "Service.Dispose();");
            
            #line 94 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(OnDispose()));
            
            #line default
            #line hidden
            this.Write("\r\n        }\r\n");
            
            #line 96 "D:\Projects\IntentModules\Modules\Intent.Modules.AspNet.WebApi\Templates\Controller\WebApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassMethods()));
            
            #line default
            #line hidden
            this.Write("\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
