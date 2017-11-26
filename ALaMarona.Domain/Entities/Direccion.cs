using Eg.Core;

namespace ALaMarona.Domain.Entities
{
    public class Direccion: Entity<long>
    {
        public virtual string Calle { get; set; }
        public virtual int Altura { get; set; }
        public virtual string Piso { get; set; }
        public virtual string Departamento { get; set; }
        public virtual string CodigoPostal { get; set; }
        public virtual Pais Pais { get; set; }
        public virtual Provincia Provincia {get;set;}
        public virtual Localidad Localidad { get; set; }
    }
}
