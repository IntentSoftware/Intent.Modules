using System;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("ModuleBuilder.Templates.Api.ApiModelExtensions", Version = "1.0")]

namespace Intent.Modules.ModuleBuilder.Api
{
    public static class ElementSettingsExtensions
    {
        public static DefaultCreationOptions GetDefaultCreationOptions(this ElementSettingsModel model)
        {
            var stereotype = model.GetStereotype("Default Creation Options");
            return stereotype != null ? new DefaultCreationOptions(stereotype) : null;
        }

        public static IconFull GetIconFull(this ElementSettingsModel model)
        {
            var stereotype = model.GetStereotype("Icon (Full)");
            return stereotype != null ? new IconFull(stereotype) : null;
        }

        public static IconFullExpanded GetIconFullExpanded(this ElementSettingsModel model)
        {
            var stereotype = model.GetStereotype("Icon (Full, Expanded)");
            return stereotype != null ? new IconFullExpanded(stereotype) : null;
        }

        public static Settings GetSettings(this ElementSettingsModel model)
        {
            var stereotype = model.GetStereotype("Settings");
            return stereotype != null ? new Settings(stereotype) : null;
        }

        public static TypeReferenceSettings GetTypeReferenceSettings(this ElementSettingsModel model)
        {
            var stereotype = model.GetStereotype("Type Reference Settings");
            return stereotype != null ? new TypeReferenceSettings(stereotype) : null;
        }


        public class DefaultCreationOptions
        {
            private IStereotype _stereotype;

            public DefaultCreationOptions(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Shortcut()
            {
                return _stereotype.GetProperty<string>("Shortcut");
            }

            public string DefaultName()
            {
                return _stereotype.GetProperty<string>("Default Name");
            }

            public int? TypeOrder()
            {
                return _stereotype.GetProperty<int?>("Type Order");
            }

        }

        public class IconFull
        {
            private IStereotype _stereotype;

            public IconFull(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public TypeOptions Type()
            {
                return new TypeOptions(_stereotype.GetProperty<string>("Type"));
            }

            public string Source()
            {
                return _stereotype.GetProperty<string>("Source");
            }

            public class TypeOptions
            {
                public readonly string Value;

                public TypeOptions(string value)
                {
                    Value = value;
                }

                public bool IsUrlImagePath()
                {
                    return Value == "UrlImagePath";
                }
                public bool IsRelativeImagePath()
                {
                    return Value == "RelativeImagePath";
                }
                public bool IsFontAwesome()
                {
                    return Value == "FontAwesome";
                }
                public bool IsCharacterBox()
                {
                    return Value == "CharacterBox";
                }
                public bool IsInternal()
                {
                    return Value == "Internal";
                }
            }

        }

        public class IconFullExpanded
        {
            private IStereotype _stereotype;

            public IconFullExpanded(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public TypeOptions Type()
            {
                return new TypeOptions(_stereotype.GetProperty<string>("Type"));
            }

            public string Source()
            {
                return _stereotype.GetProperty<string>("Source");
            }

            public class TypeOptions
            {
                public readonly string Value;

                public TypeOptions(string value)
                {
                    Value = value;
                }

                public bool IsUrlImagePath()
                {
                    return Value == "UrlImagePath";
                }
                public bool IsRelativeImagePath()
                {
                    return Value == "RelativeImagePath";
                }
                public bool IsFontAwesome()
                {
                    return Value == "FontAwesome";
                }
                public bool IsCharacterBox()
                {
                    return Value == "CharacterBox";
                }
                public bool IsInternal()
                {
                    return Value == "Internal";
                }
            }

        }

        public class Settings
        {
            private IStereotype _stereotype;

            public Settings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public SaveModeOptions SaveMode()
            {
                return new SaveModeOptions(_stereotype.GetProperty<string>("Save Mode"));
            }

            public string DisplayTextFunction()
            {
                return _stereotype.GetProperty<string>("Display Text Function");
            }

            public bool AllowRename()
            {
                return _stereotype.GetProperty<bool>("Allow Rename");
            }

            public bool AllowAbstract()
            {
                return _stereotype.GetProperty<bool>("Allow Abstract");
            }

            public bool AllowGenericTypes()
            {
                return _stereotype.GetProperty<bool>("Allow Generic Types");
            }

            public bool AllowMapping()
            {
                return _stereotype.GetProperty<bool>("Allow Mapping");
            }

            public bool AllowSorting()
            {
                return _stereotype.GetProperty<bool>("Allow Sorting");
            }

            public bool AllowFindInView()
            {
                return _stereotype.GetProperty<bool>("Allow Find in View");
            }

            public class SaveModeOptions
            {
                public readonly string Value;

                public SaveModeOptions(string value)
                {
                    Value = value;
                }

                public bool IsOwnFile()
                {
                    return Value == "Own File";
                }
                public bool IsAsChild()
                {
                    return Value == "As Child";
                }
            }

        }

        public class TypeReferenceSettings
        {
            private IStereotype _stereotype;

            public TypeReferenceSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public ModeOptions Mode()
            {
                return new ModeOptions(_stereotype.GetProperty<string>("Mode"));
            }

            public IElement[] TargetTypes()
            {
                return _stereotype.GetProperty<IElement[]>("Target Types");
            }

            public RepresentsOptions Represents()
            {
                return new RepresentsOptions(_stereotype.GetProperty<string>("Represents"));
            }

            public string DefaultTypeId()
            {
                return _stereotype.GetProperty<string>("Default Type Id");
            }

            public bool AllowNullable()
            {
                return _stereotype.GetProperty<bool>("Allow Nullable");
            }

            public bool AllowCollection()
            {
                return _stereotype.GetProperty<bool>("Allow Collection");
            }

            public class ModeOptions
            {
                public readonly string Value;

                public ModeOptions(string value)
                {
                    Value = value;
                }

                public bool IsDisabled()
                {
                    return Value == "Disabled";
                }
                public bool IsOptional()
                {
                    return Value == "Optional";
                }
                public bool IsRequired()
                {
                    return Value == "Required";
                }
            }

            public class RepresentsOptions
            {
                public readonly string Value;

                public RepresentsOptions(string value)
                {
                    Value = value;
                }

                public bool IsReference()
                {
                    return Value == "Reference";
                }
                public bool IsInheritance()
                {
                    return Value == "Inheritance";
                }
            }

        }

    }
}