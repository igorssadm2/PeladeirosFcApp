using PeladeirosfcApp.Shared.ViewToApiDTO;

namespace PeladeirosfcAppView.Services
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDto>> GetUsuariosAsync();
        Task<UsuarioDto?> GetUsuarioAsync(string id);
        Task<UsuarioDto> CreateUsuarioAsync(UsuarioDto usuario);
        Task UpdateUsuarioAsync(string id, UsuarioDto usuario);
        Task DeleteUsuarioAsync(string id);
    }
}