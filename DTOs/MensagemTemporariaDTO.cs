

using Beautysoft.Enum;

namespace Beautysoft.DTOs
{
    public class MensagemTemporariaDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Habilitado { get; set; } = string.Empty;
        public TipoMensagemTemporaria TipoMensagemTemporaria { get; set; }
    }
}
