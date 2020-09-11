﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Intent.Engine;
using Intent.Modules.Common.Plugins;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.Java.Templates;
using Intent.Plugins.FactoryExtensions;
using Intent.Utils;

namespace Intent.Modules.Common.Java.Weaving
{
    public class JavaWeavingOutputTransformer : FactoryExtensionBase, ITransformOutput
    {
        public override string Id => "Intent.Common.Java.OutputWeaver";

        public void Transform(IOutputFile output)
        {
            if (!(output.Template is IJavaMerged typeScriptMerged))
            {
                return;
            }

            var existingFile = typeScriptMerged.GetExistingFile();

            if (existingFile == null)
            {
                return;
            }

            try
            {
                var merger = new JavaWeavingMerger();

                var newContent = merger.Merge(existingFile, output.Content);

                output.ChangeContent(newContent);
            }
            catch (Exception e)
            {
                output.ChangeContent(existingFile.GetSource());

                Logging.Log.Failure($"Error while weaving Java file: {output.FileMetadata.GetRelativeFilePath()}");
                Logging.Log.Failure(e.ToString());
            }
        }
    }
}
