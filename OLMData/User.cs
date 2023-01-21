using OLMServer.OLMData.Structures;
using OLMServer.OLMData.Enums;

namespace OLMServer.OLMData
{
    public class User
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
        public Book[] likedBooks { get; set; }
        public PunishmentStatus punishmentStatus { get; set; }
        public Rent[] activeRents { get; set; } = new Rent[ProgramData.MaxRentAtATime];
        public Rent[] rentHistory { get; set; }
    }
}
