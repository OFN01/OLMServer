namespace OLMServer.OLMData
{
    public class Rating
    {
        public int ID { get; set; }

        public Book book { get; set; }
        public float point { get => pointSum / activeCommentNum; }
        public int pointSum { get; set; }
        public int activeCommentNum { get; set; }

        public void Rate(int point)
        {
            activeCommentNum++;
            pointSum += point;
        }

        public void Unrate(int point)
        {
            activeCommentNum--;
            pointSum -= point;
        }
    }
}
