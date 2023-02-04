using AdvancedDatasetManager;
using System.Xml.Linq;

namespace OLMServer.OLMData
{
    public class StockAssetModel
    {
        public int bookID { get; set; }
        public BookLocationModel location { get; set; }
    }
}
