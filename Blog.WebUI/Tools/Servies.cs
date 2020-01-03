using Blog.Data.Abstrac;
using Blog.Data.Concreate;
using Blog.Data.Core.IUnit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.Tools
{
    public class Servies
    {
        public static void DInj(IServiceCollection services)
        {
            services.AddTransient<IArticleRepostory, ArticalRepostory>();
            services.AddTransient<ICommentRepstory, CommentRepostory>();

            services.AddTransient<IImageRepstory, ImageRepstory>();
            services.AddTransient<ICategoryRepstory, CategoryRepstory>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

    }
}
