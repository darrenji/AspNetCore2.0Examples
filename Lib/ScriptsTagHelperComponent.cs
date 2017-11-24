using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Lib
{
    public class ScriptsTagHelperComponent:TagHelperComponent
    {
        public override int Order => 99;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if(string.Equals(context.TagName, "head", StringComparison.OrdinalIgnoreCase))
            {
                output.PostContent.AppendHtml($"<script src='js/jquery.min.js'></script> \r\n");
                output.PostContent.AppendHtml($"<script src='js/site.js'></script> \r\n");
            }
        }
    }
}
