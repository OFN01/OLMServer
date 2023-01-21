using Microsoft.AspNetCore.Mvc;
using OLMServer.OLMData.Structures;

namespace OLMServer.WebContext
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public ContentResult Index()
        {
            Mail mail = "omerfaruknehir@gmail.com";
            Mail mail1 = "ahmet200681@gmail.com";
            Mail mail2 = "qubit.sec@protonmail.com";

            //mail.SendMail("Warning!", "<button>!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! " + Response.HttpContext.Connection.RemoteIpAddress + " entered your site !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!</button>");
            //mail2.SendMail("Warning!", "<button>!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! " + Response.HttpContext.Connection.RemoteIpAddress + " entered your site !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!</button>");
            return new ContentResult()
            {
                ContentType = "text/html",
                Content = System.IO.File.ReadAllText("Public/Documents/index.html")
            };
        }

        [HttpGet("favicon.ico")]
        public FileContentResult Favicon()
        {
            return new FileContentResult(System.IO.File.ReadAllBytes("4344873.ico"), "image/ico");
        }
    }
}
