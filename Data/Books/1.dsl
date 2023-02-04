[DataSet]
;Book
int ID = 1
str name = "Ulak"
str description = "Orhan Gazi'nin Yalova Rum Beyi'ne gönderdiği elçiler geri dönmemektedir. Orhan Gazi, Sunguroğlu'nu çağırıp bu esrarengis olayı çözmesini ister. Sunguroğlu, Köse, ve İbrahim'i yanına alarak Yalova'ya yola koyulur. Ama daha yolda saldırılara uğrarlar, ilginç olaylarla karşılaşırlar. Yine gizli bir örgüt iş başındadır ve bir çok sürpriz onları beklemektedir. Sunguroğlu ve arkadaşları, Yalova'ya giden elçilerin esrarengiz bir şekilde kaybolmalarının sırrını çözmeye çalışırken, birbirinden ilginç ve oldukça hareketli olaylar baş döndürücü bir hızla gelişir..."
lnk author = @"Authors/1.dsl"
lnk publisher = @"Publishers/1.dsl"
lst tags = ["Orhan Gazi", "Sunguroğlu", "Yalova", "Osmanlı"]
lst types = ["Roman", "Tarihi Roman", "Aksiyon"]
lnk bookSerie = @""
lnk rating = @"Ratings/1.dsl"
lst likers = [@"Users/1.dsl"]
lst currentStocks = [@"StockAssets/1.dsl"]