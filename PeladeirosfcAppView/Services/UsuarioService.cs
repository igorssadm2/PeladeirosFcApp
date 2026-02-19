using PeladeirosfcAppView.Models;
using System.Net.Http.Json;

namespace PeladeirosfcAppView.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly HttpClient _http;

        public UsuarioService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            try
            {
                var usuarios = await _http.GetFromJsonAsync<List<Usuario>>("api/usuarios");
                return usuarios ?? new List<Usuario>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar usuários: {ex.Message}");
                return new List<Usuario>();
            }
        }

        public async Task<Usuario?> GetUsuarioAsync(string id)
        {
            return await _http.GetFromJsonAsync<Usuario>($"api/usuarios/{id}");
        }

        public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
        {
            // Cria o DTO para enviar à API
            var usuarioDto = new
            {
                Email = usuario.Email,
                Telefone = usuario.PhoneNumber,
                Apelido = usuario.Apelido,
                DataNascimento = usuario.DataNascimento,
                Genero = usuario.Genero,
                PeDominante = usuario.PeDominante,
                Posicao = usuario.Posicao
            };

            var response = await _http.PostAsJsonAsync("api/usuarios", usuarioDto);
            response.EnsureSuccessStatusCode();
            
            // A API retorna um DTO, então precisamos ler e converter
            var responseDto = await response.Content.ReadFromJsonAsync<UsuarioDto>() 
                ?? throw new Exception("Erro ao criar usuário");
            
            // Converte o DTO de volta para o modelo Usuario
            return new Usuario
            {
                Id = Guid.NewGuid().ToString(), // Temporário, idealmente a API deveria retornar o ID
                UserName = responseDto.Nome,
                Email = responseDto.Email,
                PhoneNumber = responseDto.Telefone,
                Apelido = responseDto.Apelido,
                DataNascimento = responseDto.DataNascimento,
                Genero = responseDto.Genero,
                PeDominante = responseDto.PeDominante,
                Posicao = responseDto.Posicao
            };
        }

        private class UsuarioDto
        {
            public string? Nome { get; set; }
            public string? Apelido { get; set; }
            public string? Email { get; set; }
            public string? Telefone { get; set; }
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
            public DateTime DataCriacao { get; set; }
            public DateTime? DataAtualizacao { get; set; }
        }

        public async Task UpdateUsuarioAsync(string id, Usuario usuario)
        {
            var response = await _http.PutAsJsonAsync($"api/usuarios/{id}", usuario);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteUsuarioAsync(string id)
        {
            var response = await _http.DeleteAsync($"api/usuarios/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}