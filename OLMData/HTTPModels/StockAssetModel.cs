using AdvancedDatasetManager;
using System.Xml.Linq;

namespace OLMServer.OLMData.HTTPModels
{
    public class StockAssetModel
    {
        public int bookID { get; set; }
        public BookLocationModel location { get; set; }
    }
}
