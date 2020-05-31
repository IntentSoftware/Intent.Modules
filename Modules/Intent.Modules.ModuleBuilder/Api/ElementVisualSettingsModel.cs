using System;
using System.Collections.Generic;
using System.Linq;
using Intent.IArchitect.Agent.Persistence.Model.Common;
using Intent.Metadata.Models;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("ModuleBuilder.Templates.Api.ApiElementModel", Version = "1.0")]

namespace Intent.Modules.ModuleBuilder.Api
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class ElementVisualSettingsModel : IHasStereotypes, IMetadataModel
    {
        public const string SpecializationType = "Element Visual Settings";
        protected readonly IElement _element;

        public ElementVisualSettingsModel(IElement element)
        {
            if (!SpecializationType.Equals(element.SpecializationType, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception($"Cannot create a 'ElementVisualSettingsModel' from element with specialization type '{element.SpecializationType}'. Must be of type '{SpecializationType}'");
            }
            _element = element;
        }

        [IntentManaged(Mode.Fully)]
        public string Id => _element.Id;

        [IntentManaged(Mode.Fully)]
        public string Name => _element.Name;

        [IntentManaged(Mode.Fully)]
        public IEnumerable<IStereotype> Stereotypes => _element.Stereotypes;


        [IntentManaged(Mode.Fully)]
        public bool Equals(ElementVisualSettingsModel other)
        {
            return Equals(_element, other?._element);
        }

        [IntentManaged(Mode.Fully)]
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ElementVisualSettingsModel)obj);
        }

        [IntentManaged(Mode.Fully)]
        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }

        [IntentManaged(Mode.Fully)]
        public override string ToString()
        {
            return _element.ToString();
        }

        [IntentManaged(Mode.Fully)]
        public IElement InternalElement => _element;

        [IntentManaged(Mode.Fully)]
        public IList<PathDrawSettingsModel> Paths => _element.ChildElements
            .Where(x => x.SpecializationType == PathDrawSettingsModel.SpecializationType)
            .Select(x => new PathDrawSettingsModel(x))
            .ToList();

        [IntentManaged(Mode.Fully)]
        public IList<TextDrawSettingsModel> Texts => _element.ChildElements
            .Where(x => x.SpecializationType == TextDrawSettingsModel.SpecializationType)
            .Select(x => new TextDrawSettingsModel(x))
            .ToList();

        [IntentManaged(Mode.Fully)]
        public StereotypesVisualSettingsModel StereotypesVisual => _element.ChildElements
            .Where(x => x.SpecializationType == StereotypesVisualSettingsModel.SpecializationType)
            .Select(x => new StereotypesVisualSettingsModel(x))
            .SingleOrDefault();

        public ElementVisualSettingsPersistable ToPersistable()
        {
            return new ElementVisualSettingsPersistable()
            {
                SpecializationType = this.TypeReference.Element.Name,
                Position = new PositionSettings()
                {
                    X = this.GetPositionSettings().X() ?? "${x}",
                    Y = this.GetPositionSettings().Y() ?? "${y}"
                },
                Size = new SizeSettings()
                {
                    Width = this.GetPositionSettings().Width() ?? "${w}",
                    Height = this.GetPositionSettings().Height() ?? "${h}"
                },
                DefaultSize = new SizeSettings()
                {
                    Width = this.GetPositionSettings().Width() ?? "${x}",
                    Height = this.GetPositionSettings().Height() ?? "${y}"
                },
                DisplayElements = Paths.Select(x => x.ToPersistable()).Cast<object>()
                    .Concat(Texts.Select(x => x.ToPersistable())).ToList(),
                StereotypesVisualSettings = StereotypesVisual?.ToPersistable(),
                ChildElementVisualSettings = ChildVisuals.Select(x => x.ToPersistable()).ToList()
            };
        }

        [IntentManaged(Mode.Fully)]
        public IList<ElementVisualSettingsModel> ChildVisuals => _element.ChildElements
            .Where(x => x.SpecializationType == ElementVisualSettingsModel.SpecializationType)
            .Select(x => new ElementVisualSettingsModel(x))
            .ToList();

        [IntentManaged(Mode.Fully)]
        public ITypeReference TypeReference => _element.TypeReference;
    }
}