using System;
using System.ComponentModel.DataAnnotations;

namespace PeladeirosfcApp.Shared.ViewToApiDTO
{
    public class UsuarioDto
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres")]
        public string? Nome { get; set; }
        
        [StringLength(50, ErrorMessage = "Apelido deve ter no máximo 50 caracteres")]
        public string? Apelido { get; set; }
        
        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [StringLength(255, ErrorMessage = "Email deve ter no máximo 255 caracteres")]
        public string? Email { get; set; }
        
        public DateTime? DataNascimento { get; set; }
        public string? Genero { get; set; }
        public string? FotoUrl { get; set; }
        public string? Cidade { get; set; }
        public string? Bairro { get; set; }
        public string? CEP { get; set; }
        public string? Telefone { get; set; }

        public decimal? Altura { get; set; }
        public decimal? Peso { get; set; }
        public int? TamanhoPe { get; set; }
        public string? PeDominante { get; set; }
        public string? Posicao { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime? DataAtualizacao { get; set; }
    }
}