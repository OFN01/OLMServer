using AdvancedDatasetManager;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using OLMServer.OLMData.Structures;

namespace OLMServer.OLMData
{
    public class Author
    {
        public int ID { get; set; }

        public string name { get; set; }
        public string surname { get; set; }
        public string description { get; set; }
        public string[] tags { get; set; }
        public List<Book> books { get; set; }
        public List<BookSerie> bookSeries { get; set; }
        public DateOnly birthDate { get; set; }
        public Image photo { get; set; }

        public static Author FromDataSet(DataSet ds)
        {
            dynamic ID;
            dynamic name;
            dynamic surname;
            dynamic description;
            dynamic tags;
            dynamic bookDataSets;
            dynamic bookSerieDataSets;
            dynamic birthDate;
            if (!(ds.TryGetMember("ID", out ID) &&
                  ds.TryGetMember("name", out name) &&
                  ds.TryGetMember("surname", out surname) &&
                  ds.TryGetMember("description", out description) &&
                  ds.TryGetMember("tags", out tags) &&
                  ds.TryGetMember("books", out bookDataSets) &&
                  ds.TryGetMember("bookSeries", out bookSerieDataSets) &&
                  ds.TryGetMember("birthDate", out birthDate)
            ))
                throw new Exception("Wrong Type (TODO)");
            var books = new List<Book>();
            foreach (DataSet dataset in bookDataSets)
            {
                books.Add(Book.FromDataSet(dataset));
            }
            var bookSeries = new List<BookSerie>();
            foreach (DataSet dataset in (IEnumerable<DataSet>)bookSerieDataSets)
            {
                bookSeries.Add(BookSerie.FromDataSet(dataset));
            }
            return new Author()
            {
                ID = ID,
                name = name,
                surname = surname,
                description = description,
                tags = tags,
                books = books,
                bookSeries = bookSeries,
                birthDate = DateOnly.ParseExact(birthDate, "dd.MM.yyyy")
            };
        }

        public DataSet ToDataSet()
        {
            var books = new List<DataSet>();
            foreach (Book book in this.books)
            {
                books.Add(book.ToDataSet());
            }
            var bookSeries = new List<DataSet>();
            foreach (BookSerie bookSerie in this.bookSeries)
            {
                bookSeries.Add(bookSerie.ToDataSet());
            }
            return new DataSet($"Data/Authors/{ID}.dsl", new Dictionary<string, dynamic>()
            {
                { "ID", ID },
                { "name", name },
                { "surname", surname },
                { "description", description },
                { "tags", tags },
                { "books", books },
                { "bookSeries", bookSeries },
                { "birthDate", birthDate.ToString("yyyy") }
            });
        }
    }
}