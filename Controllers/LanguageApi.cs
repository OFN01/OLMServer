using Microsoft.AspNetCore.Mvc;
using OLMServer.OLMData.Structures;
using System.IO;

namespace OLMServer.WebContext
{
    [Route("/api/languages/")]
    public class LanguageApi : Controller
    {
        [HttpGet("tr")]
        public ContentResult Turkish()
        {
            return new ContentResult()
            {
                ContentType = "application/json",
                Content = System.IO.File.ReadAllText("Public/Languages/TR.json")
            };
        }

        [HttpGet("en")]
        public ContentResult English()
        {
            return new ContentResult()
            {
                ContentType = "application/json",
                Content = System.IO.File.ReadAllText("Public/Languages/EN.json")
            };
        }
    }
}
