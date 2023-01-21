using Microsoft.AspNetCore.Mvc;

namespace OLMServer.WebContext
{
    [Route("/public")]
    public class PublicController : Controller
    {
        [HttpGet("script/{path}")]
        public ContentResult Scripts(string path)
        
        {
            if (!System.IO.File.Exists("Public/Scripts/" + path))
                return new ContentResult
                {
                    StatusCode = 404,
                    ContentType = "text/html",
                    Content = System.IO.File.ReadAllText("Public/Documents/Errors/404.html")
                };
            return new ContentResult
            {
                ContentType = "text/javascript",
                Content = System.IO.File.ReadAllText("Public/Scripts/" + path)
            };
        }
    }
}
