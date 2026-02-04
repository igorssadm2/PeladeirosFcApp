using PeladeirosfcApp.Models.Enuns;

namespace PeladeirosfcApp.Models
{
    public class MembroGrupo
    {
        public Guid Id { get; set; }

        public Guid GrupoPeladaId { get; set; }
        public GrupoPelada GrupoPelada { get; set; }

        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public TipoMembroGrupo Tipo { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataEntrada { get; set; } = DateTime.UtcNow;
    }

}