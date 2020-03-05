﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Intent.IArchitect.Agent.Persistence.Model.Common
{
    public class ModelerSettings
    {
        [XmlElement("diagramSettings")]
        public DiagramSettings DiagramSettings { get; set; }

        [XmlElement("packageSettings")]
        public PackageSettings PackageSettings { get; set; }

        [XmlArray("elementSettings")]
        [XmlArrayItem("elementSetting")]
        public List<ElementSettings> ElementSettings { get; set; }

        [XmlArray("associationSettings")]
        [XmlArrayItem("associationSetting")]
        public List<AssociationSettings> AssociationSettings { get; set; }

        [XmlElement("stereotypeSettings")]
        public StereotypeSettings StereotypeSettings { get; set; }
    }

    public class StereotypeSettings
    {
        [XmlArray("targetTypeOptions")]
        [XmlArrayItem("option")]
        public List<StereotypeTargetTypeOption> TargetTypeOptions { get; set; }
    }

    public class StereotypeTargetTypeOption
    {
        [XmlAttribute("specializationType")]
        public string SpecializationType { get; set; }

        [XmlAttribute("displayText")]
        public string DisplayText { get; set; }

        public override string ToString()
        {
            return $"{nameof(SpecializationType)} = '{SpecializationType}', " +
                   $"{nameof(DisplayText)} = '{DisplayText}'";
        }
    }

    public class ElementSettings
    {
        private string _specializationType;
        private List<TypeOrder> _typeOrder;

        [XmlAttribute("type")]
        public string SpecializationType
        {
            get => _specializationType ?? SpecializationTypeOld;
            set => _specializationType = value;
        }

        [XmlElement("specializationType")]
        public string SpecializationTypeOld { get; set; }

        [XmlElement("icon")]
        public IconModel Icon { get; set; }

        [XmlElement("expandedIcon")]
        public IconModel ExpandedIcon { get; set; }

        [XmlElement("allowRename")]
        public bool? AllowRename { get; set; } = true;

        [XmlElement("allowAbstract")]
        public bool? AllowAbstract { get; set; }

        [XmlElement("allowGenericTypes")]
        public bool? AllowGenericTypes { get; set; }

        [XmlElement("allowMapping")]
        public bool? AllowMapping { get; set; }

        [XmlElement("allowSorting")]
        public bool? AllowSorting { get; set; }

        [XmlElement("allowFindInView")]
        public bool? AllowFindInView { get; set; }

        [XmlArray("typeOrder")]
        [XmlArrayItem("type", typeof(TypeOrder))]
        public List<TypeOrder> TypeOrder
        {
            get => _typeOrder;
            set
            {
                _typeOrder = value;
                if (_typeOrder == null)
                {
                    return;
                }
                for (int i = 0; i < _typeOrder.Count; i++)
                {
                    if (_typeOrder[i].Order == default(int))
                    {
                        _typeOrder[i].Order = i;
                    }
                }

                _typeOrder = _typeOrder.OrderBy(x => x.Order).ToList();
            }
        }

        [XmlElement("diagramSettings")]
        public DiagramSettings DiagramSettings { get; set; }

        [XmlArray("literalSettings")]
        [XmlArrayItem("literalSetting")]
        public ClassLiteralSettings[] LiteralSettings { get; set; }

        [XmlArray("attributeSettings")]
        [XmlArrayItem("attributeSetting")]
        public AttributeSettings[] AttributeSettings { get; set; }

        [XmlArray("operationSettings")]
        [XmlArrayItem("operationSetting")]
        public OperationSettings[] OperationSettings { get; set; }

        [XmlElement("mappingSettings")]
        public ElementMappingSettings MappingSettings { get; set; }

        [XmlArray("creationOptions")]
        [XmlArrayItem("option")]
        public List<ElementCreationOption> CreationOptions { get; set; }

        public override string ToString()
        {
            return $"{nameof(SpecializationType)} = '{SpecializationType}'";
        }
    }

    public class TypeOrder
    {
        [XmlText]
        public string Type { get; set; }

        [XmlAttribute("order")]
        public int Order { get; set; }
    }

    public class AttributeSettings
    {
        [XmlElement("specializationType")]
        public string SpecializationType { get; set; }

        [XmlElement("icon")]
        public IconModel Icon { get; set; }

        [XmlElement("text")]
        public string Text { get; set; }

        [XmlElement("shortcut")]
        public string Shortcut { get; set; }

        [XmlElement("displayFunction")]
        public string DisplayFunction { get; set; }

        [XmlElement("defaultName")]
        public string DefaultName { get; set; }

        [XmlElement("allowRename")]
        public bool? AllowRename { get; set; } = true;

        [XmlElement("allowDuplicateNames")]
        public bool? AllowDuplicateNames { get; set; }

        [XmlElement("allowFindInView")]
        public bool? AllowFindInView { get; set; }

        [XmlElement("defaultTypeId")]
        public string DefaultTypeId { get; set; }

        [XmlArray("targetTypes")]
        [XmlArrayItem("type")]
        public string[] TargetTypes { get; set; }

        public override string ToString()
        {
            return $"{nameof(SpecializationType)} = '{SpecializationType}', " +
                   $"{nameof(Text)} = '{Text}'";
        }
    }

    public class ClassLiteralSettings
    {
        [XmlElement("specializationType")]
        public string SpecializationType { get; set; }

        [XmlElement("icon")]
        public IconModel Icon { get; set; }

        [XmlElement("text")]
        public string Text { get; set; }

        [XmlElement("shortcut")]
        public string Shortcut { get; set; }

        [XmlElement("defaultName")]
        public string DefaultName { get; set; }

        [XmlElement("allowRename")]
        public bool? AllowRename { get; set; } = true;

        [XmlElement("allowDuplicateNames")]
        public bool? AllowDuplicateNames { get; set; }

        [XmlElement("allowFindInView")]
        public bool? AllowFindInView { get; set; }

        public override string ToString()
        {
            return $"{nameof(SpecializationType)} = '{SpecializationType}', " +
                   $"{nameof(Text)} = '{Text}'";
        }
    }

    public class OperationSettings
    {
        [XmlElement("specializationType")]
        public string SpecializationType { get; set; }

        [XmlElement("icon")]
        public IconModel Icon { get; set; }

        [XmlElement("text")]
        public string Text { get; set; }

        [XmlElement("shortcut")]
        public string Shortcut { get; set; }

        [XmlElement("defaultName")]
        public string DefaultName { get; set; }

        [XmlElement("allowRename")]
        public bool? AllowRename { get; set; } = true;

        [XmlElement("allowDuplicateNames")]
        public bool? AllowDuplicateNames { get; set; }

        [XmlElement("allowFindInView")]
        public bool? AllowFindInView { get; set; }

        [XmlElement("defaultTypeId")]
        public string DefaultTypeId { get; set; }

        [XmlArray("targetTypes")]
        [XmlArrayItem("type")]
        public string[] TargetTypes { get; set; }

        public override string ToString()
        {
            return $"{nameof(SpecializationType)} = '{SpecializationType}', " +
                   $"{nameof(Text)} = '{Text}'";
        }
    }

    public class PackageSettings
    {
        private List<TypeOrder> _typeOrder;

        [XmlArray("creationOptions")]
        [XmlArrayItem("option")]
        public List<ElementCreationOption> CreationOptions { get; set; }

        [XmlArray("typeOrder")]
        [XmlArrayItem("type")]
        public List<TypeOrder> TypeOrder
        {
            get => _typeOrder;
            set
            {
                _typeOrder = value;
                if (_typeOrder == null)
                {
                    return;
                }
                for (int i = 0; i < _typeOrder.Count; i++)
                {
                    if (_typeOrder[i].Order == default(int))
                    {
                        _typeOrder[i].Order = i;
                    }
                }

                _typeOrder = _typeOrder.OrderBy(x => x.Order).ToList();
            }
        }
    }

    public class ElementMappingSettings
    {
        [XmlElement("defaultModeler")]
        public string DefaultModeler { get; set; }

        [XmlElement("inheritanceAssociationType")]
        public string InheritanceAssociationType { get; set; }

        [XmlArray("specializationTypes")]
        [XmlArrayItem("type")]
        public string[] SpecializationTypes { get; set; }
    }

    public class ElementCreationOption
    {
        [XmlElement("specializationType")]
        public string SpecializationType { get; set; }

        [XmlElement("text")]
        public string Text { get; set; }

        [XmlElement("shortcut")]
        public string Shortcut { get; set; }

        [XmlElement("defaultName")]
        public string DefaultName { get; set; }

        [XmlElement("icon")]
        public IconModel Icon { get; set; }

        public override string ToString()
        {
            return $"{nameof(SpecializationType)} = '{SpecializationType}', " +
                   $"{nameof(Text)} = '{Text}'";
        }
    }

    public enum ElementType
    {
        Unknown = 0,
        Class = 1,
        Literal = 2,
        Attribute = 3,
        Operation = 4,
        Association = 5,
        StereotypeDefinition = 6,
        Folder = 7
    }
}