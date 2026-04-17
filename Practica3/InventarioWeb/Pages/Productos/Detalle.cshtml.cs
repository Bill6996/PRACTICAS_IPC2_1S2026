using InventarioWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace InventarioWeb.Pages.Productos
{
    public class DetalleModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        public Producto? Producto { get; set; }

        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public DetalleModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var client = _clientFactory.CreateClient("InventarioAPI");
            var response = await client.GetAsync($"api/productos/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                Producto = JsonSerializer.Deserialize<Producto>(json, _jsonOptions);
                return Page();
            }

            return RedirectToPage("/Index");
        }
    }
}