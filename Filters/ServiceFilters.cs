using Examples.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Filters
{
    public class GreetingServiceFilter : IActionFilter
    {
        private readonly IGreetingService greetingService;

        public GreetingServiceFilter(IGreetingService greetingService)
        {
            this.greetingService = greetingService;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.ActionArguments["param"] = this.greetingService.Greet("james bond");
        }
    }
}
