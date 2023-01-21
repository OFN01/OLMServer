using OLMServer.OLMData;

namespace OLMServer
{
    public static class ProgramData
    {
        public static int MaxRentAtATime = 2;
        public static int MaxRentDays = 15;
        public static int PunishmentTimeout = 5;

        public static int BookPunishmentPerLost = 2;
        public static int BooksForRentTimeout = 2;

        public static string ProgramMail;
        public static string ProgramMailPass;

        public static List<User> users = new List<User>();
        public static List<Book> books = new List<Book>();
        public static List<Rent> rents = new List<Rent>();

        public static List<Author> authors = new List<Author>();
        public static List<Publisher> publishers = new List<Publisher>();
    }
}
