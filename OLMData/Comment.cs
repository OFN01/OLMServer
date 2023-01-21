namespace OLMServer.OLMData
{
    public class Comment
    {
        public int ID { get; set; }

        public Book book { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public User user { get; set; }
        public int ratePoint { get; set; }
        public Comment[] comments { get; set; }
        public DateTime publishDate { get; set; }
        public bool isDeleted { get; set; }
    }
}
