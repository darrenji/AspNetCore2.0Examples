using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Models.Home
{
    //继承于ViewComponent
    //默认的、惯例默认的名称是Address
    [ViewComponent(Name = "Address")]
    public class AddressComponent:ViewComponent
    {
        private readonly IAddressFormatter formatter;
        public AddressComponent(IAddressFormatter formatter)
        {
            this.formatter = formatter;
        }

        //类似于Controller中的IActionResult，但组件不依赖Controller
        //接受多个参数
        public async Task<IViewComponentResult> InvokeAsync(int employeeId)
        {
            var model = new AddressViewModel
            {
                EmployeeId = employeeId,
                Line1 = "secret location",
                Line2 = "london",
                Line3 = "uk"
            };
            model.FormattedValue = this.formatter.Format(model.Line1, model.Line2, model.Line3);
            //组件虽然不依赖controller，但依赖视图，在这里还可以注明是哪个视图
            return View(model);
        }
    }
}
