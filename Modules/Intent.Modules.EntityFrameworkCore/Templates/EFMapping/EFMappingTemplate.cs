﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.EntityFrameworkCore.Templates.EFMapping
{
    using Intent.MetaModel.Domain;
    using Intent.SoftwareFactory.Templates;
    using Intent.SoftwareFactory.MetaData;
    using System;
    using System.IO;
    using System.Diagnostics;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class EFMappingTemplate : IntentRoslynProjectItemTemplateBase<IClass>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(" \r\n\r\n");
            
            #line 15 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
//Some initial validation
    foreach (var associationEnd in Model.AssociatedClasses)
    {
        var association = associationEnd.Association;
 
        //if there is more than 1 parent association && there are any which are not 0..1->1 (this is a manual inheritance mapping)
        var multipleCompositions = Model.AssociatedClasses.Where(ae => ae.Association.AssociationType == AssociationType.Composition && ae.Association.TargetEnd.Class == Model);
        if (multipleCompositions.Count() > 1)
        {
            throw new Exception(string.Format("Unsupported Mapping - {0} each have a Compositional relationship with {1}.", multipleCompositions.Select(x => x.Class.Name).Aggregate((x, y) => x + ", " + y), Model.Name));
        }

        if (!association.TargetEnd.IsNavigable)
        {
            throw new Exception(string.Format("Unsupported Source Needs to be Navigable to Target relationship  {0} on {1} ", association.ToString(), association.TargetEnd.Class.Name));
        }

        //Unsupported Associations
        if ((association.AssociationType == AssociationType.Aggregation ) && ( association.RelationshipString() == "1->0..1"))
        {
            throw new Exception(string.Format("Unsupported Aggregation relationship  {0} - this relationship implies composition", association.ToString()));
        }
        if ((association.AssociationType == AssociationType.Aggregation ) && ( association.RelationshipString() == "1->1"))
        {
            throw new Exception(string.Format("Unsupported Aggregation relationship  {0} - this relationship implies composition", association.ToString()));
        }
        if ((association.AssociationType == AssociationType.Aggregation ) && ( association.RelationshipString() == "1->*"))
        {
            throw new Exception(string.Format("Unsupported Aggregation relationship {0}, this relationship implies Composition", association.ToString()));
        }
        if ((association.AssociationType == AssociationType.Composition ) && ( association.RelationshipString() == "0..1->0..1"))
        {
            throw new Exception(string.Format("Unsupported Composition relationship {0}", association.ToString()));
        }
        if ((association.AssociationType == AssociationType.Composition ) && ( association.RelationshipString() == "0..1->*"))
        {
            throw new Exception(string.Format("Unsupported Composition relationship {0}, this relationship implies aggregation", association.ToString()));
        }
        if ((association.AssociationType == AssociationType.Composition ) && ( association.RelationshipString().StartsWith("*->")))
        {
            throw new Exception(string.Format("Unsupported Composition relationship {0}, this relationship implies aggregation", association.ToString()));
        }
        //Naviagability Requirement
        if ((association.AssociationType == AssociationType.Composition ) && ( association.RelationshipString() == "0..1->1") && (!association.SourceEnd.IsNavigable))
        {
            throw new Exception(string.Format("Unsupported. IsNavigable from Composition Required for Composition relationship {0}", association.ToString()));
        }
    }


            
            #line default
            #line hidden
            this.Write("using System;\r\nusing Microsoft.EntityFrameworkCore;\r\nusing Microsoft.EntityFramew" +
                    "orkCore.Metadata.Builders;\r\n");
            
            #line 68 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DependencyUsings));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 72 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public class ");
            
            #line 74 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" : IEntityTypeConfiguration<");
            
            #line 74 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityStateName));
            
            #line default
            #line hidden
            this.Write(">\r\n    {\r\n        public void Configure(EntityTypeBuilder<");
            
            #line 76 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityStateName));
            
            #line default
            #line hidden
            this.Write("> builder)\r\n        {\r\n");
            
            #line 78 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
  if (Model.ParentClass == null)
    {
            
            #line default
            #line hidden
            this.Write("            builder.ToTable(\"");
            
            #line 80 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("\");\r\n");
            
            #line 81 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
  }
    if (ImplicitSurrogateKey && Model.ParentClass == null) {
            
            #line default
            #line hidden
            this.Write("            builder.HasKey(x => x.Id);\r\n            builder.Property(x => x.Id).H" +
                    "asColumnName(\"Id\");\r\n");
            
            #line 85 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
  }
    if (Model.ParentClass != null) {
            
            #line default
            #line hidden
            this.Write("            builder.HasBaseType<");
            
            #line 87 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.ParentClass.Name));
            
            #line default
            #line hidden
            this.Write(">();\r\n");
            
            #line 88 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
  }  
    foreach (var attribute in Model.Attributes)
    {
        if (attribute.Name.ToLower() == "id")
        {
            if (ImplicitSurrogateKey) {
                throw new Exception(string.Format("Surrogate Key is implicit for class {0}. Either remove the 'id' attribute, or disable the 'Implicit Surrogate Key' option for this template", Model.Name));
            }
            
            #line default
            #line hidden
            this.Write("            builder.HasKey(x => x.Id);\r\n");
            
            #line 97 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
	    }
            
            #line default
            #line hidden
            
            #line 98 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
		var indexStereotype = attribute.GetStereotype("Index");
        if(indexStereotype != null)
        { 
            
            #line default
            #line hidden
            this.Write("            builder.HasIndex(x => x.");
            
            #line 101 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(attribute.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write(")\r\n                .IsUnique(unique: ");
            
            #line 102 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(indexStereotype.GetProperty("IsUnique", "false")));
            
            #line default
            #line hidden
            this.Write(")\r\n");
            
            #line 103 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
			
            var uniqueKey = indexStereotype.GetProperty("UniqueKey", string.Empty);
            if(!string.IsNullOrEmpty(uniqueKey))
            { 
            
            #line default
            #line hidden
            this.Write("                .HasName(\"");
            
            #line 107 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(uniqueKey));
            
            #line default
            #line hidden
            this.Write("\")\r\n");
            
            #line 108 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
			} 
            
            #line default
            #line hidden
            this.Write("                ;\r\n");
            
            #line 110 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
      } 
            
            #line default
            #line hidden
            this.Write("            builder.Property(x => x.");
            
            #line 111 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(attribute.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write(")");
            
            #line 111 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"


        if (!attribute.IsNullable){
            
            #line default
            #line hidden
            this.Write("\r\n                .IsRequired()");
            
            #line 115 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"

        }

        if (attribute.Type.Name == "string" )
        {
            var maxLength = attribute.GetStereotypeProperty<int?>("Text", "MaxLength");    
            if (maxLength.HasValue){
        
            
            #line default
            #line hidden
            this.Write("\r\n                .HasMaxLength(");
            
            #line 124 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(maxLength.Value));
            
            #line default
            #line hidden
            this.Write(")");
            
            #line 124 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"

            }
        }

        var decimalPrecision = attribute.GetStereotypeProperty<int?>("Numeric", "Precision");
        var decimalScale = attribute.GetStereotypeProperty<int?>("Numeric", "Scale");
        if (decimalPrecision.HasValue && decimalScale.HasValue){
            
            #line default
            #line hidden
            this.Write("\r\n                .HasPrecision(");
            
            #line 132 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(decimalPrecision));
            
            #line default
            #line hidden
            this.Write(", ");
            
            #line 132 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(decimalScale));
            
            #line default
            #line hidden
            this.Write(")");
            
            #line 132 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"

        }

        if (HasTypeOverride(attribute))
        { 
            
            #line default
            #line hidden
            this.Write("                .HasColumnType(\"");
            
            #line 137 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetTypeOverride(attribute)));
            
            #line default
            #line hidden
            this.Write("\")\r\n");
            
            #line 138 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
      } 
            
            #line default
            #line hidden
            this.Write("                ;\r\n\r\n");
            
            #line 141 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
  }
            
            #line default
            #line hidden
            
            #line 142 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
    foreach (var associationEnd in Model.AssociatedClasses)
    {

        if (associationEnd != associationEnd.Association.TargetEnd)
        {
            continue;
        }

        switch (associationEnd.Relationship())
        {
            case RelationshipType.OneToOne :
            
            #line default
            #line hidden
            this.Write("            builder.HasOne(x => x.");
            
            #line 153 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(associationEnd.Name().ToPascalCase()));
            
            #line default
            #line hidden
            this.Write(")\r\n                .WithOne(");
            
            #line 154 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(associationEnd.OtherEnd().IsNavigable ? "x => x." + associationEnd.OtherEnd().Name().ToPascalCase() : ""));
            
            #line default
            #line hidden
            this.Write(")\r\n");
            
            #line 155 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
				if (associationEnd.OtherEnd().MinMultiplicity != "0") { 
            
            #line default
            #line hidden
            this.Write("                .HasForeignKey<");
            
            #line 156 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write(">(x => x.Id)\r\n                .IsRequired()\r\n                .OnDelete(DeleteBeha" +
                    "vior.Cascade)\r\n");
            
            #line 159 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
				} else {
            
            #line default
            #line hidden
            this.Write("                .HasForeignKey<");
            
            #line 160 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write(">(x => x.");
            
            #line 160 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(associationEnd.Name().ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Id)\r\n                .OnDelete(DeleteBehavior.Restrict)\r\n");
            
            #line 162 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
              } 
            
            #line default
            #line hidden
            this.Write("                ;\r\n\r\n");
            
            #line 165 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
              break;
            case RelationshipType.OneToMany :
            
            #line default
            #line hidden
            this.Write("            builder.HasOne(x => x.");
            
            #line 167 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(associationEnd.Name().ToPascalCase()));
            
            #line default
            #line hidden
            this.Write(")\r\n                .WithMany(");
            
            #line 168 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(associationEnd.OtherEnd().IsNavigable ? "x => x." + associationEnd.OtherEnd().Name().ToPascalCase() : ""));
            
            #line default
            #line hidden
            this.Write(")\r\n");
            
            #line 169 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
				if (UseForeignKeys) { 
            
            #line default
            #line hidden
            this.Write("                .HasForeignKey(x => x.");
            
            #line 170 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(associationEnd.Name().ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Id)\r\n");
            
            #line 171 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
				} else { 
            
            #line default
            #line hidden
            this.Write("                .HasForeignKey(\"");
            
            #line 172 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(associationEnd.Name().ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Id\"))\r\n");
            
            #line 173 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
				} 
            
            #line default
            #line hidden
            this.Write("                ;\r\n\r\n");
            
            #line 176 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
                  break;
            case RelationshipType.ManyToOne :
            
            #line default
            #line hidden
            this.Write("            builder.HasMany(x => x.");
            
            #line 178 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(associationEnd.Name().ToPascalCase()));
            
            #line default
            #line hidden
            this.Write(")\r\n                .WithOne(x => x.");
            
            #line 179 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(associationEnd.OtherEnd().Name().ToPascalCase()));
            
            #line default
            #line hidden
            this.Write(")\r\n");
            
            #line 180 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
				if (UseForeignKeys) { 
            
            #line default
            #line hidden
            this.Write("                .HasForeignKey(x => x.");
            
            #line 181 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(associationEnd.OtherEnd().Name().ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Id)\r\n");
            
            #line 182 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
				} else { 
            
            #line default
            #line hidden
            this.Write("                .Map(m => m.MapKey(\"");
            
            #line 183 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(associationEnd.OtherEnd().Name().ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Id\"))\r\n");
            
            #line 184 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
				} 
            
            #line default
            #line hidden
            
            #line 185 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
				if (associationEnd.OtherEnd().MinMultiplicity != "0") { 
            
            #line default
            #line hidden
            this.Write("                .IsRequired()\r\n                .OnDelete(DeleteBehavior.Cascade)\r" +
                    "\n");
            
            #line 188 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
				}
            
            #line default
            #line hidden
            this.Write("                ;\r\n\r\n");
            
            #line 191 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
                  break;
            case RelationshipType.ManyToMany :
            
            #line default
            #line hidden
            this.Write("            builder.Ignore(x => x.");
            
            #line 193 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(associationEnd.Name().ToPascalCase()));
            
            #line default
            #line hidden
            this.Write(")\r\n                ");
            
            #line 194 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
 IssueManyToManyWarning(associationEnd); 
            
            #line default
            #line hidden
            this.Write("                ;\r\n\r\n");
            
            #line 197 "D:\Projects\IntentModules\Modules\Intent.Modules.EntityFrameworkCore\Templates\EFMapping\EFMappingTemplate.tt"
                  break;
        }       
    }

            
            #line default
            #line hidden
            this.Write("        }\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
