namespace DevIO.Business.Models.Base
{
    public interface IAppIdentityUser
    {
        string GetUsername();
        Guid GetUserId();
        bool IsAuthenticated();
        bool IsInRole(string role);
        string GetRemoteIpAddress();
        string GetLocalIpAddress();
    }
}
