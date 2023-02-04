[DataSet]
;StockAsset
int ID = 1
lnk book = @"Books/1.dsl"
lgc isDamaged = F
lgc isRented = True
lst rentHistory = [@"Rents/1.dsl"]
lnk rentUser = @"Users/1.dsl"