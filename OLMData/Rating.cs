using AdvancedDatasetManager;
using System.Xml.Linq;

namespace OLMServer.OLMData
{
    public class Rating
    {
        public int ID { get; set; }

        public Book book { get; set; }
        public float point { get => pointSum / activeCommentNum; }
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

        public static Rating FromDataSet(DataSet ds)
        {
            dynamic ID;
            dynamic book;
            dynamic pointSum;
            dynamic activeCommentNum;
            dynamic commentDataSets;
            if (!(ds.TryGetMember("ID", out ID) &&
                  ds.TryGetMember("book", out book) &&
                  ds.TryGetMember("pointSum", out pointSum) &&
                  ds.TryGetMember("activeCommentNum", out activeCommentNum) &&
                  ds.TryGetMember("comments", out commentDataSets)
            ))
                throw new Exception("Wrong Type (TODO)");
            var comments = new List<Comment>();
            foreach (DataSet dataset in (IEnumerable<DataSet>)commentDataSets)
            {
                comments.Add(Comment.FromDataSet(dataset));
            }
            return new Rating()
            {
                ID = ID,
                book = Book.FromDataSet(book),
                pointSum = pointSum,
                activeCommentNum = activeCommentNum,
                comments = comments
            };
        }

        public DataSet ToDataSet()
        {
            var comments = new List<DataSet>();
            foreach (Comment comment in this.comments)
            {
                comments.Add(comment.ToDataSet());
            }
            return new DataSet($"Data/Ratings/{ID}.dsl", new Dictionary<string, dynamic>()
            {
                { "ID", ID },
                { "book", book.ToDataSet() },
                { "pointSum", pointSum },
                { "active", activeCommentNum },
                { "comments", comments }
            });
        }
    }
}
