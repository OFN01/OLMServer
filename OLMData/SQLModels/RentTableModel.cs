using AdvancedDatasetManager;
using OLMServer.OLMData.Structures;

namespace OLMServer.OLMData.SQLModels
{
    public class RentTableModel
    {
        public int ID { get; set; }

        public User user { get; set; }
        public User renter { get; set; }
        public Book book { get; set; }
        public StockAsset stockAsset { get; set; }
        public DateTime rentDate { get; set; }
        public DateTime returnDate { get; set; }
        public string reportData { get; set; }
        public Image reportImage { get; set; }
    }
}
