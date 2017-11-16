using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Lib
{
    /// <summary>
    /// 自定义的模型绑定
    /// ValueProviderResult.FirstValue
    /// ModelBindingContext.ValueProvider
    /// ModelBindingContext.ModelState
    /// ModelBindingContext.Result 把结果
    /// </summary>
    public class ProtectedIdModelBinder : IModelBinder
    {
        private readonly IDataProtector protector;
        public ProtectedIdModelBinder(IDataProtectionProvider provider)
        {
            this.protector = provider.CreateProtector("protect_my_query_string");
        }
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            //ModelBindingContext.ValueProvider,根据模型名称获取ValueProviderResult
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if(valueProviderResult==ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            //ModelBindingContext.ModelState,通过这个为模型绑定值
            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);

            //要值到valueProviderResult
            var result = this.protector.Unprotect(valueProviderResult.FirstValue);

            //最后要放到ModelBiningContext.Result
            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }
    }
}
