using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace OLMServer.OLMData.SQLModels
{
    public class BookLocationTableModel
    {
        public int ID { get; set; }
        public int caseNum { get; set; }
        public int shelfNum { get; set; }
    }
}