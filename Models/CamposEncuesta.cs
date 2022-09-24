using System.ComponentModel.DataAnnotations;

namespace WebApiAcmeEncuestasV1.Models
{
    public class CamposEncuesta
    {
        public int id { get; set; }
       
        [Required]
        public string nombreCampo { get; set; }
        [Required]
        public string tituloCampo { get; set; }
        [Required]
        public Boolean requerido { get; set; }
        [Required]
        public string tipoCampo { get; set; }
    }
}
