﻿using Intent.Metadata.Models;

namespace Intent.Modelers.Domain.Api
{
    public interface IAssociationEnd : ITypeReference
    {
        IAssociation Association { get; }

        IClass Class { get; }

        bool IsNavigable { get; }

        string MinMultiplicity { get; }

        string MaxMultiplicity { get; }

        Multiplicity Multiplicity { get; }

        IAssociationEnd OtherEnd();
    }

    public enum Multiplicity
    {
        ZeroToOne,
        One,
        Many
    }
}