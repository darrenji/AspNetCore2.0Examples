using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Examples.Pages
{
    //可以把PageModel看做是controller和model的混合，PageModel既可以接受HTTP请求，也可以处理模型出具
    //IndexModel就是页面的页面模型
    public class IndexModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            this.Message = "asp.net core 2.0 razor pages";
        }
    }
}