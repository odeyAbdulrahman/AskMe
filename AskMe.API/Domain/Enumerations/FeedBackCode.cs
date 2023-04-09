namespace AskMe.API.Domain.Enumerations
{
    public enum FeedBackCode
    {
        Processed = 1001,
        OK = 2000,
        Created = 2001,
        Updated = 2002,
        Deleted = 2003,
        Archived = 2004,
        Actived = 2005,
        Recoverd = 2006,
        Restored = 2007,
        Uploaded = 2008,
        Sended = 2011,
        FileDownloaded = 2012,
        NotCreated = 3001,
        NotUpdated = 3002,
        NotDeleted = 3003,
        NotArchived = 3004,
        NotActived = 3005,
        NotRecoverd = 3006,
        NotRestored = 3007,
        NotUploaded = 3008,
        NotSended = 4001,
        NotFound = 4004,
        NullOrEmpty = 4005,
        LargeSize = 4006,
        IsNotImage = 4007,
        IsNotFile = 4008,
        ValidationNotValid = 4009,
        NotAccept = 4010
    }
}
