using AdvancedDatasetManager;
using System.Xml.Linq;

namespace OLMServer.OLMData
{
    public class Comment
    {
        public int ID { get; set; }

        public string title { get; set; }
        public string content { get; set; }
        public User user { get; set; }
        public int ratePoint { get; set; }
        public Comment[] comments { get; set; }
        public DateTime publishDate { get; set; }
        public bool isDeleted { get; set; }

        public static Comment FromDataSet(DataSet ds)
        {
            dynamic ID;
            dynamic title;
            dynamic content;
            dynamic user;
            dynamic ratePoint;
            dynamic commentDataSets;
            dynamic publishDate;
            dynamic isDeleted;
            if (!(ds.TryGetMember("ID", out ID) &&
                  ds.TryGetMember("title", out title) &&
                  ds.TryGetMember("content", out content) &&
                  ds.TryGetMember("user", out user) &&
                  ds.TryGetMember("ratePoint", out ratePoint) &&
                  ds.TryGetMember("comments", out commentDataSets) &&
                  ds.TryGetMember("publishDate", out publishDate) &&
                  ds.TryGetMember("isDeleted", out isDeleted)
            ))
                throw new Exception("Wrong Type (TODO)");
            user = User.FromDataSet(user);
            publishDate = DateTime.ParseExact(publishDate, "dd.MM.yyyy-HH.mm.ss", null);
            var comments = new List<Comment>();
            foreach (DataSet dataset in (IEnumerable<DataSet>)commentDataSets)
            {
                comments.Add(Comment.FromDataSet(dataset));
            }
            return new Comment()
            {
                ID = ID
            };
        }

        public DataSet ToDataSet()
        {
            var comments = new List<DataSet>();
            foreach (Comment comment in this.comments)
            {
                comments.Add(comment.ToDataSet());
            }
            return new DataSet($"Data/Comments/{ID}.dsl", new Dictionary<string, dynamic>()
            {
                { "ID", ID },
                { "title", title },
                { "content", content },
                { "user", user.ToDataSet() },
                { "ratePoint", ratePoint },
                { "comments", comments },
                { "publishDate", publishDate.ToString("dd.MM.yyyy-HH:mm:ss") },
                { "isDeleted", isDeleted }
            });
        }
    }
}