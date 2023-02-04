using OLMServer.OLMData.Structures;
using OLMServer.OLMData.Enums;
using AdvancedDatasetManager;

namespace OLMServer.OLMData
{
    public class UserModel
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string password { get; set; }
        public string signupDate { get; set; }
        public string mail { get; set; }
        public string phoneNumber { get; set; }
    }
}
