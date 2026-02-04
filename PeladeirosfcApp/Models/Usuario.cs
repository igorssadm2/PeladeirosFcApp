namespace PeladeirosfcApp.Models
{

    using Microsoft.AspNetCore.Identity;

    public class Usuario : IdentityUser
    {
        public string? Nome { get; set; } = null!;
        public string? Apelido { get; set; }

        public DateTime? DataNascimento { get; set; }
        public string? Genero { get; set; }
        public string? FotoUrl { get; set; }
        public string? Cidade { get; set; }
        public string? Bairro { get; set; }
        public string? CEP { get; set; }

        public decimal? Altura { get; set; }
        public decimal? Peso { get; set; }
        public int? TamanhoPe { get; set; }
        public string? PeDominante { get; set; }
        public string? Posicao { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime? DataAtualizacao { get; set; }


        // Construtor de conveniência para inicializar campos comuns
       
    }

}
