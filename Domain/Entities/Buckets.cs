namespace Api_BoxCenter.Domain.Entities
{
    public class Buckets
    {
        public int IdBucket { get; set; }
        public int EmpresaId {  get; set; }
        public int CreadoPorUserId { get; set; }
        public string Nombre { get; set; }
        public bool EsPublico { get; set; } = true;
        public DateTime FechaCreacion { get; set; }

        public Empresa Empresa { get; set; } = null!;
        public Usuario CreateByUsuario { get; set; } = null!;
        public ICollection<Folder> Folders { get; set; } = new List<Folder>();


    }

}
