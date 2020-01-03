using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.WebUI.TagsHelpers
{
    [HtmlTargetElement("p")]
    public class ContextTagHelper:TagHelper
    {
        [HtmlAttributeName("text")]
        public string Text { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = string.Empty;
           

            if (!string.IsNullOrEmpty(Text))
            {
                if (Text.Length < 290)
                {
                    output.Content.SetHtmlContent(Text.ToString());
                }
                else
                {
                   
                    output.Content.SetHtmlContent(Text.Substring(0, 348).ToString()+ " [...]");
                }
            }
            
        }
    }
}
