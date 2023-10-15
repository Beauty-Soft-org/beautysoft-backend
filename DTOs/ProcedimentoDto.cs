using Beautysoft.Enum;

namespace Beautysoft.DTOs
{
    public class ProcedimentoDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public double Valor { get; set; }
        public string InserirArquivo { get; set; } = string.Empty;
        public TipoProc TipoProcedimento { get; set; }
    }
}
