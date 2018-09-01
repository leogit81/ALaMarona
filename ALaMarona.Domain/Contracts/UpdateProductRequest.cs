using ALaMarona.Domain.Generic;

namespace ALaMarona.Domain.Contracts
{
    public class UpdateProductRequest: IUpdateRequest<long>
    {
        public long IdProducto { get; set; }
        public string Descripcion { get; set; }
        public int Talle { get; set; }
        public long IdColor { get; set; }
        public long Id
        {
            get
            {
                return IdProducto;
            }

            set
            {
                IdProducto = value;
            }
        }
    }
}
