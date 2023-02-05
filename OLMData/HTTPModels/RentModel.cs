using AdvancedDatasetManager;
using OLMServer.OLMData.Structures;

namespace OLMServer.OLMData.HTTPModels
{
    public class RentModel
    {
        public int userID { get; set; }
        public int renterID { get; set; }
        public int bookID { get; set; }
        public int stockAssetID { get; set; }
        public string rentDate { get; set; }
    }
}
