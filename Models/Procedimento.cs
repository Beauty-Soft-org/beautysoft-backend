using Beautysoft.Enum;

namespace Beautysoft.Models
{
    public class Procedimento
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public double Valor { get; set; } 
        public string InserirArquivo { get; set; } = string.Empty;
        public TipoProc TipoProcedimento { get; set; }
    }
}
