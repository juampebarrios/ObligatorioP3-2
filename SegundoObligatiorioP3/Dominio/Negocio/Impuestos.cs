using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Negocio
{
    [Table("Impuestos")]
    public class Impuestos
    {
        [Key]
        public int IdImpuesto { get; set; }
        public int ImpuestoIva { get; set; }
        public int ImpuestoDgi { get; set; }
        public int ImpuestoArancel { get; set; }
    }
}
