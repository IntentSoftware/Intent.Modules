using System.IO;
using Intent.Engine;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.Html.Editor;

namespace Intent.Modules.Common.Html.Templates
{
    public abstract class HtmlTemplateBase : HtmlTemplateBase<object>
    {
        protected HtmlTemplateBase(string templateId, IProject outputTarget) : base(templateId, outputTarget, null)
        {
        }
    }

    public abstract class HtmlTemplateBase<TModel> : IntentProjectItemTemplateBase<TModel>, IHtmlFileMerge
    {
        protected HtmlTemplateBase(string templateId, IProject outputTarget, TModel model) : base(templateId, outputTarget, model)
        {
        }

        public override string RunTemplate()
        {
            var file = CreateOutputFile();

            return file.GetSource();
        }

        protected virtual HtmlFile CreateOutputFile()
        {
            return GetTemplateFile();
        }

        public HtmlFile GetTemplateFile()
        {
            return new HtmlFile(base.RunTemplate());
        }

        public HtmlFile GetExistingFile()
        {
            var metadata = GetMetadata();
            var fullFileName = Path.Combine(metadata.GetFullLocationPath(), metadata.FileNameWithExtension());
            return File.Exists(fullFileName) ? new HtmlFile(File.ReadAllText(fullFileName)) : null;
        }
    }
}