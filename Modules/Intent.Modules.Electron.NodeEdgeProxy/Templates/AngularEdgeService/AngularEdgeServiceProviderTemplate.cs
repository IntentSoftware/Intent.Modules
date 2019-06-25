﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.Electron.NodeEdgeProxy.Templates.AngularEdgeService
{
    using Intent.Modules.Common.Templates;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Electron.NodeEdgeProxy\Templates\AngularEdgeService\AngularEdgeServiceProviderTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class AngularEdgeServiceProviderTemplate : IntentProjectItemTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("namespace App {\r\n    interface IEdge {\r\n        func(options: IEdgeFuncOptions): " +
                    "IEdgeProxy;\r\n    }\r\n\r\n    interface IEdgeFuncOptions {\r\n        assemblyFile: st" +
                    "ring;\r\n        typeName?: string;\r\n        methodName?: string;\r\n    }\r\n\r\n    ex" +
                    "port interface IEdgeProxy {\r\n        <TData, TResult>(data: TData, callback: (er" +
                    "ror: any, result: TResult) => void): void;\r\n    }\r\n\r\n    export interface IEdgeC" +
                    "allInterceptor {\r\n        request(config: IEdgeCallConfig): void;\r\n    }\r\n\r\n    " +
                    "export interface IEdgeCallConfig {\r\n        readonly headers: { [type: string]: " +
                    "string };\r\n    }\r\n\r\n    export interface IEdgeService {\r\n        callMethod<TRet" +
                    "urn>(typeName: string, methodName: string, ...methodParameters: any[]): ng.IProm" +
                    "ise<TReturn>;\r\n        createProxy(typeName: string, methodName: string): IEdgeP" +
                    "roxy;\r\n    }\r\n\r\n    export class EdgeServiceProvider implements ng.IServiceProvi" +
                    "der {\r\n        private readonly service: IEdge;\r\n        private assemblyFile: s" +
                    "tring;\r\n\r\n        readonly interceptors: string[] = [];\r\n        readonly proxyC" +
                    "ache: { [type: string]: any; } = {};\r\n\r\n        static $inject = [\"$q\", \"$inject" +
                    "or\"];\r\n        constructor(\r\n            public $q: ng.IQService,\r\n            p" +
                    "ublic $injector: { get<T>(name: string): T }\r\n        ) {\r\n            this.serv" +
                    "ice = window[\"require\"](\"electron-edge-js\");\r\n        }\r\n\r\n        setAssemblyFi" +
                    "le = (assemblyFile: string): void => {\r\n            this.assemblyFile = assembly" +
                    "File;\r\n        }\r\n\r\n        $get = (): IEdgeService => {\r\n            return {\r\n" +
                    "                callMethod: this.callMethodImplementation,\r\n                crea" +
                    "teProxy: this.createProxyImplementation\r\n            };\r\n        }\r\n\r\n        pr" +
                    "ivate callMethodImplementation = <TReturn>(typeName: string, methodName: string," +
                    " ...methodParameters: any[]): ng.IPromise<TReturn> => {\r\n            return this" +
                    ".$q<TReturn>((resolve: ng.IQResolveReject<TReturn>, reject: ng.IQResolveReject<a" +
                    "ny>) => {\r\n                try {\r\n                    const config: IEdgeCallCon" +
                    "fig = {\r\n                        headers: {}\r\n                    };\r\n\r\n        " +
                    "            for (const interceptor of this.interceptors.map(x => this.$injector." +
                    "get<IEdgeCallInterceptor>(x))) {\r\n                        interceptor.request(co" +
                    "nfig);\r\n                    }\r\n\r\n                    const data = {\r\n           " +
                    "             headers: Object.keys(config.headers)\r\n                            ." +
                    "map(x => ({\r\n                                name: x,\r\n                         " +
                    "       value: config.headers[x]\r\n                            })),\r\n             " +
                    "           methodName: methodName,\r\n                        methodParameters: me" +
                    "thodParameters.map(x => JSON.stringify(x)),\r\n                    }\r\n\r\n          " +
                    "          const proxy = this.createProxyImplementation(typeName, \"Invoke\");\r\n   " +
                    "                 proxy(data, (error: any, result: string) => {\r\n                " +
                    "        if (error) {\r\n                            reject(error);\r\n              " +
                    "              return;\r\n                        }\r\n\r\n                        reso" +
                    "lve(JSON.parse(result).response);\r\n                    });\r\n                } ca" +
                    "tch (e) {\r\n                    reject(e);\r\n                }\r\n            });\r\n " +
                    "       }\r\n\r\n        private createProxyImplementation = (typeName: string, metho" +
                    "dName: string): IEdgeProxy => {\r\n            if (!this.assemblyFile) {\r\n        " +
                    "        throw new Error(\"Could not create proxy, as assemblyFile not set. Use th" +
                    "e EdgeServiceProvider\'s .setAssemblyFile(...) method in your angular module conf" +
                    "ig.\");\r\n            }\r\n\r\n            if (!this.proxyCache[typeName]) {\r\n        " +
                    "        this.proxyCache[typeName] = this.service.func({\r\n                    ass" +
                    "emblyFile: this.assemblyFile,\r\n                    typeName: typeName,\r\n        " +
                    "            methodName: methodName\r\n                });\r\n            }\r\n\r\n      " +
                    "      return this.proxyCache[typeName];\r\n        }\r\n    }\r\n\r\n    angular.module(" +
                    "\"App\").provider(\"EdgeService\", EdgeServiceProvider);\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}