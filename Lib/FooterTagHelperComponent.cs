using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Lib
{
    public class FooterTagHelperComponent:TagHelperComponent
    {
        public override int Order => 1;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if(string.Equals(context.TagName, "footer", StringComparison.OrdinalIgnoreCase))
            {
                output.PostContent.AppendHtml(
                    string.Format($"<p>{DateTime.Now.ToString()}</p>"));
            }
        }
    }
}
