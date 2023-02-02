using OLMServer.OLMData;

namespace OLMServer
{
    public class OLMManager
    {
        public string DataPath { private set; get; }

        string GetTablePath(string TableName)
        {
            return DataPath + "/" + TableName;
        }

        public OLMManager(string dataPath)
        {
            DataPath = dataPath;
        }

        public void SaveExistBook(Book book)
        {

        }

        public void AddBook(Book book)
        {

        }
    }
}