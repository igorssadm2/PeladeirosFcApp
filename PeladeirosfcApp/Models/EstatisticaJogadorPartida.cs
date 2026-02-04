namespace PeladeirosfcApp.Models
{
    public class EstatisticaJogadorPartida
    {
        public Guid Id { get; set; }

        public Guid JogadorPartidaId { get; set; }
        public JogadorPartida? JogadorPartida { get; set; }

        public int Gols { get; set; }
        public int Assistencias { get; set; }
        public int Desarmes { get; set; }
        public int Defesas { get; set; }
    }

}