using Microsoft.AspNetCore.Mvc;

namespace OLMServer.WebContext
{
    [Route("/Public")]
    public class PublicController : Controller
    {
        [HttpGet("Scripts/{path}")]
        public ContentResult Scripts(string path)
        {
            if (!System.IO.File.Exists("Public/Scripts/" + path))
                return new ContentResult
                {
                    StatusCode = 404,
                    ContentType = "text/html",
                    Content = System.IO.File.ReadAllText("Public\\Documents\\Errors\\404.html")
                };
            Console.Write("Eerr");
            return new ContentResult
            {
                ContentType = "text/javascript",
                Content = System.IO.File.ReadAllText("Public/Scripts/" + path)
            };
        }

        [HttpGet("Media/Animated/{path}")]
        public ActionResult AnimatedMedia(string path)

        {
            if (!System.IO.File.Exists("Public/Media/Animated/" + path))
                return new ContentResult
                {
                    StatusCode = 404,
                    ContentType = "text/html",
                    Content = System.IO.File.ReadAllText("Public/Documents/Errors/404.html")
                };
            return new FileContentResult(System.IO.File.ReadAllBytes("Public/Media/Animated/" + path), "image/gif");
        }

        [HttpGet("Media/Static/{path}")]
        public ActionResult StaticMedia(string path)

        {
            if (!System.IO.File.Exists("Public/Media/Static/" + path))
                return new ContentResult
                {
                    StatusCode = 404,
                    ContentType = "text/html",
                    Content = System.IO.File.ReadAllText("Public/Documents/Errors/404.html")
                };
            return new FileContentResult(System.IO.File.ReadAllBytes("Public/Media/Static/" + path), "image/png");
        }

        [HttpGet("Stylesheets/{path}")]
        public ActionResult Stylesheet(string path)

        {
            if (!System.IO.File.Exists("Public/Stylesheets/" + path))
                return new ContentResult
                {
                    StatusCode = 404,
                    ContentType = "text/html",
                    Content = System.IO.File.ReadAllText("Public/Documents/Errors/404.html")
                };
            return new FileContentResult(System.IO.File.ReadAllBytes("Public/Stylesheets/" + path), "text/css");
        }
    }
}
