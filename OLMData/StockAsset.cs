using AdvancedDatasetManager;
using System.Xml.Linq;

namespace OLMServer.OLMData
{
    public class StockAsset
    {
        public int ID { get; set; }

        public Book book { get; set; }
        public bool isDamaged { get; set; }
        public bool isRented { get; set; }
        public List<Rent> rentHistory { get; set; }
        public User rentUser { get; set; }

        public static StockAsset FromDataSet(DataSet ds)
        {
            dynamic ID;
            dynamic book;
            dynamic isDamaged;
            dynamic isRented;
            dynamic rentDataSets;
            dynamic rentUser;
            if (!(ds.TryGetMember("ID", out ID) &&
                  ds.TryGetMember("book", out book) &&
                  ds.TryGetMember("isDamaged", out isDamaged) &&
                  ds.TryGetMember("isRented", out isRented) &&
                  ds.TryGetMember("rentHistory", out rentDataSets) &&
                  ds.TryGetMember("rentUser", out rentUser)
            ))
                throw new Exception("Wrong Type (TODO)");
            var rentHistory = new List<Rent>();
            foreach (DataSet dataset in (IEnumerable<DataSet>)rentDataSets)
            {
                rentHistory.Add(Rent.FromDataSet(dataset));
            }
            return new StockAsset()
            {
                ID = ID,
                book = book,
                isDamaged = isDamaged,
                isRented = isRented,
                rentHistory = rentHistory,
                rentUser = rentUser
            };
        }

        public DataSet ToDataSet()
        {
            var rentHistory = new List<DataSet>();
            foreach (Rent rent in this.rentHistory)
            {
                rentHistory.Add(rent.ToDataSet());
            }
            return new DataSet($"Data/StockAssets/{ID}.dsl", new Dictionary<string, dynamic>()
            {
                { "ID", ID },
                { "book", book.ToDataSet() },
                { "isDamaged", isDamaged },
                { "isRented", isRented },
                { "rentHistory", rentHistory },
                { "rentUser", rentUser.ToDataSet() },
            });
        }
    }
}
