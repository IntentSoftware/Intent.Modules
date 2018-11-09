﻿using Intent.SoftwareFactory.Engine;
using Intent.SoftwareFactory.Registrations;
using System;
using Intent.Modules.Entities.Templates.DomainEntityState;

namespace Intent.Modules.Entities.Decorators
{
    public class VisitableDomainEntityStateDecoratorRegistration : DecoratorRegistration<DomainEntityStateDecoratorBase>
    {
        public override string DecoratorId => VisitableDomainEntityStateDecorator.Identifier;

        public override object CreateDecoratorInstance(IApplication application)
        {
            return new VisitableDomainEntityStateDecorator();
        }
    }
}