using OLMServer.OLMData.Structures;
using OLMServer.OLMData.Enums;
using AdvancedDatasetManager;

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
        public List<Book> likedBooks { get; set; }
        public PunishmentStatus punishmentStatus { get; set; }
        public List<Rent> activeRents { get; set; }
        public List<Rent> rentHistory { get; set; }

        public static User FromDataSet(DataSet ds)
        {
            dynamic ID;
            dynamic name;
            dynamic surname;
            dynamic password;
            dynamic profilePhoto;
            dynamic signupDate;
            dynamic mail;
            dynamic phoneNumber;
            dynamic userLevel;
            dynamic likedBookDataSet;
            dynamic punishmentStatus;
            dynamic activeRentDataSet;
            dynamic rentDataSet;
            if (!(ds.TryGetMember("ID", out ID) &&
                  ds.TryGetMember("name", out name) &&
                  ds.TryGetMember("surname", out surname) &&
                  ds.TryGetMember("password", out password) &&
                  ds.TryGetMember("profilePhoto", out profilePhoto) &&
                  ds.TryGetMember("signupDate", out signupDate) &&
                  ds.TryGetMember("mail", out mail) &&
                  ds.TryGetMember("phoneNumber", out phoneNumber) &&
                  ds.TryGetMember("userLevel", out userLevel) &&
                  ds.TryGetMember("likedBooks", out likedBookDataSet) &&
                  ds.TryGetMember("punishmentStatus", out punishmentStatus) &&
                  ds.TryGetMember("activeRents", out activeRentDataSet) &&
                  ds.TryGetMember("rentHistory", out rentDataSet)
            ))
                throw new Exception("Wrong Type (TODO)");
            signupDate = DateTime.ParseExact(signupDate, "dd.MM.yyyy HH:mm:ss", null);

            List<Book> likedBooks = new List<Book>();
            foreach (DataSet dataset in likedBookDataSet)
            {
                likedBooks.Add(Book.FromDataSet(dataset));
            }
            List<Rent> activeRents = new List<Rent>();
            foreach (DataSet dataset in (IEnumerable<DataSet>)activeRentDataSet)
            {
                activeRents.Add(Rent.FromDataSet(dataset));
            }
            List<Rent> rentHistory = new List<Rent>();
            foreach (DataSet dataset in (IEnumerable<DataSet>)rentDataSet)
            {
                rentHistory.Add(Rent.FromDataSet(dataset));
            }
            return new User()
            {
                ID = ID,
                name = name,
                surname = surname,
                password = password,
                profilePhoto = profilePhoto,
                signupDate = signupDate,
                mail = mail,
                phoneNumber = phoneNumber,
                userLevel = userLevel,
                likedBooks = likedBooks,
                punishmentStatus = punishmentStatus,
                activeRents = activeRents,
                rentHistory = rentHistory
            };
        }

        public DataSet ToDataSet()
        {
            var likedBooks = new List<DataSet>();
            foreach (Book book in this.likedBooks)
            {
                likedBooks.Add(book.ToDataSet());
            }
            var activeRents = new List<DataSet>();
            foreach (Rent rent in this.activeRents)
            {
                activeRents.Add(rent.ToDataSet());
            }
            var rentHistory = new List<DataSet>();
            foreach (Rent rent in this.rentHistory)
            {
                rentHistory.Add(rent.ToDataSet());
            }
            return new DataSet($"Data/Users/{ID}.dsl", new Dictionary<string, dynamic>()
            {
                { "ID", ID },
                { "name", name },
                { "surname", surname },
                { "password", password },
                { "profilePhoto", "" },
                { "signupDate", signupDate.ToString("dd.MM.yyyy-HH.mm.ss") },
                { "mail", mail.ToString() },
                { "phoneNumber", phoneNumber.ToString() },
                { "userLevel", (int)userLevel },
                { "likedBooks", likedBooks },
                { "punishmentStatus", (int)punishmentStatus },
                { "activeRents", activeRents },
                { "rentHistory", rentHistory },
            });
        }
    }
}
