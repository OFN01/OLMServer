using AdvancedDatasetManager;

namespace OLMServer.OLMData
{
    public class BookSerie
    {
        public int ID { get; set; }

        public string name { get; set; }
        public string description { get; set; }
        public string[] tags { get; set; }
        public List<Book> books { get; set; }

        public static BookSerie FromDataSet(DataSet ds)
        {
            dynamic ID;
            dynamic name;
            dynamic description;
            dynamic tags;
            dynamic bookDataSets;
            if (!(ds.TryGetMember("ID", out ID) &&
                  ds.TryGetMember("name", out name) &&
                  ds.TryGetMember("description", out description) &&
                  ds.TryGetMember("tags", out tags) &&
                  ds.TryGetMember("books", out bookDataSets)
            ))
                throw new Exception("Wrong Type (TODO)");
            var books = new List<Book>();
            foreach (DataSet dataset in (IEnumerable<DataSet>)bookDataSets)
            {
                books.Add(Book.FromDataSet(dataset));
            }
            return new BookSerie()
            {
                ID = ID,
                name = name,
                description = description,
                tags = tags,
                books = books
            };
        }

        public DataSet ToDataSet()
        {
            var books = new List<DataSet>();
            foreach (Book book in this.books)
            {
                books.Add(book.ToDataSet());
            }
            return new DataSet($"Data/BookSeries/{ID}.dsl", new Dictionary<string, dynamic>()
            {
                { "ID", ID },
                { "name", name },
                { "description", description },
                { "tags", tags },
                { "books", books }
            });
        }
    }
}
