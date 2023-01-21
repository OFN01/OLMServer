namespace OLMServer.OLMData.Enums
{
    public enum UserLevel
    {
        Default = 0,
        Renter = 1,
        Manager = 2,
        Admin = 3,
    }

    public enum PunishmentStatus
    {
        None = 0,
        RentTimeout = 1,
        RentLost = 2,
        TakeWithoutRent = 3,
    }
}
