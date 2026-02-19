namespace PeladeirosfcAppView.Models
{
    public class Usuario
    {
        public string Id { get; set; } = string.Empty;
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Apelido { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Genero { get; set; }
        public string? PeDominante { get; set; }
        public string? Posicao { get; set; }
        public string? FotoPerfilUrl { get; set; }
    }
}