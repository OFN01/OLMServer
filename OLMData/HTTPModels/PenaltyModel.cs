using OLMServer.OLMData.Enums;

namespace OLMServer.OLMData.HTTPModels
{
    public class PenaltyModel
    {
        public string date { get; set; }
        public PenaltyReason reason { get; set; }
        public long multiplier { get; set; }
    }
}