using Intent.Modules.Common.VisualStudio;

namespace Intent.Modules.Electron.NodeEdgeProxy
{
    public static class NugetPackages
    {
        public static NugetPackageInfo IntentFrameworkCore = new NugetPackageInfo("Intent.Framework.Core", "1.0.0", "net45");

        public static NugetPackageInfo NewtonsoftJson = new NugetPackageInfo("Newtonsoft.Json", "9.0.1", "net452")
         .WithAssemblyRedirect(new AssemblyRedirectInfo("Newtonsoft.Json", "9.0.0.0", "30ad4fe6b2a6aeed"));
    }
}