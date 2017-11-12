using System;
using System.Configuration;
using System.Web;

namespace AdgisticsShoppingKart
{
    public static class CookieFactory
    {
        public static string GetShoppingCartCookie(HttpRequestBase request, HttpResponseBase response)
        {
            if (request == null || response == null)
                return String.Empty;

            string cookieName = ConfigurationManager.AppSettings["shoppingCartCookieName"];

            if (String.IsNullOrEmpty(cookieName))
                cookieName = "shoppingCartCookie";

            HttpCookie cookie = request.Cookies[cookieName];

            // Check if this cookie exists
            if (cookie != null)
                return cookie.Value; // Return the current cookie Guid

            // Otherwise, create a new cookie
            HttpCookie newCookie = SetShoppingCartCookie(cookieName);

            // Add the cookie
            response.Cookies.Add(newCookie);

            // Return the new cookie Guid
            return newCookie.Value;
        }

        private static HttpCookie SetShoppingCartCookie(string cookieName)
        {
            HttpCookie shoppingCartCookie = new HttpCookie(cookieName);

            Guid guid = Guid.NewGuid();

            // Set the cookie value
            shoppingCartCookie.Value = guid.ToString();

            // Set the cookie expiration date
            shoppingCartCookie.Expires = DateTime.Now.AddDays(2);

            return shoppingCartCookie;
        }
    }
}