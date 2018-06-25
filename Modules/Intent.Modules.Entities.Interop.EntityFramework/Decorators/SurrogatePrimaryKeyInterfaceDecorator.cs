﻿using System;
using System.Collections.Generic;
using Intent.MetaModel.Domain;
using Intent.Modules.Entities.Interop.EntityFramework.Templates.IdentityGenerator;
using Intent.Modules.Entities.Templates.DomainEntity;
using Intent.SoftwareFactory.Configuration;
using Intent.Modules.Entities.Templates;
using Intent.Modules.Entities.Templates.DomainEntityInterface;
using Intent.Modules.Entities.Templates.DomainEntityState;
using Intent.SoftwareFactory.Templates;

namespace Intent.Modules.Entities.Interop.EntityFramework.Decorators
{
    public class SurrogatePrimaryKeyInterfaceDecorator : DomainEntityInterfaceDecoratorBase
    {
        private string _surrogateKeyType = "Guid";
        public const string Identifier = "Intent.Entities.Interop.EntityFramework.SurrogatePrimaryKeyInterfaceDecorator";
        public string SurrogateKeyType => "Surrogate Key Type";

        public override string BeforeProperties(IClass @class)
        {
            if (@class.ParentClass != null)
            {
                return base.BeforeProperties(@class);
            }

            return $@"
        /// <summary>
        /// Get the persistent object's identifier
        /// </summary>
        {_surrogateKeyType} Id {{ get; }}";
        }

        public override void Configure(IDictionary<string, string> settings)
        {
            base.Configure(settings);
            if (settings.ContainsKey(SurrogateKeyType) && !string.IsNullOrWhiteSpace(settings[SurrogateKeyType]))
            {
                _surrogateKeyType = settings[SurrogateKeyType];
            }
        }

    }
}