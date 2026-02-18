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
            var response = await _http.PostAsJsonAsync("api/usuarios", usuario);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Usuario>() 
                ?? throw new Exception("Erro ao criar usuário");
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