using System.ComponentModel.DataAnnotations;

namespace ProductosApp.Models
{
    public class Categoria
    {
        [Key]
        public int NoCategoria { get; set; }

        [Required(ErrorMessage = "El nombre de la categoría es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
        public string Nombre { get; set; }

        [StringLength(200, ErrorMessage = "La descripción no puede tener más de 200 caracteres")]
        public string Descripcion { get; set; }

        // Relación con Productos
        public List<Producto> Productos { get; set; }
    }
}
