namespace Beautysoft.DTOs
{
    public class RegistroDto
    {
        public required string NomeUsuario { get; set; } = string.Empty;
        public required string EnderecoEmail { get; set; } = string.Empty;
        public required string Senha { get; set; } = string.Empty;
    }
}
