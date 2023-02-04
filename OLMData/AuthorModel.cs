using AdvancedDatasetManager;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using OLMServer.OLMData.Structures;

namespace OLMServer.OLMData
{
    public class AuthorModel
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string description { get; set; }
        public string[] tags { get; set; }
        public string birthDate { get; set; }
    }
}