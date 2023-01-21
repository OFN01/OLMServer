namespace OLMServer.OLMData
{
    public class BookSerie
    {
        public int ID { get; set; }

        public string name { get; set; }
        public string description { get; set; }
        public string[] tags { get; set; }
        public Book[] books { get; set; }
        public DateOnly startDate { get; set; }
        public DateOnly endDate { get; set; }
    }
}
