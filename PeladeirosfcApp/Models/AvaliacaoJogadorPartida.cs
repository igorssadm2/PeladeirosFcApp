namespace PeladeirosfcApp.Models
{
    public class AvaliacaoJogadorPartida
    {
        public Guid Id { get; set; }

        public Guid JogadorPartidaId { get; set; }
        public JogadorPartida? JogadorPartida { get; set; }

        public string? AvaliadorId { get; set; }
        public Usuario? Avaliador { get; set; }

        public int Nota { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    }

}
