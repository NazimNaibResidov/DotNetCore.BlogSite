using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Blog.WebUI.Helpers.Paths
{
    public class PathOptions
    {
        public static string PathFolder(IHostingEnvironment env, string FolderName,string Name)
        {
          return  Path.Combine(env.WebRootPath, $"blog/{FolderName}/") + $"/{Name}";
        }
        public static string ImagePath(string FolderName,string Name)
        {
            return $"/blog/{FolderName}/{Name}";
        }
    }
}
