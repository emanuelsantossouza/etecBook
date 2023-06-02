using System.ComponentModel.DataAnnotations;

namespace EtecBookApi.DataTransferObjects
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Informe o nome")]
        [StringLength(60, ErrorMessage = "O nome deve possuir no maximo 60 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email requirido")]
        [EmailAddress(ErrorMessage ="Informe um email valido")]
        [StringLength(100, ErrorMessage = "O nome deve possuir no maximo 60 caracteres")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Informe a senha")]
        [StringLength(20,MinimumLength =6, ErrorMessage = "O nome deve possuir no maximo 60 caracteres")]
        public string Password { get; set; }

    }
}