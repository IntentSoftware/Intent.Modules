using System;
using System.Collections.Generic;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using System.Linq;
using Intent.IArchitect.Agent.Persistence.Model.Common;
using Intent.Modules.ModelerBuilder.External;
using Intent.Modules.ModuleBuilder.Helpers;
using Intent.RoslynWeaver.Attributes;
using IconType = Intent.IArchitect.Common.Types.IconType;

[assembly: IntentTemplate("ModuleBuilder.Templates.Api.ApiElementModel", Version = "1.0")]
[assembly: DefaultIntentManaged(Mode.Merge)]

namespace Intent.Modules.ModuleBuilder.Api
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class ElementCreationOptionModel : IHasStereotypes, IMetadataModel
    {
        protected readonly IElement _element;
        public const string SpecializationType = "Element Creation Option";

        public ElementCreationOptionModel(IElement element)
        {
            if (element.SpecializationType != SpecializationType)
            {
                throw new ArgumentException($"Invalid element [{element}]");
            }

            _element = element;

            TargetSpecializationType = _element.TypeReference.Element.Name;
            //Text = element.Name;
            //Shortcut = element.TypeReference.Element.GetStereotypeProperty<string>("Default Creation Options", "Shortcut");
            //DefaultName = this.GetOptionSettings().DefaultName() ?? $"New{element.TypeReference.Element.Name.ToCSharpIdentifier()}";
            Icon = element.TypeReference.Element.GetStereotypeProperty<IIconModel>("Settings", "Icon");
            Type = CreatableTypeFactory.Create(element.TypeReference.Element);
            //AllowMultiple = element.GetStereotypeProperty("Creation Options", "Allow Multiple", true);
        }

        public string Id => _element.Id;
        public IEnumerable<IStereotype> Stereotypes => _element.Stereotypes;
        public string Name => _element.Name;
        public string TargetSpecializationType { get; }

        public ElementCreationOption ToPersistable()
        {
            return new ElementCreationOption
            {
                Order = this.GetOptionSettings().TypeOrder()?.ToString(),
                Type = GetElementType(),
                SpecializationType = this.TargetSpecializationType,
                Text = this.Name,
                Shortcut = this.GetOptionSettings().Shortcut(),
                DefaultName = this.GetOptionSettings().DefaultName() ?? $"New{_element.TypeReference.Element.Name.ToCSharpIdentifier()}",
                Icon = GetIcon(this.Icon) ?? new IconModelPersistable { Type = IconType.FontAwesome, Source = "file-o" },
                AllowMultiple = this.GetOptionSettings().AllowMultiple()
            };
        }

        public bool CreatesElement()
        {
            return TypeReference.Element.SpecializationType == ElementSettingsModel.SpecializationType;
        }

        public bool CreatesAssociation()
        {
            return TypeReference.Element.SpecializationType == AssociationSettingsModel.SpecializationType;
        }

        private ElementType GetElementType()
        {
            switch (TypeReference.Element.SpecializationType)
            {
                case ElementSettingsModel.SpecializationType:
                    return ElementType.Element;
                case AssociationSettingsModel.SpecializationType:
                    return ElementType.Association;
                case CoreTypeModel.SpecializationType:
                    return ElementType.StereotypeDefinition;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        private IconModelPersistable GetIcon(IIconModel icon)
        {
            return icon != null ? new IconModelPersistable { Type = (IconType)icon.Type, Source = icon.Source } : null;
        }


        public IIconModel Icon { get; }

        public ICreatableType Type { get; }


        [IntentManaged(Mode.Fully)]
        public override string ToString()
        {
            return _element.ToString();
        }


        [IntentManaged(Mode.Fully)]
        public bool Equals(ElementCreationOptionModel other)
        {
            return Equals(_element, other._element);
        }

        [IntentManaged(Mode.Fully)]
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ElementCreationOptionModel)obj);
        }

        [IntentManaged(Mode.Fully)]
        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }

        [IntentManaged(Mode.Fully)]
        public ITypeReference TypeReference => _element.TypeReference;
    }
}