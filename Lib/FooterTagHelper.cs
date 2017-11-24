using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Lib
{
    [HtmlTargetElement("footer")]
    public class FooterTagHelper:TagHelperComponentTagHelper
    {
        public FooterTagHelper(ITagHelperComponentManager manger, ILoggerFactory logger):base(manger, logger)
        {

        }
    }
}
