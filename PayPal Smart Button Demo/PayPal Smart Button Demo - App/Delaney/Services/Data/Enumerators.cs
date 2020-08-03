namespace Delaney.Services.Data
{
    // https://en.wikipedia.org/wiki/List_of_HTTP_status_codes
    public enum DataStoreResult
    {
        Failed_ChildDependency = -1,
        Failed = 0,
        Success = 200,
        NotFound = 404 
    }

    public enum SignInResult
    {
        Failed = 0,
        Succeeded = 1,
        Expired,
        EmailNotConfirmed,
        IsLockedOut,
        IsNotAllowed,
    }
}