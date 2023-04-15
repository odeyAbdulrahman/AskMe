using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace AskMe.APP.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory HttpClient;
        public IEnumerable<Question>? Data { get; private set; }

        public IndexModel(IHttpClientFactory httpClient)
        {
            HttpClient = httpClient;
        }

        public async void OnGet()
        {
            Data = JsonSerializer.Deserialize<IEnumerable<Question>?>(await SendAsync("AskMe.API", "/api/Questions"), new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true});
        }
        #region HttpClient Factory
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<string> SendAsync(string name, string requestUrl)
        {
            var httpClient = HttpClient.CreateClient(name);
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            var response = await httpClient.SendAsync(
             request, HttpCompletionOption.ResponseHeadersRead).
             ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        #endregion
    }
}