using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modules.Common.Types.Api;
using Intent.RoslynWeaver.Attributes;
using Intent.Modules.Common;

[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiElementModel", Version = "1.0")]
[assembly: DefaultIntentManaged(Mode.Merge)]

namespace Intent.Modelers.Services.Api
{
    [IntentManaged(Mode.Merge, Signature = Mode.Merge)]
    public class EnumModel : IHasStereotypes, IMetadataModel, IHasFolder, IHasName
    {
        protected readonly IElement _element;

        [IntentManaged(Mode.Ignore)]
        public EnumModel(IElement element, string requiredType = SpecializationType)
        {
            _element = element;
            Folder = FolderModel.SpecializationType.Equals(_element.ParentElement?.SpecializationType, StringComparison.OrdinalIgnoreCase) ? new FolderModel(_element.ParentElement) : null;
        }

        [IntentManaged(Mode.Fully)]
        public string Id => _element.Id;

        [IntentManaged(Mode.Fully)]
        public IEnumerable<IStereotype> Stereotypes => _element.Stereotypes;
        public FolderModel Folder { get; }

        [IntentManaged(Mode.Fully)]
        public string Name => _element.Name;
        public IElementApplication Application => _element.Application;

        [IntentManaged(Mode.Fully)]
        public IList<EnumLiteralModel> Literals => _element.ChildElements
            .GetElementsOfType(EnumLiteralModel.SpecializationTypeId)
            .Select(x => new EnumLiteralModel(x))
            .ToList();
        public string Comment => _element.Comment;
        public const string SpecializationType = "Enum";

        [IntentManaged(Mode.Fully)]
        public bool Equals(EnumModel other)
        {
            return Equals(_element, other?._element);
        }

        [IntentManaged(Mode.Fully)]
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((EnumModel)obj);
        }

        [IntentManaged(Mode.Fully)]
        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }

        [IntentManaged(Mode.Fully)]
        public IElement InternalElement => _element;

        [IntentManaged(Mode.Fully)]
        public override string ToString()
        {
            return _element.ToString();
        }
        public const string SpecializationTypeId = "bc763e02-b38f-41e4-aac3-ea62e39d34f2";
    }
}