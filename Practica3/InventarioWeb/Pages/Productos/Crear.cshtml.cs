using InventarioWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;

namespace InventarioWeb.Pages.Productos
{
    public class CrearModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        public string ErrorMessage { get; set; } = string.Empty;

        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public CrearModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync(
            string Nombre, string Categoria, string Descripcion,
            decimal Precio, int CantidadStock, DateTime? FechaVencimiento)
        {
            var producto = new Producto
            {
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
            var response = await client.PostAsync("api/productos", content);

            if (response.IsSuccessStatusCode)
                return RedirectToPage("/Index");

            ErrorMessage = "Ocurrió un error al guardar el producto.";
            return Page();
        }
    }
}