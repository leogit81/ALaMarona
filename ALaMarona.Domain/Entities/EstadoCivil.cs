using System.Collections.Generic;

namespace ALaMarona.Domain.Entities
{
    public class EstadoCivil
    {
        private static IList<string> tipos;

        public string Descripcion { get; set; }

        static EstadoCivil()
        {
            tipos = new List<string>();

            tipos.Add("Soltero/a");
            tipos.Add("Casado/a");
            tipos.Add("Viudo/a");
            tipos.Add("Divorciado/a");
        }

        public static IList<string> GetCodigos()
        {
            return tipos;
        }

        public static string Soltero
        {
            get
            {
                return tipos[0];
            }
        }

        public static string Casado
        {
            get
            {
                return tipos[1];
            }
        }

        public static string Viudo
        {
            get
            {
                return tipos[2];
            }
        }

        public static string Divorciado
        {
            get
            {
                return tipos[3];
            }
        }
    }
}