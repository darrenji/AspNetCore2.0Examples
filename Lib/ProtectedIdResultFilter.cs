﻿using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Lib
{
    public class ProtectedIdResultFilter : IResultFilter
    {
        private readonly IDataProtector protector;

        public ProtectedIdResultFilter(IDataProtectionProvider provider)
        {
            this.protector = provider.CreateProtector("protect_my_query_string");
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var viewResult = context.Result as ViewResult;
            if (viewResult == null) return;

            if (!typeof(IEnumerable).IsAssignableFrom(viewResult.Model.GetType()))
                return;

            var model = viewResult.Model as IList;
            foreach(var item in model)
            {
                foreach(var prop in item.GetType().GetProperties())
                {
                    var attribute = prop.GetCustomAttributes(typeof(IProtectedIdAttribute), false).FirstOrDefault();
                    if(attribute!=null)
                    {
                        var value = prop.GetValue(item);
                        var cipher = this.protector.Protect(value.ToString());
                        prop.SetValue(item, cipher);
                    }
                }
            }
        }
    }

    public class ProtectedIdResultFilterAttribute:TypeFilterAttribute
    {
        public ProtectedIdResultFilterAttribute():base(typeof(ProtectedIdResultFilter))
        {

        }
    }
}
