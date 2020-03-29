namespace GoodsLogistics.Auth.Services.Interfaces
{
    public interface ICookiesService
    {
        void SetCookie(
            string key, 
            string value, 
            int? expireTimeInSeconds = null);

        string GetCookieByKey(string key);

        void RemoveCookie(string key);
    }
}
