using AdvancedDatasetManager;
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


        public void SaveExistBook(Book item)
        {
            item.ToDataSet().SaveData();
        }
        public void AddBook(Book item)
        {
            item.ID = Directory.GetFiles("Data/Books/", "*.dsl", SearchOption.TopDirectoryOnly).Length + 1;
            item.ToDataSet().SaveData();
        }
        public Book GetBook(int ID)
        {
            return Book.FromDataSet(new DataSet($"Data/Books/{ID}.dsl"));
        }


        public void SaveExistAuthor(Author item)
        {
            item.ToDataSet().SaveData();
        }
        public void AddAuthor(Author item)
        {
            item.ID = Directory.GetFiles("Data/Authors/", "*.dsl", SearchOption.TopDirectoryOnly).Length + 1;
            item.ToDataSet().SaveData();
        }
        public Author GetAuthor(int ID)
        {
            return Author.FromDataSet(new DataSet($"Data/Authors/{ID}.dsl"));
        }


        public void SaveExistBookSerie(BookSerie item)
        {
            item.ToDataSet().SaveData();
        }
        public void AddBookSerie(BookSerie item)
        {
            item.ID = Directory.GetFiles("Data/BookSeries/", "*.dsl", SearchOption.TopDirectoryOnly).Length + 1;
            item.ToDataSet().SaveData();
        }
        public BookSerie GetBookSerie(int ID)
        {
            return BookSerie.FromDataSet(new DataSet($"Data/BookSeries/{ID}.dsl"));
        }


        public void SaveExistComment(Comment item)
        {
            item.ToDataSet().SaveData();
        }
        public void AddComment(Comment item)
        {
            item.ID = Directory.GetFiles("Data/Comments/", "*.dsl", SearchOption.TopDirectoryOnly).Length + 1;
            item.ToDataSet().SaveData();
        }
        public Comment GetComment(int ID)
        {
            return Comment.FromDataSet(new DataSet($"Data/Comments/{ID}.dsl"));
        }


        public void SaveExistPublisher(Comment item)
        {
            item.ToDataSet().SaveData();
        }
        public void AddPublisher(Comment item)
        {
            item.ID = Directory.GetFiles("Data/Publishers/", "*.dsl", SearchOption.TopDirectoryOnly).Length + 1;
            item.ToDataSet().SaveData();
        }
        public Publisher GetPublisher(int ID)
        {
            return Publisher.FromDataSet(new DataSet($"Data/Publishers/{ID}.dsl"));
        }


        public void SaveExistRating(Rating item)
        {
            item.ToDataSet().SaveData();
        }
        public void AddRating(Rating item)
        {
            item.ID = Directory.GetFiles("Data/Ratings/", "*.dsl", SearchOption.TopDirectoryOnly).Length + 1;
            item.ToDataSet().SaveData();
        }
        public Rating GetRating(int ID)
        {
            return Rating.FromDataSet(new DataSet($"Data/Ratings/{ID}.dsl"));
        }


        public void SaveExistRent(Rent item)
        {
            item.ToDataSet().SaveData();
        }
        public void AddRent(Rent item)
        {
            item.ID = Directory.GetFiles("Data/Rents/", "*.dsl", SearchOption.TopDirectoryOnly).Length + 1;
            item.ToDataSet().SaveData();
        }
        public Rent GetRent(int ID)
        {
            return Rent.FromDataSet(new DataSet($"Data/Rents/{ID}.dsl"));
        }


        public void SaveExistStockAsset(StockAsset item)
        {
            item.ToDataSet().SaveData();
        }
        public void AddStockAsset(StockAsset item)
        {
            item.ID = Directory.GetFiles("Data/StockAssets/", "*.dsl", SearchOption.TopDirectoryOnly).Length + 1;
            item.ToDataSet().SaveData();
        }
        public StockAsset GetStockAsset(int ID)
        {
            return StockAsset.FromDataSet(new DataSet($"Data/StockAssets/{ID}.dsl"));
        }


        public void SaveExistUser(User item)
        {
            item.ToDataSet().SaveData();
        }
        public void AddUser(User item)
        {
            item.ID = Directory.GetFiles("Data/Users/", "*.dsl", SearchOption.TopDirectoryOnly).Length + 1;
            item.ToDataSet().SaveData();
        }
        public User GetUser(int ID)
        {
            return User.FromDataSet(new DataSet($"Data/Users/{ID}.dsl"));
        }
    }
}