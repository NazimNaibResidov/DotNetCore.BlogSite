

using Blog.Data.Core.IUnit;
using Blog.Entity.Data;
using Blog.WebUI.Helpers.Paths;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Blog.WebUI.Helpers.Images
{
    public class ImageOptions
    {
       
       
        public async static Task<int> SaveImage(IFormFile file, IHostingEnvironment env,IUnitOfWork context)
        {
            Image image = new Image();
            string Name = Tools.RNImage(file.FileName);

            string smallPath = PathOptions.PathFolder(env, "spath", Name);
            string bigPath = PathOptions.PathFolder(env, "bpath", Name);
            string midelPath = PathOptions.PathFolder(env, "mpath", Name);

  Tools.RASImage(file.OpenReadStream(), smallPath, 60, 60);
  Tools.RASImage(file.OpenReadStream(), bigPath, 840, 330);
  Tools.RASImage(file.OpenReadStream(), midelPath, 326, 135);

           image.BPath = PathOptions.ImagePath("bpath", Name);
           image.MPath = PathOptions.ImagePath("mpath", Name);
           image.SPath = PathOptions.ImagePath("spath", Name);

  context.ImageRepstory.Add(image);
  await context.SaveChanges();
  return image.Id;
        }
        public async static Task<int> SaveImageForUser(IFormFile file, IHostingEnvironment env, IUnitOfWork context)
        {
            Image image = new Image();
            string Name = string.Empty;
            if (file != null)
            {
               
                Name = Tools.RNImage(file.FileName);
                string userPath = PathOptions.PathFolder(env, "upath", Name);
                Tools.RASImage(file.OpenReadStream(), userPath, 60, 60);
                image.UserPath = PathOptions.ImagePath("upath", Name);
                image.DateTime = DateTime.Now;
               
            }
            else
            {
                //~/img/avatars/avatar.jpg
                Name = "avatar.jpg";
                image.UserPath = PathOptions.ImagePath("upath",Name);
                image.DateTime = DateTime.Now;
            }
            context.ImageRepstory.Add(image);
            await context.SaveChanges();
            return image.Id;
        }
       
    }
}
