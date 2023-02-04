using OLMServer.OLMData;

namespace OLMServer
{
    public static class ProgramData
    {
        public static int MaxRentAtATime = 2;
        public static int MaxRentDays = 15;
        public static int PunishmentTimeout = 5;

        public static string Directory;

        public static int BookPunishmentPerLost = 2;
        public static int BooksForRentTimeout = 2;

        public static string ProgramMail;
        public static string ProgramMailPass;

        public static List<Author> authors = new List<Author>();
        public static List<Book> books = new List<Book>();
        public static List<BookSerie> bookSeries = new List<BookSerie>();
        public static List<Comment> comments = new List<Comment>();
        public static List<Publisher> publishers = new List<Publisher>();
        public static List<Rating> ratings = new List<Rating>();
        public static List<Rent> rents = new List<Rent>();
        public static List<StockAsset> stockAssets = new List<StockAsset>();
        public static List<User> users = new List<User>();

    }
}
