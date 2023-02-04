using AdvancedDatasetManager;
using System.Reflection;
using System.Text.Json;
using System.Xml.Linq;

namespace OLMServer.OLMData
{
    public class Book
    {
        public int ID { get; set; }

        public string name { get; set; }
        public string description { get; set; }
        public Author author { get; set; }
        public Publisher publisher { get; set; }
        public string[] tags { get; set; }
        public string[] types { get; set; }
        public BookSerie bookSerie { get; set; }
        public Rating rating { get; set; }
        public List<User> likers { get; set; }

        public int stockNumber { get => currentStocks.Count; }
        public int availableStock { get { int i = 0; foreach (StockAsset item in currentStocks) if (!item.isRented) i++; return i; } }
        public List<StockAsset> currentStocks { get; set; }

        public static Book FromDataSet(DataSet ds)
        {
            dynamic ID;
            dynamic name;
            dynamic description;
            dynamic author;
            dynamic publisher;
            dynamic tags;
            dynamic types;
            dynamic bookSerie;
            dynamic rating;
            dynamic likerDataSets;
            dynamic currentStockDynamicSet;
            if (!(ds.TryGetMember("ID", out ID) &&
                  ds.TryGetMember("name", out name) &&
                  ds.TryGetMember("description", out description) &&
                  ds.TryGetMember("author", out author) &&
                  ds.TryGetMember("publisher", out publisher) &&
                  ds.TryGetMember("tags", out tags) &&
                  ds.TryGetMember("types", out types) &&
                  ds.TryGetMember("bookSerie", out bookSerie) &&
                  ds.TryGetMember("rating", out rating) &&
                  ds.TryGetMember("likers", out likerDataSets) &&
                  ds.TryGetMember("currentStocks", out currentStockDynamicSet)
            ))
                throw new Exception("Wrong Type (TODO)");
            author = Author.FromDataSet(author);
            publisher = Publisher.FromDataSet(publisher);
            bookSerie = BookSerie.FromDataSet(bookSerie);
            rating = Rating.FromDataSet(rating);
            List<User> likers = new List<User>();
            foreach (DataSet dataset in (IEnumerable<DataSet>)likerDataSets)
            {
                likers.Add(User.FromDataSet(dataset));
            }
            List<StockAsset> currentStocks = new List<StockAsset>();
            foreach (DataSet dataset in (IEnumerable<DataSet>)currentStockDynamicSet)
            {
                currentStocks.Add(StockAsset.FromDataSet(dataset));
            }
            return new Book()
            {
                ID = ID,
                name = name,
                description = description,
                author = author,
                tags = tags,
                types = types,
                bookSerie = bookSerie,
                rating = rating,
                likers = likers,
                currentStocks = currentStocks,
            };
        }

        public DataSet ToDataSet()
        {
            var currentStocks = new List<DataSet>();
            foreach (StockAsset stockAsset in this.currentStocks)
            {
                currentStocks.Add(stockAsset.ToDataSet());
            }
            return new DataSet($"Data/Books/{ID}.dsl", new Dictionary<string, dynamic>()
            {
                { "ID", ID },
                { "name", name },
                { "description", description },
                { "author", author.ToDataSet() },
                { "publisher", publisher.ToDataSet() },
                { "tags", tags },
                { "types", types },
                { "rating", rating.ToDataSet() },
                { "currentStocks", currentStocks }
            });
        }
    }
}
