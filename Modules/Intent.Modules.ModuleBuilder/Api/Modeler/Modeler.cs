﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intent.IArchitect.Common.Types;
using Intent.Metadata.Models;
using Intent.Modules.Common;

namespace Intent.Modules.ModuleBuilder.Api.Modeler
{
    public class Modeler
    {
        public const string RequiredSpecializationType = "Modeler";

        public Modeler(IElement element)
        {
            if (element.SpecializationType != RequiredSpecializationType)
            {
                throw new ArgumentException($"Invalid element [{element}]");
            }

            Name = element.Name;
            PackageSettings = new PackageSettings(element.ChildElements.SingleOrDefault(x => x.SpecializationType == PackageSettings.SpecializationType));
            ElementSettings = element.ChildElements.Where(x => x.SpecializationType == ElementSetting.RequiredSpecializationType).Select(x => new ElementSetting(x)).ToList();
            AssociationSettings = element.ChildElements.Where(x => x.SpecializationType == AssociationSetting.RequiredSpecializationType).Select(x => new ElementSetting(x)).ToList();
        }

        public PackageSettings PackageSettings { get; }
        public IList<ElementSetting> ElementSettings { get; }
        public IList<AssociationSetting> AssociationSettings { get; }
        public string Name { get; }
    }

    public class TypeOrder
    {
        public int? Order { get; set; }
        public string Type { get; set; }
    }

    public class IconModel
    {
        public IconModel(IStereotype stereotype)
        {
            Type = (IconType) Enum.Parse(typeof(IconType), stereotype.GetProperty<string>("Type"));
            Source = stereotype.GetProperty<string>("Source");
        }

        public IconType Type { get; set; }
        public string Source { get; set; }
    }

    public class AssociationSetting
    {
        public const string RequiredSpecializationType = "Association Setting";

        public AssociationSetting(IElement element)
        {
            if (element.SpecializationType != RequiredSpecializationType)
            {
                throw new ArgumentException($"Invalid element [{element}]");
            }

            SpecializationType = element.Name;
            Icon = new IconModel(element.GetStereotype("Icon (Full)"));
        }

        public string SpecializationType { get; set; }

        public IconModel Icon { get; set; }

        public AssociationEndSetting SourceEnd { get; set; }

        public AssociationEndSetting TargetEnd { get; set; }

        public override string ToString()
        {
            return $"{nameof(SpecializationType)} = '{SpecializationType}'";
        }
    }

    public class AssociationEndSetting
    {
        public string[] TargetTypes { get; set; }

        public bool? IsNavigableEnabled { get; set; }

        public bool? IsNullableEnabled { get; set; }

        public bool? IsCollectionEnabled { get; set; }

        public bool? IsNavigableDefault { get; set; }

        public bool? IsNullableDefault { get; set; }

        public bool? IsCollectionDefault { get; set; }
    }

    public class OperationSetting
    {

    }
}