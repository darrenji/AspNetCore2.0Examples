using Examples.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Filters
{
    public class GreetingTypeFilter : IActionFilter
    {
        private readonly IGreetingService greetingService;
        public GreetingTypeFilter(IGreetingService greetingService)
        {
            this.greetingService = greetingService;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.ActionArguments["param"] = this.greetingService.Greet("Dr. Yes");
        }
    }

    public class GreetingTypeFilterWrapper : TypeFilterAttribute
    {
        public GreetingTypeFilterWrapper():base(typeof(GreetingTypeFilter))
        {

        }
    }
}
