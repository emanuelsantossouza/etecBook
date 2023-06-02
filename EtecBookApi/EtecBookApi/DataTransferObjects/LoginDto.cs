using System.ComponentModel.DataAnnotations;

namespace EtecBookApi.DataTransferObjects
{
    // O Dto é o que a gente enviar para a api infez de ser direto o model
    public class LoginDto
    {
        [Required(ErrorMessage = "Email ou Nome de Usuário requirido")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "A senha é requerida")]
        public string Password { get; set; }

    }
}