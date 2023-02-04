using AdvancedDatasetManager;
using OLMServer.OLMData.Structures;

namespace OLMServer.OLMData
{
    public class Publisher
    {
        public int ID { get; set; }

        public string name { get; set; }
        public string[] tags { get; set; }
        public List<Book> books { get; set; }
        public Image logo { get; set; }

        public static Publisher FromDataSet(DataSet ds)
        {
            dynamic ID;
            dynamic name;
            dynamic tags;
            dynamic bookDataSets;
            dynamic logo;
            if (!(ds.TryGetMember("ID", out ID) &&
                  ds.TryGetMember("name", out name) &&
                  ds.TryGetMember("tags", out tags) &&
                  ds.TryGetMember("books", out bookDataSets) &&
                  ds.TryGetMember("logo", out logo)
            ))
                throw new Exception("Wrong Type (TODO)");
            var books = new List<Book>();
            foreach (DataSet dataset in (IEnumerable<DataSet>)bookDataSets)
            {
                books.Add(Book.FromDataSet(dataset));
            }
            return new Publisher()
            {
                ID = ID,
                name = name,
                tags = tags,
                books = books,
                logo = logo
            };
        }

        public DataSet ToDataSet()
        {
            var books = new List<DataSet>();
            foreach (Book book in this.books)
            {
                books.Add(book.ToDataSet());
            }
            return new DataSet($"Data/Publishers/{ID}.dsl", new Dictionary<string, dynamic>()
            {
                { "ID", ID },
                { "name", name },
                { "tags", tags },
                { "books", books },
                { "logo", "" }
            });
        }
    }
}
