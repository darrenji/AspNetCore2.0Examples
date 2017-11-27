using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Examples.Pages
{
    //���԰�PageModel������controller��model�Ļ�ϣ�PageModel�ȿ��Խ���HTTP����Ҳ���Դ���ģ�ͳ���
    //IndexModel����ҳ���ҳ��ģ��
    public class IndexModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            this.Message = "asp.net core 2.0 razor pages";
        }
    }
}