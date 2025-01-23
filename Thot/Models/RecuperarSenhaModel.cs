using System.ComponentModel.DataAnnotations;

namespace Thot.Models
{
    public class RecuperarSenhaModel
    {
        [Required(ErrorMessage = "Digite o Login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o E-mail")]
        public string Email { get; set; }
    }
}
