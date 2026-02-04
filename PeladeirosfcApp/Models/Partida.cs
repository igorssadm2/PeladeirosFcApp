namespace PeladeirosfcApp.Models
{
    public class Partida
    {
        public Guid Id { get; set; }

        public Guid? GrupoPeladaId { get; set; }
        public GrupoPelada? GrupoPelada { get; set; }

        public DateTime DataPartida { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }

        public bool Finalizada { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        public ICollection<JogadorPartida>? Jogadores { get; set; }
    }

}