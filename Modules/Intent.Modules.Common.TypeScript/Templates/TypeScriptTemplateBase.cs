using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Intent.Code.Weaving.TypeScript.Editor;
using Intent.Engine;
using Intent.Modules.Common.Templates;
using Intent.Templates;
using Intent.Utils;

namespace Intent.Modules.Common.TypeScript.Templates
{
    public abstract class TypeScriptTemplateBase : TypeScriptTemplateBase<object>
    {
        protected TypeScriptTemplateBase(string templateId, IOutputTarget outputTarget) : base(templateId, outputTarget, null)
        {
        }
    }

    public abstract class TypeScriptTemplateBase<TModel, TDecorator> : TypeScriptTemplateBase<TModel>, IHasDecorators<TDecorator>
        where TDecorator : ITemplateDecorator
    {
        private readonly ICollection<TDecorator> _decorators = new List<TDecorator>();

        protected TypeScriptTemplateBase(string templateId, IOutputTarget outputTarget, TModel model) : base(templateId, outputTarget, model)
        {
        }

        public IEnumerable<TDecorator> GetDecorators()
        {
            return _decorators.OrderBy(x => x.Priority);
        }

        public void AddDecorator(TDecorator decorator)
        {
            _decorators.Add(decorator);
        }

        /// <summary>
        /// Aggregates the specified <see cref="propertyFunc"/> property of all Decorators. Ignores Decorators where the property returns null.
        /// </summary>
        /// <param name="propertyFunc"></param>
        /// <returns></returns>
        protected string GetDecoratorsOutput(Func<TDecorator, string> propertyFunc)
        {
            return GetDecorators().Aggregate(propertyFunc);
        }
    }

    public abstract class TypeScriptTemplateBase<TModel> : IntentTypescriptProjectItemTemplateBase<TModel>, ITypeScriptMerged
    {
        protected TypeScriptTemplateBase(string templateId, IOutputTarget outputTarget, TModel model) : base(templateId, outputTarget, model)
        {
        }

        public ICollection<TypeScriptImport> Imports = new List<TypeScriptImport>();

        public override string RunTemplate()
        {
            var file = CreateOutputFile();

            file.AddDependencyImports(this);

            return file.GetSource();
        }

        protected virtual TypeScriptFile CreateOutputFile()
        {
            return GetTemplateFile();
        }

        public void AddImport(string type, string location)
        {
            Imports.Add(new TypeScriptImport(type, location));
        }

        public TypeScriptFile GetTemplateFile()
        {
            try
            {
                return new TypeScriptFileEditor(base.RunTemplate()).File;
            }
            catch
            {
                Logging.Log.Failure($@"Failed to parse TypesScript output file:
{base.RunTemplate()}");
                throw;
            }
        }

        public TypeScriptFile GetExistingFile()
        {
            var metadata = GetMetadata();
            var fullFileName = Path.Combine(metadata.GetFullLocationPath(), metadata.FileNameWithExtension());
            return File.Exists(fullFileName) ? new TypeScriptFileEditor(File.ReadAllText(fullFileName)).File : null;
        }
    }

    public class TypeScriptImport
    {
        public TypeScriptImport(string type, string location)
        {
            Type = type;
            Location = location;
        }

        public string Type { get; set; }
        public string Location { get; set; }
    }
}