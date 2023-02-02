using Microsoft.AspNetCore.Mvc;
using OLMServer.OLMData.Structures;
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

        string[] x = new string[] {
            "Afghanistan",
            "Albania",
            "Algeria",
            "Andorra",
            "Angola",
            "Antigua & Deps",
            "Argentina",
            "Armenia",
            "Australia",
            "Austria",
            "Azerbaijan",
            "Bahamas",
            "Bahrain",
            "Bangladesh",
            "Barbados",
            "Belarus",
            "Belgium",
            "Belize",
            "Benin",
            "Bermuda",
            "Bhutan",
            "Bolivia",
            "Bosnia Herzegovina",
            "Botswana",
            "Brazil",
            "Brunei",
            "Bulgaria",
            "Burkina",
            "Burundi",
            "Cambodia",
            "Cameroon",
            "Canada",
            "Cape Verde",
            "Central African Rep",
            "Chad",
            "Chile",
            "China",
            "Colombia",
            "Comoros",
            "Congo",
            "Congo (Democratic Rep)",
            "Costa Rica",
            "Croatia",
            "Cuba",
            "Cyprus",
            "Czech Republic",
            "Denmark",
            "Djibouti",
            "Dominica",
            "Dominican Republic",
            "East Timor",
            "Ecuador",
            "Egypt",
            "El Salvador",
            "Equatorial Guinea",
            "Eritrea",
            "Estonia",
            "Eswatini",
            "Ethiopia",
            "Fiji",
            "Finland",
            "France",
            "Gabon",
            "Gambia",
            "Georgia",
            "Germany",
            "Ghana",
            "Greece",
            "Grenada",
            "Guatemala",
            "Guinea",
            "Guinea-Bissau",
            "Guyana",
            "Haiti",
            "Honduras",
            "Hungary",
            "Iceland",
            "India",
            "Indonesia",
            "Iran",
            "Iraq",
            "Ireland (Republic)",
            "Israel",
            "Italy",
            "Ivory Coast",
            "Jamaica",
            "Japan",
            "Jordan",
            "Kazakhstan",
            "Kenya",
            "Kiribati",
            "Korea North",
            "Korea South",
            "Kosovo",
            "Kuwait",
            "Kyrgyzstan",
            "Laos",
            "Latvia",
            "Lebanon",
            "Lesotho",
            "Liberia",
            "Libya",
            "Liechtenstein",
            "Lithuania",
            "Luxembourg",
            "Macedonia",
            "Madagascar",
            "Malawi",
            "Malaysia",
            "Maldives",
            "Mali",
            "Malta",
            "Marshall Islands",
            "Mauritania",
            "Mauritius",
            "Mexico",
            "Micronesia",
            "Moldova",
            "Monaco",
            "Mongolia",
            "Montenegro",
            "Morocco",
            "Mozambique",
            "Myanmar",
            "Namibia",
            "Nauru",
            "Nepal",
            "Netherlands",
            "New Zealand",
            "Nicaragua",
            "Niger",
            "Nigeria",
            "Norway",
            "Oman",
            "Pakistan",
            "Palau",
            "Palestine",
            "Panama",
            "Papua New Guinea",
            "Paraguay",
            "Peru",
            "Philippines",
            "Poland",
            "Portugal",
            "Qatar",
            "Romania",
            "Russian Federation",
            "Rwanda",
            "St Kitts & Nevis",
            "St Lucia",
            "Saint Vincent & the Grenadines",
            "Samoa",
            "San Marino",
            "Sao Tome & Principe",
            "Saudi Arabia",
            "Senegal",
            "Serbia",
            "Seychelles",
            "Sierra Leone",
            "Singapore",
            "Slovakia",
            "Slovenia",
            "Solomon Islands",
            "Somalia",
            "South Africa",
            "South Sudan",
            "Spain",
            "Sri Lanka",
            "Sudan",
            "Suriname",
            "Sweden",
            "Switzerland",
            "Syria",
            "Taiwan",
            "Tajikistan",
            "Tanzania",
            "Thailand",
            "Togo",
            "Tonga",
            "Trinidad & Tobago",
            "Tunisia",
            "Turkey",
            "Turkmenistan",
            "Tuvalu",
            "Uganda",
            "Ukraine",
            "United Arab Emirates",
            "United Kingdom",
            "United States",
            "Uruguay",
            "Uzbekistan",
            "Vanuatu",
            "Vatican City",
            "Venezuela",
            "Vietnam",
            "Yemen",
            "Zambia",
            "Zimbabwe",
        };

        [HttpGet("complete")]
        public ActionResult Complete(string q)
        {
            if (string.IsNullOrEmpty(q))
            {
                return new ContentResult()
                {
                    ContentType = "application/json",
                    Content = "[]"
                };
            }

            var nlst = Libraries.TextProcessing.AutoComplete(q, x);

            string lst = "[";
            foreach (string str in nlst)
            {
                lst += $"\"{str}\",";
                Console.WriteLine(str);
            }
            if (lst.Length > 1)
            {
                lst = lst.Remove(lst.Length - 1, 1);
            }
            lst += "]";
            return new ContentResult()
            {
                ContentType = "application/json",
                Content = lst
            };
        }

        [HttpGet("favicon.ico")]
        public ActionResult Favicon()
        {
            return new FileContentResult(System.IO.File.ReadAllBytes("4344873.ico"), "image/ico");
        }
    }
}
