using System.Runtime.CompilerServices;

namespace OLMServer.OLMData.Structures
{
    public class Image
    {
        public int ID { get; set; }

        System.Drawing.Image imageData { get; set; }
        public string filePath { get; set; }

        public Image(FileStream file)
        {

        }

        public Image()
        {

        }

        public Image(string filePath)
        {
            this.filePath = filePath;
        }
    }
}
