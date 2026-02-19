using Microsoft.EntityFrameworkCore;
using PeladeirosfcApp.Data;
using PeladeirosfcApp.Models;
using PeladeirosfcApp.Services.interfaces;
using PeladeirosfcApp.Shared.ViewToApiDTO;

namespace PeladeirosfcApp.Services
{
    public class UsuarioServices : IUsuarioService
    {
        private readonly ApplicationDbContext _context;

        public UsuarioServices(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém um usuário por ID
        /// </summary>
        public async Task<Usuario?> GetByIdAsync(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        /// <summary>
        /// Obtém todos os usuários com paginação
        /// </summary>
        public async Task<PaginatedResult<Usuario>> GetAllPaginatedAsync(int pageNumber = 1, int pageSize = 10)
        {
            // Validação de parâmetros
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;
            if (pageSize > 100) pageSize = 100; // Limite máximo

            var totalCount = await _context.Users.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var items = await _context.Users
                .OrderBy(u => u.UserName)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedResult<Usuario>
            {
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalCount = totalCount
            };
        }

        /// <summary>
        /// Cria um novo usuário
        /// </summary>
        public async Task<Usuario> CreateAsync(UsuarioDto usuarioDto)
        {
            var usuario = new Usuario
            {
                Id = Guid.NewGuid().ToString(),
                UserName = usuarioDto.Email,
                NormalizedUserName = usuarioDto.Email?.ToUpper(),
                Email = usuarioDto.Email,
                NormalizedEmail = usuarioDto.Email?.ToUpper(),
                EmailConfirmed = false,
                PhoneNumber = usuarioDto.Telefone,
                Apelido = usuarioDto.Apelido,
                DataNascimento = usuarioDto.DataNascimento,
                Genero = usuarioDto.Genero,
                FotoUrl = usuarioDto.FotoUrl,
                Cidade = usuarioDto.Cidade,
                Bairro = usuarioDto.Bairro,
                CEP = usuarioDto.CEP,
                Altura = usuarioDto.Altura,
                Peso = usuarioDto.Peso,
                TamanhoPe = usuarioDto.TamanhoPe,
                PeDominante = usuarioDto.PeDominante,
                Posicao = usuarioDto.Posicao,
                DataCriacao = DateTime.UtcNow,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            _context.Users.Add(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        public async Task<Usuario?> UpdateAsync(string id, UsuarioDto usuarioDto)
        {
            var usuario = await _context.Users.FindAsync(id);
            if (usuario == null)
                return null;

            // Atualiza apenas os campos que podem ser modificados
            usuario.Apelido = usuarioDto.Apelido;
            usuario.DataNascimento = usuarioDto.DataNascimento;
            usuario.Genero = usuarioDto.Genero;
            usuario.FotoUrl = usuarioDto.FotoUrl;
            usuario.Cidade = usuarioDto.Cidade;
            usuario.Bairro = usuarioDto.Bairro;
            usuario.CEP = usuarioDto.CEP;
            usuario.Altura = usuarioDto.Altura;
            usuario.Peso = usuarioDto.Peso;
            usuario.TamanhoPe = usuarioDto.TamanhoPe;
            usuario.PeDominante = usuarioDto.PeDominante;
            usuario.Posicao = usuarioDto.Posicao;
            usuario.DataAtualizacao = DateTime.UtcNow;

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ExistsAsync(id))
                    return null;
                throw;
            }

            return usuario;
        }

        /// <summary>
        /// Remove um usuário
        /// </summary>
        public async Task<bool> DeleteAsync(string id)
        {
            var usuario = await _context.Users.FindAsync(id);
            if (usuario == null)
                return false;

            _context.Users.Remove(usuario);
            await _context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Verifica se um usuário existe
        /// </summary>
        public async Task<bool> ExistsAsync(string id)
        {
            return await _context.Users.AnyAsync(u => u.Id == id);
        }

        /// <summary>
        /// Busca usuários por termo (nome, apelido, email)
        /// </summary>
        public async Task<PaginatedResult<Usuario>> SearchAsync(string searchTerm, int pageNumber = 1, int pageSize = 10)
        {
            // Validação de parâmetros
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;
            if (pageSize > 100) pageSize = 100;

            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var lowerSearchTerm = searchTerm.ToLower();
                query = query.Where(u =>
                    (u.UserName != null && u.UserName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                    (u.Email != null && u.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                    (u.Apelido != null && u.Apelido.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                );
            }

            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var items = await query
                .OrderBy(u => u.UserName)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedResult<Usuario>
            {
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalCount = totalCount
            };
        }
    }
}

