using InventarioWeb.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace InventarioWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        public List<Producto> Productos { get; set; } = new();

        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public IndexModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task OnGetAsync()
        {
            var client = _clientFactory.CreateClient("InventarioAPI");
            var response = await client.GetAsync("api/productos");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                Productos = JsonSerializer.Deserialize<List<Producto>>(json, _jsonOptions)
                            ?? new List<Producto>();
            }
        }
    }
}