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

        public static Dictionary<int, Author> authors = new Dictionary<int, Author>();
        public static Dictionary<int, Book> books = new Dictionary<int, Book>();
        public static Dictionary<int, BookSerie> bookSeries = new Dictionary<int, BookSerie>()
        {
            {-1, null }
        };
        public static Dictionary<int, Comment> comments = new Dictionary<int, Comment>();
        public static Dictionary<int, Publisher> publishers = new Dictionary<int, Publisher>();
        public static Dictionary<int, Rating> ratings = new Dictionary<int, Rating>();
        public static Dictionary<int, Rent> rents = new Dictionary<int, Rent>();
        public static Dictionary<int, StockAsset> stockAssets = new Dictionary<int, StockAsset>();
        public static Dictionary<int, User> users = new Dictionary<int, User>();

    }
}
