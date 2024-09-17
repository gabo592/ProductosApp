namespace ProductosApp.Models
{
    public class ProductoViewModel
    {
        public Producto Producto { get; set; }  // Para el formulario de creación/edición
        public List<Producto> ListaProductos { get; set; }  // Para la tabla
        public List<Categoria> Categorias { get; set; }
    }
}
