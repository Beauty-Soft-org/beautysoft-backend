namespace Beautysoft.Models
{
    public class LoginViewModel
    {
        public string NameUsuario { get; set; } = string.Empty;
        public string EnderecoEmail { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public string ConfirmSenha { get; set; } = string.Empty;
    }
}
