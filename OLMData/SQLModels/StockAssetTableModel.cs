using AdvancedDatasetManager;
using System.Xml.Linq;

namespace OLMServer.OLMData.SQLModels
{
    public class StockAssetTableModel
    {
        public int ID { get; set; }

        public Book book { get; set; }
        public bool isDamaged { get; set; }
        public bool isRented { get; set; }
        public List<Rent> rentHistory { get; set; }
        public User rentUser { get; set; }
    }
}
