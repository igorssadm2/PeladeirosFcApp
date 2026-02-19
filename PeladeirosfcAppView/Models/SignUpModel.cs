using System.ComponentModel.DataAnnotations;

namespace PeladeirosfcAppView.Models;

public class SignUpModel
{
    [Required(ErrorMessage = "Nome de usuário é obrigatório")]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email é obrigatório")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    public string Email { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }
    public string? Apelido { get; set; }
    public DateTime? DataNascimento { get; set; }
    public string? Genero { get; set; }
    public string? PeDominante { get; set; }
    public string? Posicao { get; set; }
}