using InventarioWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;

namespace InventarioWeb.Pages.Productos
{
    public class EditarModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        public Producto Producto { get; set; } = new();
        public string ErrorMessage { get; set; } = string.Empty;

        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public EditarModel(IHttpClientFactory clientFactory)
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

        public async Task<IActionResult> OnPostAsync(
            int Id, string Nombre, string Categoria, string Descripcion,
            decimal Precio, int CantidadStock, DateTime? FechaVencimiento)
        {
            var producto = new Producto
            {
                Id = Id,
                Nombre = Nombre,
                Categoria = Categoria,
                Descripcion = Descripcion,
                Precio = Precio,
                CantidadStock = CantidadStock,
                FechaVencimiento = FechaVencimiento
            };

            var client = _clientFactory.CreateClient("InventarioAPI");
            var json = JsonSerializer.Serialize(producto, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"api/productos/{Id}", content);

            if (response.IsSuccessStatusCode)
                return RedirectToPage("/Index");

            ErrorMessage = "Ocurrió un error al actualizar el producto.";
            return Page();
        }
    }
}