using static System.Net.WebRequestMethods;

namespace WebUI.Constants
{
    public class WebServiceAdresses
    {
        public const string categoryApi= "https://localhost:7034/api/Category";
        public static readonly string categoryIdApi= "https://localhost:7034/api/Category/{id}";
        public static readonly string categoryGetByIdApi= "https://localhost:7034/api/Category/GetCategoryById/{id}";

        public const string productApi = "https://localhost:7034/api/Product";
        public static readonly string productIdApi = "https://localhost:7034/api/Product/{id}";
        public static readonly string productGetByIdApi = "https://localhost:7034/api/Product/GetProductById/{id}";
        public static readonly string productGetWithCategoryApi = "https://localhost:7034/api/Product/ProductListWithCategory";

        public const string aboutApi = "https://localhost:7034/api/About";
        public const string aboutGetByIdApi = "https://localhost:7034/api/About/GetAboutById/{id}";
    }
}
