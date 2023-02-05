namespace OLMServer.OLMData.Enums
{
    public enum UserLevel
    {
        Default = 0,
        Renter = 1,
        Manager = 2,
        Admin = 3,
    }

    public enum PenaltyReason
    {
        Other = 0,
        LostBook = 1,
        DamageBook = 2,
        ReturnTimeout = 3,
        TakeWithoutRent = 4
    }

    public enum PenaltyType
    {
        PayWithBook = 0,
        PayWithMoney = 1,
        BanForDays = 2,
        BanUntilADate = 3
    }
}
