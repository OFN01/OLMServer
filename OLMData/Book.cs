using System.Text.Json;

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
        public BookSerie includedBookSerie { get; set; }
        public DateOnly publishDate { get; set; }
        public Comment[] comments { get; set; }
        public Rating rating { get; set; }
        public User[] likers { get; set; }

        public int stockNumber { get => currentStocks.Length; }
        public int availableStock { get { int i = 0; foreach (StockAsset item in currentStocks) if (!item.isRented) i++; return i; } }
        public StockAsset[] currentStocks { get; set; }
    }
}
