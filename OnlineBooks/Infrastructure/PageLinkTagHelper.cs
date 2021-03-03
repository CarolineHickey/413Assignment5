using System;
using Microsoft.AspNetCore.Mvc.Rendering; //added
using Microsoft.AspNetCore.Mvc.Routing; //added
using Microsoft.AspNetCore.Razor.TagHelpers; //added
using System.Threading.Tasks; //added
using OnlineBooks.Models.ViewModels; //added
using Microsoft.AspNetCore.Mvc; //added
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic; //added

namespace OnlineBooks.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]

    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        public PageLinkTagHelper (IUrlHelperFactory hp) //constructor
        {
            urlHelperFactory = hp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public PagingInfo PageModel { get; set; }

        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]

        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();


        public bool PageClassesEnabled { get; set; }
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        //void = method
        //This method helps create dynamic html on the fly! It builds a div with an a tag that displays the current page.

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

            TagBuilder result = new TagBuilder("div");

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {

                TagBuilder tag = new TagBuilder("a");

                PageUrlValues["page"] = i;
                tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);

                if(PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);

                    //This highlights the page that is selected. if true selected else normal -
                    //the PageClassSelected is a class that we have created and is set in the Index.
                    //In the Index page we made the PageClassSelected = "btn-light"
                    // and in the Index page we made the PageClassNormal = "btn-outline-light"
                    //Then the buttons change depending on where you are/ what the i is equal to
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                };

                //append the tag object to the innner html!
                tag.InnerHtml.Append(i.ToString());

                //give the tag object to the result object and display it to the html
                result.InnerHtml.AppendHtml(tag);
            }

            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
