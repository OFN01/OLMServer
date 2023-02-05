using AdvancedDatasetManager;
using System.Xml.Linq;

namespace OLMServer.OLMData
{
    public class Rating
    {
        public int ID { get; set; }

        public Book book { get; set; }
        public float point { get => activeCommentNum == 0 ? -1 : pointSum / activeCommentNum; }
        public int pointSum { get; set; }
        public int activeCommentNum { get; set; }
        public List<Comment> comments { get; set; }

        public void AddComment(Comment comment)
        {
            activeCommentNum++;
            comments.Add(comment);
            pointSum += comment.ratePoint;
        }

        public void RemoveComment(Comment comment)
        {
            activeCommentNum--;
            pointSum += comment.ratePoint;
        }
    }
}
