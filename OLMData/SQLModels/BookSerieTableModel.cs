using AdvancedDatasetManager;

namespace OLMServer.OLMData.SQLModels
{
    public class BookSerieTableModel
    {
        public int ID { get; set; }

        public string name { get; set; }
        public string description { get; set; }
        public string[] tags { get; set; }
        public List<Book> books { get; set; }
    }
}
