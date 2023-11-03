using Beautysoft.Enum;

namespace Beautysoft.Models
{
    public class MensagemTemporariaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Habilitado { get; set; } = string.Empty;
        public TipoMensagemTemporaria TipoMensagemTemporaria { get; set; }


    }
}
