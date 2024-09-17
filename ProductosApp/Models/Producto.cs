using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductosApp.Models
{
    public class Producto
    {
        [Key]
        public int NoProducto { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
        public string Nombre { get; set; }

        [StringLength(200, ErrorMessage = "La descripción no puede tener más de 200 caracteres")]
        public string Descripcion { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock debe ser un número positivo")]
        [Required(ErrorMessage = "El stock es obligatorio")]
        public int Stock { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0")]
        [Required(ErrorMessage = "El precio es obligatorio")]
        [DataType(DataType.Currency)]
        public decimal Precio { get; set; }

        // Relación con Categorias
        [Required(ErrorMessage = "La categoría es obligatoria")]
        public int NoCategoria { get; set; }

        [ForeignKey("NoCategoria")]
        public Categoria Categoria { get; set; }
    }
}
