namespace ALaMaronaManager
{
    public interface IALaMaronaManagerFactory
    {
        ClienteFormContext CrearClienteFormContext();
        PedidoFormContext CrearPedidoFormContext();
    }
}
