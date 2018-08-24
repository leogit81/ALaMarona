namespace ALaMarona.Domain.Contracts
{
    public class UpdateProductRequest
    {
        public long IdProducto { get; set; }
        public string Descripcion { get; set; }
        public int Talle { get; set; }
        public long IdColor { get; set; }
    }
}
