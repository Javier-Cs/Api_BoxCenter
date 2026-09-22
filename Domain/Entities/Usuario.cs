using Api_BoxCenter.Domain.Enums;

namespace Api_BoxCenter.Domain.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public int EmpresaId { get; set; }
        public string NombreUser { get; set; } = string.Empty;
        public Rol Rol { get; set; }
        public string Email {  get; set; } = string.Empty;
        public string PassHash { get; set; } = string.Empty;
        public string UrlImgUser { get; set; } = string.Empty;
        public bool EstadoUser { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }

        // Navegacion
        public Empresa Empresa { get; set; } = null!;

        public ICollection<Sessiones> Sessiones { get; set; } = new List<Sessiones>();
        public ICollection<Buckets> Buckets { get; set; } = new List<Buckets>();
    }
}