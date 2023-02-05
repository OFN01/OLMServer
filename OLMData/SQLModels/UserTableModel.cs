using OLMServer.OLMData.Structures;
using OLMServer.OLMData.Enums;
using AdvancedDatasetManager;

namespace OLMServer.OLMData.SQLModels
{
    public class UserTableModel
    {
        public int ID { get; set; }

        public string name { get; set; }
        public string surname { get; set; }
        public string password { get; set; }
        public Image profilePhoto { get; set; }
        public DateTime signupDate { get; set; }
        public Mail mail { get; set; }
        public PhoneNumber phoneNumber { get; set; }
        public UserLevel userLevel { get; set; }
        public List<Book> likedBooks { get; set; }
        public List<Penalty> activePenalties { get; set; }
        public List<Penalty> penaltyHistory { get; set; }
        public List<Rent> activeRents { get; set; }
        public List<Rent> rentHistory { get; set; }
    }
}
