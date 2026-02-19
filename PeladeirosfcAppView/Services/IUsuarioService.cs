using PeladeirosfcAppView.Models;

namespace PeladeirosfcAppView.Services
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> GetUsuariosAsync();
        Task<Usuario?> GetUsuarioAsync(string id);
        Task<Usuario> CreateUsuarioAsync(Usuario usuario);
        Task UpdateUsuarioAsync(string id, Usuario usuario);
        Task DeleteUsuarioAsync(string id);
    }
}