using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Controllers
{
    class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string? _baseUrl;

        public ApiService(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _baseUrl = apiSettings.Value.BaseUrl;
        }

        public async Task<string> GetDataAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/endpoint");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }

    public class ApiSettings
    {
        public string BaseUrl { get; set; }
    }
}
