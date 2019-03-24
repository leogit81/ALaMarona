using Microsoft.Owin.Hosting;
using System;

namespace ALaMaronaOwinSelfHost
{
    public class Program
    {
        static void Main()
        {
            string port = "9000";
            string baseAddress = "http://localhost:{0}/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: string.Format(baseAddress, port)))
            {
                Console.WriteLine($"A La Marona Owin Self Host server started on port {port}.");
                Console.ReadLine();
            }
        }
    }
}
