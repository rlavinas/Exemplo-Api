using System.ComponentModel.DataAnnotations;

namespace ChapterAPI.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-mail obrigatório.")]
        [EmailAddress(ErrorMessage = "Valor informado não é um e-mail válido.")]
        [Display(Name = "E-mail")]
        public string? Email { get; set; }
        
        [Required(ErrorMessage = "Senha obrigatória")]
        [StringLength(10,ErrorMessage = "Informar senha no máximo de 10 e mínimo de 6 caracetres.", MinimumLength = 6)]
        [Display(Name = "Senha")]
        public string? Senha { get; set; }
    }
}
