using AdvancedDatasetManager;
using OLMServer.OLMData.Structures;

namespace OLMServer.OLMData
{
    public class Rent
    {
        public int ID { get; set; }

        public User user { get; set; }
        public User renter { get; set; }
        public Book book { get; set; }
        public StockAsset stockAsset { get; set; }
        public DateTime rentDate { get; set; }
        public DateTime returnDate { get; set; }
        public string reportData { get; set; }
        public Image reportImage { get; set; }

        public static Rent FromDataSet(DataSet ds)
        {
            dynamic ID;
            dynamic user;
            dynamic book;
            dynamic stockAsset;
            dynamic rentDate;
            dynamic returnDate;
            dynamic reportData;
            dynamic reportImage;
            if (!(ds.TryGetMember("ID", out ID) &&
                  ds.TryGetMember("user", out user) &&
                  ds.TryGetMember("book", out book) &&
                  ds.TryGetMember("stockAsset", out stockAsset) &&
                  ds.TryGetMember("rentDate", out rentDate) &&
                  ds.TryGetMember("returnDate", out returnDate) &&
                  ds.TryGetMember("reportData", out reportData) &&
                  ds.TryGetMember("reportImage", out reportImage)
            ))
                throw new Exception("Wrong Type (TODO)");
            user = User.FromDataSet(user);
            book = Book.FromDataSet(book);
            stockAsset = StockAsset.FromDataSet(stockAsset);
            rentDate = DateTime.ParseExact(rentDate, "dd.MM.yyyy-HH:mm:ss", null);
            returnDate = DateTime.ParseExact(returnDate, "dd.MM.yyyy-HH:mm:ss", null);
            return new Rent()
            {
                ID = ID,
                user = user,
                book = book,
                stockAsset = stockAsset,
                rentDate = rentDate,
                returnDate = returnDate,
                reportData = reportData,
                reportImage = reportImage
            };
        }

        public DataSet ToDataSet()
        {
            return new DataSet($"Data/Rents/{ID}.dsl", new Dictionary<string, dynamic>()
            {
                { "ID", ID },
                { "user", user.ToDataSet() },
                { "book", book.ToDataSet() },
                { "stockAsset", stockAsset.ToDataSet() },
                { "rentDate", rentDate.ToString("dd.MM.yyyy-HH.mm.ss") },
                { "returnDate", returnDate.ToString("dd.MM.yyyy-HH.mm.ss") },
                { "reportData", reportData },
                { "reportImage", "" },
            });
        }
    }
}
