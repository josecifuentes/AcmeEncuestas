using System.ComponentModel.DataAnnotations;
using WebApiAcmeEncuestasV1.Models;

namespace WebApiAcmeEncuestasV1.ViewModels
{
    public class EncuestaVM
    {
    }
    public class EncuestaWithCamposVM
    {
        public int Id { get; set; }
        [Required]
        public string nombreEncuesta { get; set; }
        [Required]
        public string descripcionEncuesta { get; set; }

        public List<String> Campos { get; set; }
    }
}
