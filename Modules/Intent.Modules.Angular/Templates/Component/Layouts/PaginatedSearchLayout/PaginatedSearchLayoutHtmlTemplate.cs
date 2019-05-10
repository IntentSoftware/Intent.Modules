// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.Angular.Templates.Component.Layouts.PaginatedSearchLayout
{
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Modules.Angular.Api;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules\Modules\Intent.Modules.Angular\Templates\Component\Layouts\PaginatedSearchLayout\PaginatedSearchLayoutHtmlTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class PaginatedSearchLayoutHtmlTemplate : IntentProjectItemTemplateBase<IComponentModel>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(@"<!--IntentManaged-->
<div class=""container"">
  <div class=""row"">
    <div class=""col"">
      <button class=""btn btn-secondary mb-2"" type=""button"" (click)=""createMovie()"">Create New</button>
    </div>
  </div>
  <div *ngIf=""pagination"">
    <div class="""">
      <div class=""row border rounded-top"">
        <div class=""col"">Title</div>
        <div class=""col"">Year</div>
        <div class=""col"">Rating</div>
      </div>
      <div *ngFor=""let item of pagination.items"" class=""row border"">
        <div class=""col"">
          <span>{{item.title}}</span>
        </div>
        <div class=""col"">
          <span>{{item.year}}</span>
        </div>
        <div class=""col"">
          <span>{{item.imdbRating}}</span>
        </div>
      </div>
    </div>
    <div class=""row mt-4"">
      <div class=""col"">
          <ngb-pagination class=""d-flex justify-content-center""
                          [(page)]=""pagination.pageNumber""
                          [pageSize]=""pagination.pageSize""
                          [collectionSize]=""pagination.totalItems""
                          (pageChange)=""changePage()""
                          [maxSize]=""5"" [boundaryLinks]=""false""></ngb-pagination>
        </div>
    </div>

  </div>
</div>
");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
