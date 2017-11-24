using Examples.Services;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.TagHelpers
{
    [HtmlTargetElement("greeting")]
    public class GreetingTagHelper:TagHelper
    {
        private readonly IGreetingService service;

        public GreetingTagHelper(IGreetingService service)
        {
            this.service = service;
        }

        [HtmlAttributeName("name")]
        public string Name { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "p";
            output.Content.SetContent(this.service.Greet(this.Name));
        }
    }
}
