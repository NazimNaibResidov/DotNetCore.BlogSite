using Microsoft.AspNetCore.Mvc;


namespace Blog.WebUI.ViewComponents
{
    public class SearchMenuViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
