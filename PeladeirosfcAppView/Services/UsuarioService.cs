using PeladeirosfcApp.Shared.ViewToApiDTO;
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

        public async Task<List<UsuarioDto>> GetUsuariosAsync()
        {
            try
            {
                var result = await _http.GetFromJsonAsync<PaginatedResult<UsuarioDto>>("api/usuarios");
                return result?.Items ?? new List<UsuarioDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar usuários: {ex.Message}");
                return new List<UsuarioDto>();
            }
        }

        public async Task<UsuarioDto?> GetUsuarioAsync(string id)
        {
            return await _http.GetFromJsonAsync<UsuarioDto>($"api/usuarios/{id}");
        }

        public async Task<UsuarioDto> CreateUsuarioAsync(UsuarioDto usuarioDto)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/usuarios", usuarioDto);
                response.EnsureSuccessStatusCode();

                var responseDto = await response.Content.ReadFromJsonAsync<UsuarioDto>()
                    ?? throw new Exception("Erro ao criar usuário");

                return responseDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private class PaginatedResult<T>
        {
            public List<T> Items { get; set; } = new();
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
            public int TotalPages { get; set; }
            public int TotalCount { get; set; }
        }

        public async Task UpdateUsuarioAsync(string id, UsuarioDto usuario)
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