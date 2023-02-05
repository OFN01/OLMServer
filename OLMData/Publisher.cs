using AdvancedDatasetManager;
using OLMServer.OLMData.Structures;

namespace OLMServer.OLMData
{
    public class Publisher
    {
        public int ID { get; set; }

        public string name { get; set; }
        public string[] tags { get; set; }
        public List<Book> books { get; set; }
        public Image logo { get; set; }
    }
}
