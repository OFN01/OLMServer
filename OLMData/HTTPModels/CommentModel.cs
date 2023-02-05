using AdvancedDatasetManager;
using System.Xml.Linq;

namespace OLMServer.OLMData.HTTPModels
{
    public class CommentModel
    {
        public string title { get; set; }
        public string content { get; set; }
        public int userID { get; set; }
        public int ratePoint { get; set; }
    }
}