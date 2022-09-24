using System.ComponentModel.DataAnnotations;

namespace WebApiAcmeEncuestasV1.Models
{
    public class Encuesta
    {
        public int Id { get; set; }
        [Required]
        public string nombreEncuesta { get; set; }
        [Required]
        public string descripcionEncuesta { get; set; }

        public List<CamposEncuesta> Campos { get; set; }
    }
}
