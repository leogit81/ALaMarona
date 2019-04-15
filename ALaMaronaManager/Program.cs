using ALaMarona.Core.DI;
using Ninject;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace ALaMaronaManager
{
    static class Program
    {
        static Program()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            DIContainer.Kernel = kernel;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IALaMaronaManagerFactory factory = (IALaMaronaManagerFactory)DIContainer.Kernel.GetService(typeof(IALaMaronaManagerFactory));

            Application.Run(new ALaMaronaManagerHome(factory));
        }
    }
}
