﻿using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;

namespace Intent.Modules.Common
{
    public static class StereotypeExtensions
    {
        [Obsolete("Use GetStereotypeProperty")]
        public static T GetPropertyValue<T>(this IHasStereotypes model, string stereotypeName, string propertyName, T defaultIfNotFound = default(T))
        {
            return model.GetStereotypeProperty(stereotypeName, propertyName, defaultIfNotFound);
        }

        public static T GetStereotypeProperty<T>(this IHasStereotypes model, string stereotypeName, string propertyName, T defaultIfNotFound = default(T))
        {
            try
            {
                return model.GetStereotype(stereotypeName).GetProperty(propertyName, defaultIfNotFound);
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to get stereotype property for element [{model}]", e);
            }
        }

        /// <summary>
        /// Lookup only one stereotype with a given name. If more than one is found with the same name, it fails.
        /// </summary>
        public static IStereotype GetStereotype(this IHasStereotypes model, string stereotypeName)
        {
            var stereotypes = model.Stereotypes.Where(x => x.Name == stereotypeName).ToArray();
            if (stereotypes.Length > 1)
            {
                throw new Exception(model is IMetadataModel metadataModel
                    ? $"More than one stereotype found with the name '{stereotypeName}' on element with ID {metadataModel.Id}"
                    : $"More than one stereotype found with the name '{stereotypeName}'");
            }

            return stereotypes.SingleOrDefault();
        }

        /// <summary>
        /// Look up multiple stereotypes by the same name.
        /// </summary>
        public static IReadOnlyCollection<IStereotype> GetStereotypes(this IHasStereotypes model, string stereotypeName)
        {
            return model.Stereotypes.Where(p => p.Name == stereotypeName).ToArray();
        }

        public static T GetProperty<T>(this IStereotype stereotype, string propertyName, T defaultIfNotFound = default(T))
        {
            if (stereotype == null)
            {
                return defaultIfNotFound;
            }
            foreach (var property in stereotype.Properties)
            {
                if (property.Key != propertyName || string.IsNullOrWhiteSpace(property.Value)) continue;

                if (Nullable.GetUnderlyingType(typeof(T)) != null) // is nullable type
                {
                    return (T)Convert.ChangeType(property.Value, Nullable.GetUnderlyingType(typeof(T)));
                }

                if (property is IStereotypeProperty<T> stereotypeProperty)
                {
                    return stereotypeProperty.Value;
                }
                return (T)Convert.ChangeType(property.Value, typeof(T));
            }
            return defaultIfNotFound;
        }

        public static bool HasStereotype(this IHasStereotypes model, string stereotypeName)
        {
            return model.Stereotypes.Any(x => x.Name == stereotypeName);
        }
    }

    //public static class CommonExtensions
    //{
    //    public static string ToPascalCase(this string s)
    //    {
    //        if (string.IsNullOrWhiteSpace(s))
    //        {
    //            return s;
    //        }
    //        if (Char.IsUpper(s[0]))
    //        {
    //            return s;
    //        }
    //        else
    //        {
    //            return Char.ToUpper(s[0]) + s.Substring(1);
    //        }
    //    }

    //    public static string ToCamelCase(this string s)
    //    {
    //        return s.ToCamelCase(true);
    //    }

    //    public static string ToCamelCase(this string s, bool reservedWordEscape)
    //    {
    //        if (string.IsNullOrWhiteSpace(s))
    //        {
    //            return s;
    //        }
    //        string result;
    //        if (Char.IsLower(s[0]))
    //        {
    //            result = s;
    //        }
    //        else
    //        {
    //            result = Char.ToLower(s[0]) + s.Substring(1);
    //        }

    //        if (reservedWordEscape)
    //        {
    //            switch (result)
    //            {
    //                case "class":
    //                case "namespace":
    //                    return "@" + result;
    //            }
    //        }
    //        return result;
    //    }

    //    public static string ToPrivateMember(this string s)
    //    {
    //        if (string.IsNullOrWhiteSpace(s))
    //        {
    //            return s;
    //        }
    //        return "_" + ToCamelCase(s, false);
    //    }
    //}
}
