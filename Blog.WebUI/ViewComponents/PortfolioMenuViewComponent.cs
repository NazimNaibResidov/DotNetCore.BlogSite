using Blog.Data.Core.IUnit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.ViewComponents
{
    public class PortfolioMenuViewComponent:ViewComponent
    {
        private readonly IUnitOfWork unitOfWork;
        
        public PortfolioMenuViewComponent(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public IViewComponentResult Invoke()
        {
            return View(unitOfWork.ImageRepstory.Select().ToList());
        }
    }
}
