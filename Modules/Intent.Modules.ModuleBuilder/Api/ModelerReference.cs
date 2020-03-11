﻿using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modules.Common;

namespace Intent.Modules.ModuleBuilder.Api
{
    internal class ModelerReference : IModelerReference, IEquatable<ModelerReference>
    {
        private readonly IElement _element;
        public const string SpecializationType = "Modeler";

        public ModelerReference(IElement element)
        {
            if (element.SpecializationType != SpecializationType)
            {
                throw new InvalidOperationException($"Cannot load {nameof(Modeler)} from element of type {element.SpecializationType}");
            }

            _element = element;
            Folder = Api.Folder.SpecializationType.Equals(_element.ParentElement?.SpecializationType, StringComparison.OrdinalIgnoreCase) ? new Folder(_element.ParentElement) : null;
            ModelTypes = _element.ChildElements.Where(x => x.SpecializationType == ModelerModelType.RequiredSpecializationType).Select(x => new ModelerModelType(x)).ToList();
        }

        public IEnumerable<IStereotype> Stereotypes => _element.Stereotypes;
        public IFolder Folder { get; }
        public string Id => _element.Id;
        public string Name => _element.Name;
        public IEnumerable<IModelerModelType> ModelTypes { get; }
        public string ApiNamespace => _element.GetStereotypeProperty<string>("Modeler Settings", "API Namespace");
        public string ModuleDependency => _element.GetStereotypeProperty<string>("Modeler Settings", "Module Dependency");
        public string ModuleVersion => _element.GetStereotypeProperty<string>("Modeler Settings", "Module Version");
        public string NuGetDependency => _element.GetStereotypeProperty<string>("Modeler Settings", "NuGet Dependency");
        public string NuGetVersion => _element.GetStereotypeProperty<string>("Modeler Settings", "NuGet Version");

        public bool Equals(ModelerReference other)
        {
            return string.Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ModelerReference) obj);
        }

        public override int GetHashCode()
        {
            return (Id != null ? Id.GetHashCode() : 0);
        }
    }
}