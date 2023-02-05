using AdvancedDatasetManager;
using System.Reflection;
using System.Text.Json;
using System.Xml.Linq;

namespace OLMServer.OLMData.HTTPModels
{
    public class BookModel
    {
        public string ISBN { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int authorID { get; set; }
        public int publisherID { get; set; }
        public string tags { get; set; }
        public string types { get; set; }
        public int bookSerieID { get; set; }
    }
}
