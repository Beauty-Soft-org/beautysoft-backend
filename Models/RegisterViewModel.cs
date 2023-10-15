namespace Beautysoft.Models
{
    public class RegisterViewModel
    {
        public int Id { get; set; }
        public string NomeUsuario { get; set; } = string.Empty;
        public string EnderecoEmail { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public string ConfirmSenhaHash { get; set; } = string.Empty;
        public string Perfil { get; set; } = string.Empty;
    }
}
