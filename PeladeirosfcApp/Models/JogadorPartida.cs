namespace PeladeirosfcApp.Models
{
    public class JogadorPartida
    {
        public Guid Id { get; set; }

        public Guid PartidaId { get; set; }
        public Partida? Partida { get; set; }

        public string? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public bool Presente { get; set; }
        public DateTime? DataConfirmacao { get; set; }

        public EstatisticaJogadorPartida? Estatistica { get; set; }
    }

}