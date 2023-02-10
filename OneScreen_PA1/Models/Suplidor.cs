using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable // Para quitar el aviso de nulls

namespace PantallaOne.Models
{
    public class Suplidor // Entidad suplidor
    {
        [Key]
        public int SuplidorId { get; set; }

        [Required(ErrorMessage = "Ingrese un nombre del suplidor.")]
        public string NombreSuplidor { get; set; }

        [Required(ErrorMessage = "Ingrese la dirección del suplidor.")]
        public string Dirección { get; set; }

        [Required(ErrorMessage = "Campo email es requerido.")]
        [RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Formato inválido. name@gmail.com")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ingrese un numero teléfonico del suplidor.")]
        [RegularExpression(@"^\d{3}[- ]?\d{3}[- ]?\d{4}$", ErrorMessage = "Formato inválido. 000-000-0000")]
        public string Telefono { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }
        public int ArticuloId { get; set; }
        public string Nombre { get; set; }

        public Suplidor()
        {
            SuplidorId = 0;
            NombreSuplidor = string.Empty;
            Nombre = string.Empty;
            Email = string.Empty;
            Telefono = string.Empty;
            Dirección = string.Empty;
            FechaIngreso = DateTime.Now;
        }
    }
}