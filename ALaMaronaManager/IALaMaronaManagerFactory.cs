using ALaMaronaManager.DI;

namespace ALaMaronaManager
{
    public interface IALaMaronaManagerFactory
    {
        FormContext CreateFormContext();
        ClienteFormContext CrearClienteFormContext();
    }
}
