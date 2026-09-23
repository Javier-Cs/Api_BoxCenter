namespace Api_BoxCenter.Domain.Entities
{
    public class Permisos
    {
        public int IdPermisos { get; set; }
        public int? IdBucket { get; set; }
        public int? IdFolder { get; set; }
        public int IdUsuario { get; set; }
        public int? IdFile { get; set; }

        public bool CantRead { get; set; } = false;
        public bool CantWrite { get; set; } = false;
        public bool CantDelete { get; set; } = false;
        public bool Canmanager { get; set; } = false;
        public DateTime FechaCreacion { get; set; }

        public Buckets? Buckets { get; set; }
        public Folder? Folder { get; set; }
        public Usuario usuario { get; set; } = null!;
        public Files? File { get; set; } 



    }
}
