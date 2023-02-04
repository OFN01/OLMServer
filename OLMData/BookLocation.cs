using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace OLMServer.OLMData
{
    public class BookLocationException : Exception
    {
        public new string Message = "";
        public BookLocationException(string message) { Message = "BookLocationException: " + message; }
    }

    public class BookLocation
    {
        public int ID { get; set; }
        public int caseNum { get; set; }
        public int shelfNum { get; set; }

        public BookLocation(int caseNum, int shelfNum)
        {
            this.caseNum = caseNum;
            this.shelfNum = shelfNum;
        }

        public string SerializeData() => "{\"caseNum\":" + caseNum + ", \"shelfNum\":" + shelfNum + "}";
        public BookLocation(string JsonData)
        {
            Dictionary<string, object> data = JsonSerializer.Deserialize<Dictionary<string, object>>(JsonData);
            caseNum = int.Parse(data["caseNum"].ToString().Replace(data["caseNum"].ToString().Split(":")[0] + ":", "").Trim('"'));
            shelfNum = int.Parse(data["shelfNum"].ToString().Replace(data["shelfNum"].ToString().Split(":")[0] + ":", "").Trim('"'));
        }
    }
}