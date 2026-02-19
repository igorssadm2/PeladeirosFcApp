using PeladeirosfcApp.Models;
using PeladeirosfcApp.Shared.ViewToApiDTO;

namespace PeladeirosfcApp.Services.interfaces
{
    /// <summary>
    /// Interface de serviço para gerenciamento de usuários
    /// </summary>
    public interface IUsuarioService
    {
        /// <summary>
        /// Obtém um usuário por ID
        /// </summary>
        Task<Usuario?> GetByIdAsync(string id);

        /// <summary>
        /// Obtém todos os usuários com paginação
        /// </summary>
        /// <param name="pageNumber">Número da página (começa em 1)</param>
        /// <param name="pageSize">Quantidade de itens por página</param>
        Task<PaginatedResult<Usuario>> GetAllPaginatedAsync(int pageNumber = 1, int pageSize = 10);

        /// <summary>
        /// Cria um novo usuário
        /// </summary>
        Task<Usuario> CreateAsync(UsuarioDto usuarioDto);

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        Task<Usuario?> UpdateAsync(string id, UsuarioDto usuarioDto);

        /// <summary>
        /// Remove um usuário
        /// </summary>
        Task<bool> DeleteAsync(string id);

        /// <summary>
        /// Verifica se um usuário existe
        /// </summary>
        Task<bool> ExistsAsync(string id);

        /// <summary>
        /// Busca usuários por termo (nome, apelido, email)
        /// </summary>
        Task<PaginatedResult<Usuario>> SearchAsync(string searchTerm, int pageNumber = 1, int pageSize = 10);
    }

    /// <summary>
    /// Classe para resultado paginado
    /// </summary>
    public class PaginatedResult<T>
    {
        public List<T> Items { get; set; } = new();
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
    }
}
