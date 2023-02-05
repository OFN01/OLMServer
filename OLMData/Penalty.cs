using OLMServer.OLMData.Enums;

namespace OLMServer.OLMData
{
    public class Penalty
    {
        public DateTime date { get; set; }
        public PenaltyReason reason { get; set; }
        public long multiplier { get; set; }
    }
}