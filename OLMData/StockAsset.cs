namespace OLMServer.OLMData
{
    public class StockAsset
    {
        public int ID { get; set; }

        public Book book { get; set; }
        public bool isDamaged { get; set; }
        public bool isRented { get; set; }
        public Rent[] rentHistory { get; set; }
        public User rentUser { get; set; }
    }
}
