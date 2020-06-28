﻿using System;
using Intent.Engine;
using Intent.Modules.Common.Templates;
using Intent.Templates;

namespace Intent.Modules.Common.Sql.Templates
{
    public abstract class SqlTemplateBase<TModel> : IntentProjectItemTemplateBase<TModel>
    {
        protected SqlTemplateBase(string templateId, IProject project, TModel model) : base(templateId, project, model)
        {
        }

        public override void OnCreated()
        {
            base.OnCreated();
            Types = new SqlTypeResolver();
        }

        public string Location => FileMetadata.LocationInProject;

        public override string RunTemplate()
        {
            var templateOutput = base.RunTemplate();

            return templateOutput;
        }
    }

    public class SqlFileConfiguration : DefaultFileMetadata
    {
        public SqlFileConfiguration(
                    OverwriteBehaviour overwriteBehaviour,
                    string fileName,
                    string defaultLocationInProject,
                    string fileExtension = "sql",
                    string codeGenType = Common.CodeGenType.Basic
                    )
            : base(overwriteBehaviour: overwriteBehaviour, 
                  codeGenType: codeGenType, 
                  fileName: fileName, 
                  fileExtension: fileExtension,
                  defaultLocationInProject: defaultLocationInProject)
        {
        }
    }
}