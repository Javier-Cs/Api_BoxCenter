namespace Api_BoxCenter.Domain.Entities
{
    public class Empresa
    {
        public int IdEmpresa { get; set; }
        public string NombreEmpresa { get; set; } = string.Empty;
        public string UrlImgEmpresa { get; set; } = string.Empty;
        public bool EstadoEmpresa { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public DateTime FechaCreacionEmpresa { get; set; }
        public DateTime FechaModificacion {  get; set; }


        // Navegacion
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public ICollection<Buckets> Buckets { get; set; } = new List<Buckets>();
    }
}
