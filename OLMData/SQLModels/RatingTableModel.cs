using AdvancedDatasetManager;
using System.Xml.Linq;

namespace OLMServer.OLMData.SQLModels
{
    public class RatingTableModel
    {
        public int ID { get; set; }

        public int bookID { get; set; }
        public int pointSum { get; set; }
        public int activeCommentNum { get; set; }
        public List<Comment> comments { get; set; }
    }
}
