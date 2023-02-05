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
    }
}