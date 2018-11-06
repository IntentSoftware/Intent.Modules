﻿using Intent.SoftwareFactory.Templates;
using Xunit;

namespace Intent.Modules.Common.Tests
{
    public class NormalizeNamespacePathTests
    {
        private static readonly string[] ProjectNames =
        {
            "Solution.Application.ApplicationLayer",
            "Solution.Application.ApplicationLayer.Identity",
            "Solution.Application.Common",
            "Solution.Application.Contracts.Internal",
            "Solution.Application.Distribution.Web",
            "Solution.Application.Domain",
            "Solution.Application.Domain.TestData",
            "Solution.Application.Domain.UnitTests",
            "Solution.Application.Infrastructure.Data",
            "Solution.Application.Infrastructure.Data.EF",
            "Solution.Application.Infrastructure.Data.EF.Migrations",
            "Solution.Application.Presentation.Web",
            "Solution.Common",
            "Solution.Messages",
        };

        [Fact]
        public void Scenario1()
        {
            var result = IntentRoslynProjectItemTemplateBase.NormalizeNamespace(
                localNamespace: "Solution.Application.Contracts.Internal.CompanyDetailsManagement",
                foreignType: "Solution.Common.Types.Country",
                knownOtherPaths: ProjectNames,
                usingPaths: new string[]
                {
                    "System",
                    "System.Collections.Generic",
                    "System.Runtime.Serialization",
                    "Intent.RoslynWeaver.Attributes",
                });

            Assert.Equal("Solution.Common.Types.Country", result);
        }

        [Fact]
        public void Scenario2()
        {
            var result = IntentRoslynProjectItemTemplateBase.NormalizeNamespace(
                localNamespace: "Solution.Application.Contracts.Internal.CompanyDetailsManagement",
                foreignType: "Solution.Common.Types.Country",
                knownOtherPaths: ProjectNames,
                usingPaths: new string[]
                {
                    "System",
                    "System.Collections.Generic",
                    "System.Runtime.Serialization",
                    "Solution.Common.Types",
                    "Intent.RoslynWeaver.Attributes",
                });

            Assert.Equal("Country", result);
        }

        [Fact]
        public void Scenario3()
        {
            var result = IntentRoslynProjectItemTemplateBase.NormalizeNamespace(
                localNamespace: "Solution.Application.ApplicationLayer",
                foreignType: "Solution.Application.Contracts.Internal.CompanyDetailsManagement.StatutoryInfoDTO",
                knownOtherPaths: ProjectNames,
                usingPaths: new string[]
                {
                    "System.Runtime.Serialization",
                    "AutoMapper",
                    "Intent.RoslynWeaver.Attributes",
                });

            Assert.Equal("Contracts.Internal.CompanyDetailsManagement.StatutoryInfoDTO", result);
        }

        [Fact]
        public void Scenario4()
        {
            var result = IntentRoslynProjectItemTemplateBase.NormalizeNamespace(
                localNamespace: "Solution.Application.Contracts.Internal.CompanyDetailsManagement",
                foreignType: "Solution.Application.Common.Enums.CompanyDetails.SocialMediaType",
                knownOtherPaths: ProjectNames,
                usingPaths: new string[]
                {
                });

            Assert.Equal("Common.Enums.CompanyDetails.SocialMediaType", result);
        }
    }
}