using Microsoft.AspNetCore.Mvc;
using PeladeirosfcApp.Services.interfaces;
using PeladeirosfcApp.Shared.ViewToApiDTO;

namespace PeladeirosfcApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Obtém uma lista paginada de usuários
        /// </summary>
        /// <param name="pageNumber">Número da página (padrão: 1)</param>
        /// <param name="pageSize">Tamanho da página (padrão: 10, máximo: 100)</param>
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<UsuarioDto>>> GetUsuarios(
            [FromQuery] int pageNumber = 1, 
            [FromQuery] int pageSize = 10)
        {
            var result = await _usuarioService.GetAllPaginatedAsync(pageNumber, pageSize);
            
            // Converte para DTO
            var dtoResult = new PaginatedResult<UsuarioDto>
            {
                Items = result.Items.Select(u => new UsuarioDto
                {
                    Nome = u.UserName,
                    Apelido = u.Apelido,
                    Email = u.Email,
                    DataNascimento = u.DataNascimento,
                    Genero = u.Genero,
                    FotoUrl = u.FotoUrl,
                    Cidade = u.Cidade,
                    Bairro = u.Bairro,
                    CEP = u.CEP,
                    Altura = u.Altura,
                    Peso = u.Peso,
                    TamanhoPe = u.TamanhoPe,
                    PeDominante = u.PeDominante,
                    Posicao = u.Posicao,
                    DataCriacao = u.DataCriacao,
                    DataAtualizacao = u.DataAtualizacao,
                    Telefone = u.PhoneNumber
                }).ToList(),
                PageNumber = result.PageNumber,
                PageSize = result.PageSize,
                TotalPages = result.TotalPages,
                TotalCount = result.TotalCount
            };

            return Ok(dtoResult);
        }

        /// <summary>
        /// Busca usuários por termo
        /// </summary>
        [HttpGet("search")]
        public async Task<ActionResult<PaginatedResult<UsuarioDto>>> SearchUsuarios(
            [FromQuery] string searchTerm,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var result = await _usuarioService.SearchAsync(searchTerm, pageNumber, pageSize);

            // Converte para DTO
            var dtoResult = new PaginatedResult<UsuarioDto>
            {
                Items = result.Items.Select(u => new UsuarioDto
                {
                    Nome = u.UserName,
                    Apelido = u.Apelido,
                    Email = u.Email,
                    DataNascimento = u.DataNascimento,
                    Genero = u.Genero,
                    FotoUrl = u.FotoUrl,
                    Cidade = u.Cidade,
                    Bairro = u.Bairro,
                    CEP = u.CEP,
                    Altura = u.Altura,
                    Peso = u.Peso,
                    TamanhoPe = u.TamanhoPe,
                    PeDominante = u.PeDominante,
                    Posicao = u.Posicao,
                    DataCriacao = u.DataCriacao,
                    DataAtualizacao = u.DataAtualizacao,
                    Telefone = u.PhoneNumber
                }).ToList(),
                PageNumber = result.PageNumber,
                PageSize = result.PageSize,
                TotalPages = result.TotalPages,
                TotalCount = result.TotalCount
            };

            return Ok(dtoResult);
        }

        /// <summary>
        /// Obtém um usuário específico por ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> GetUsuario(string id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);
            
            if (usuario == null) 
                return NotFound(new { message = $"Usuário com ID {id} não encontrado" });

            var dto = new UsuarioDto
            {
                Nome = usuario.UserName,
                Apelido = usuario.Apelido,
                Email = usuario.Email,
                DataNascimento = usuario.DataNascimento,
                Genero = usuario.Genero,
                FotoUrl = usuario.FotoUrl,
                Cidade = usuario.Cidade,
                Bairro = usuario.Bairro,
                CEP = usuario.CEP,
                Altura = usuario.Altura,
                Peso = usuario.Peso,
                TamanhoPe = usuario.TamanhoPe,
                PeDominante = usuario.PeDominante,
                Posicao = usuario.Posicao,
                DataCriacao = usuario.DataCriacao,
                DataAtualizacao = usuario.DataAtualizacao,
                Telefone = usuario.PhoneNumber
            };

            return Ok(dto);
        }

        /// <summary>
        /// Cria um novo usuário
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> CreateUsuario([FromBody] UsuarioDto usuarioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var usuario = await _usuarioService.CreateAsync(usuarioDto);

                var dto = new UsuarioDto
                {
                    Nome = usuario.UserName,
                    Apelido = usuario.Apelido,
                    Email = usuario.Email,
                    DataNascimento = usuario.DataNascimento,
                    Genero = usuario.Genero,
                    FotoUrl = usuario.FotoUrl,
                    Cidade = usuario.Cidade,
                    Bairro = usuario.Bairro,
                    CEP = usuario.CEP,
                    Altura = usuario.Altura,
                    Peso = usuario.Peso,
                    TamanhoPe = usuario.TamanhoPe,
                    PeDominante = usuario.PeDominante,
                    Posicao = usuario.Posicao,
                    DataCriacao = usuario.DataCriacao,
                    DataAtualizacao = usuario.DataAtualizacao,
                    Telefone = usuario.PhoneNumber
                };

                return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, dto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao criar usuário", error = ex.Message });
            }
        }

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(string id, [FromBody] UsuarioDto usuarioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var usuario = await _usuarioService.UpdateAsync(id, usuarioDto);
                
                if (usuario == null)
                    return NotFound(new { message = $"Usuário com ID {id} não encontrado" });

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao atualizar usuário", error = ex.Message });
            }
        }

        /// <summary>
        /// Remove um usuário
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(string id)
        {
            var result = await _usuarioService.DeleteAsync(id);
            
            if (!result)
                return NotFound(new { message = $"Usuário com ID {id} não encontrado" });

            return NoContent();
        }

        /// <summary>
        /// Verifica se um usuário existe
        /// </summary>
        [HttpHead("{id}")]
        [HttpGet("{id}/exists")]
        public async Task<IActionResult> UsuarioExists(string id)
        {
            var exists = await _usuarioService.ExistsAsync(id);
            return exists ? Ok(new { exists = true }) : NotFound(new { exists = false });
        }
    }
}