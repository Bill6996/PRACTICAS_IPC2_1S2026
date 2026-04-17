using System.Text.Json;
using InventarioAPI.Models;

namespace InventarioAPI.Services
{
    public class ProductoService
    {
        private readonly string _filePath;
        private readonly JsonSerializerOptions _jsonOptions;

        public ProductoService()
        {
            _filePath = Path.Combine(AppContext.BaseDirectory, "inventario.json");
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
        }

        private List<Producto> LeerProductos()
        {
            if (!File.Exists(_filePath))
                return new List<Producto>();

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Producto>>(json, _jsonOptions)
                   ?? new List<Producto>();
        }

        private void GuardarProductos(List<Producto> productos)
        {
            var json = JsonSerializer.Serialize(productos, _jsonOptions);
            File.WriteAllText(_filePath, json);
        }

        public List<Producto> ObtenerTodos() => LeerProductos();

        public Producto? ObtenerPorId(int id) =>
            LeerProductos().FirstOrDefault(p => p.Id == id);

        public Producto Crear(Producto producto)
        {
            var productos = LeerProductos();
            producto.Id = productos.Count > 0 ? productos.Max(p => p.Id) + 1 : 1;
            productos.Add(producto);
            GuardarProductos(productos);
            return producto;
        }

        public Producto? Actualizar(int id, Producto productoActualizado)
        {
            var productos = LeerProductos();
            var index = productos.FindIndex(p => p.Id == id);
            if (index == -1) return null;

            productoActualizado.Id = id;
            productos[index] = productoActualizado;
            GuardarProductos(productos);
            return productoActualizado;
        }

        public bool Eliminar(int id)
        {
            var productos = LeerProductos();
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null) return false;

            productos.Remove(producto);
            GuardarProductos(productos);
            return true;
        }
    }
}