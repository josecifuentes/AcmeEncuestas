using System.ComponentModel.DataAnnotations;

namespace WebApiAcmeEncuestasV1.Models
{
    public class LlenarEncuesta
    {
        public int id { get; set; }
        [Required]
        public int NoLlenado { get; set; }

        [Required]
        public int IdCampo { get; set; }
        public string Datos { get; set; }
    }
}
