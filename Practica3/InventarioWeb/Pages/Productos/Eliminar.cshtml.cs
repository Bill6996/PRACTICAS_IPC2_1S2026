using InventarioWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace InventarioWeb.Pages.Productos
{
    public class EliminarModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        public Producto Producto { get; set; } = new();

        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public EliminarModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task OnGetAsync(int id)
        {
            var client = _clientFactory.CreateClient("InventarioAPI");
            var response = await client.GetAsync($"api/productos/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                Producto = JsonSerializer.Deserialize<Producto>(json, _jsonOptions) ?? new();
            }
        }

        public async Task<IActionResult> OnPostAsync(int Id)
        {
            var client = _clientFactory.CreateClient("InventarioAPI");
            await client.DeleteAsync($"api/productos/{Id}");
            return RedirectToPage("/Index");
        }
    }
}