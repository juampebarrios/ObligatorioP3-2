using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Dominio
{
    [Table("Planta")]
    public class Planta
    {
        [Key]
        public int IdPlanta { get; set; }

        [Required]
        public string NombreCientifico { get; set; }

        [Required]
        public string NombreVulgar { get; set ; }

        [Required, StringLength(200, MinimumLength = 10)]
   
        public string Descripcion { get; set; }

        [Required]
        public string Ambiente { get; set; }

        [Required]
        public double AlturaMax { get; set; }

        [Required]
        public string Foto { get; set; }

        [Required]
        public double Precio { get; set; }


        public int IdTipoPlanta { get; set; }

        [ForeignKey("IdTipoPlanta")]
        public TipoPlanta MiTipoPlanta { get; set; }




    }
}

