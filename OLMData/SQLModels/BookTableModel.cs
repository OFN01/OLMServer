using AdvancedDatasetManager;
using System.Reflection;
using System.Text.Json;
using System.Xml.Linq;

namespace OLMServer.OLMData.SQLModels
{
    public class BookTableModel
    {
        public int ID { get; set; }

        public string ISBN { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Author author { get; set; }
        public Publisher publisher { get; set; }
        public string[] tags { get; set; }
        public string[] types { get; set; }
        public BookSerie bookSerie { get; set; }
        public Rating rating { get; set; }
        public List<User> likers { get; set; }

        public int stockNumber { get => currentStocks.Count; }
        public int availableStock { get { int i = 0; foreach (StockAsset item in currentStocks) if (!item.isRented) i++; return i; } }
        public List<StockAsset> currentStocks { get; set; }
    }
}
