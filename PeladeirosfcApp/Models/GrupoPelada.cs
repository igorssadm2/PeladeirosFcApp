using PeladeirosfcApp.Models.Enuns;

namespace PeladeirosfcApp.Models
{
    public class GrupoPelada
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string CriadorId { get; set; }
        public Usuario Criador { get; set; }

        public string Local { get; set; }
        public string TipoQuadra { get; set; }
        public string Configuracao { get; set; }

        public decimal ValorAvulso { get; set; }
        public decimal ValorMensal { get; set; }

        public IntensidadeJogo Intensidade { get; set; }

        public DayOfWeek DiaDoJogo { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        public ICollection<MembroGrupo> Membros { get; set; }
        public ICollection<Partida> Partidas { get; set; }
    }

}
