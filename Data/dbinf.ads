[DataSet]
str type = "DataBaseInfo"
str name = "MyDataBase"

lst tables = ["Users", "Books"]
lnk UsersTBL = @"Users/tableinf.ads"
lnk BooksTBL = @"Books/tableinf.ads"