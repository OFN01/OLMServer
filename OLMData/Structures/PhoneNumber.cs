using System.Text.Json;

namespace OLMServer.OLMData.Structures
{
    public class PhoneNumber
    {
        public int ID { get; set; }

        public string countryCode { get; set; }
        public string phoneCode { get; set; }
        public string phoneNumber => "+" + countryCode + " " + phoneCode;

        public PhoneNumber(string countryCode, string phoneCode)
        {
            this.countryCode = countryCode;
            this.phoneCode = phoneCode;
        }

        public string SerializeData() => "{\"countryCode\":" + countryCode + ", \"phoneCode\":" + phoneCode + "}";
        public PhoneNumber(string JsonData)
        {
            Dictionary<string, object> data = JsonSerializer.Deserialize<Dictionary<string, object>>(JsonData);
            countryCode = data["countryCode"].ToString().Replace(data["countryCode"].ToString().Split(":")[0] + ":", "").Trim('"');
            phoneCode = data["phoneCode"].ToString().Replace(data["phoneCode"].ToString().Split(":")[0] + ":", "").Trim('"');
        }
    }
}
