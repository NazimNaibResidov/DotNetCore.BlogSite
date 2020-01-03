using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.ViewComponents
{
    public class HeaderMenuViewComponent:ViewComponent
    {
        
        private readonly IAuthenticationSchemeProvider provider;
        public HeaderMenuViewComponent(IAuthenticationSchemeProvider _provider)
        {
            
            provider = _provider;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = (await provider.GetAllSchemesAsync())
                        .Select(x => x.DisplayName).Where(x => !string.IsNullOrEmpty(x)).ToList();
            return await Task.FromResult<IViewComponentResult>(View(items));
        }
        //public async Task<IViewComponentResult> Invoke()
        //{
        //    var items = (await provider.GetAllSchemesAsync())
        //              .Select(x => x.DisplayName).Where(x => !string.IsNullOrEmpty(x)).ToList();
        //    var result = View(items);
        //    return await Task.FromResult<IViewComponentResult>(result);
        //    // return View(result);
        //}
    }
}
