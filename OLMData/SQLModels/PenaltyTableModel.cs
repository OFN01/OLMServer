using OLMServer.OLMData.Enums;

namespace OLMServer.OLMData.SQLModels
{
    public class PenaltyTableModel
    {
        public string date { get; set; }
        public int reason { get; set; }
        public long multiplier { get; set; }
    }
}
