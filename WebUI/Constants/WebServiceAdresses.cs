using static System.Net.WebRequestMethods;

namespace WebUI.Constants
{
    public class WebServiceAdresses
    {
        public const string categoryApi= "https://localhost:7034/api/Category";
        public static readonly string categoryIdApi= "https://localhost:7034/api/Category/{id}";
        public static readonly string categoryGetByIdApi= "https://localhost:7034/api/Category/GetAboutById/{id}";
    }
}
