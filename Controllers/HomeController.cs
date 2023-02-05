using Microsoft.AspNetCore.Mvc;
using OLMServer.OLMData;
using OLMServer.OLMData.Structures;
using System.Diagnostics.Metrics;
using System.IO.Pipelines;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System;
using System.Text.RegularExpressions;

namespace OLMServer.WebContext
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public ActionResult Index()
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

        [HttpGet("search")]
        public ActionResult Search(string q)
        {
            if (string.IsNullOrEmpty(q))
            {
                return new RedirectResult("/");
            }

            return new ContentResult()
            {
                ContentType = "text/html",
                Content = System.IO.File.ReadAllText("Public/Documents/search.html")
            };
        }

        [HttpGet("signup")]
        public ActionResult Signup()
        {
            return new ContentResult()
            {
                ContentType = "text/html",
                Content = System.IO.File.ReadAllText("Public/Documents/signup.html")
            };
        }

        [HttpGet("favicon.ico")]
        public ActionResult Favicon()
        {
            return new FileContentResult(System.IO.File.ReadAllBytes("4344873.ico"), "image/ico");
        }
    }
}
