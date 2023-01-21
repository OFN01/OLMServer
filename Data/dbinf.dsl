[DataSet]
str type = "DataBaseInfo"
str name = "MyDataBase"

lst tables = ["Users", "Books"]
lnk UsersTBL = @"Users/tableinf.dsl"
lnk BooksTBL = @"Books/tableinf.dsl"