using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

#nullable disable // Para quitar el aviso de nulls

namespace PantallaOne.Models
{
    public class Articulos // Entidad Articulo
    {
        [Key]
        public int ArticuloId { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre del articulo.")]
        public string Nombre { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }

        [Required(ErrorMessage = "Campo categoria es obligatorio.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Seleccione la categoria del articulo.")]
        public int CategoriaId { get; set; }

        [Required]
        [Range(1, float.MaxValue, ErrorMessage = "Ingrese la cantidad del articulo.")]
        public double Cantidad { get; set; }

        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Ingrese un costo mayor a 0.")]
        public decimal Costo { get; set; }

        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Ingrese un precio mayor a 0.")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "Campo ITBIS es obligatorio.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Seleccione el % de ITBIS.")]
        public float ITBIS { get; set; } = 0.18f;
        public int SuplidorId { get; set; }
        public string NombreSuplidor { get; set; }


        //-------------------------------------------------------------------------------------

        [ForeignKey("SuplidorId")]
        public virtual Suplidor Suplidor { get; set; }

        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }

        [ForeignKey("ArticuloId")]
        public List<VentasDetalle> VentasDetalle { get; set; }

        public Articulos()
        {
            ArticuloId = 0;
            SuplidorId = 0;
            NombreSuplidor = string.Empty;
            Nombre = string.Empty;
            FechaCreacion = DateTime.Now;
            Cantidad = 0;
            Costo = 0;
            Precio = 0;

            VentasDetalle = new List<VentasDetalle>();
        }
    }
}