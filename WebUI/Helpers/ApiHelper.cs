namespace WebUI.Helpers
{
    public class ApiHelper
    {
        public static string ConfigureApiUrl(string urlTemplate, int id)
        {
            return urlTemplate.Replace("{id}", id.ToString());
        }
    }
}
