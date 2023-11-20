namespace Beautysoft.Models
{
    public class Agendamento
    {
        public int Id { get; set; }        
        public DateTime DataHoraAgendada { get; set; }

        public Procedimento Procedimento { get; set; }
    }
}
