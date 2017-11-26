using System.Collections.Generic;
using System.Linq;

namespace ALaMarona.Domain.Entities
{
    public class Documento
    {
        private static IList<string> tipos;

        public string Tipo { get; set; }
        public long Numero { get; set; }

        static Documento()
        {
            tipos = new List<string>();

            tipos.Add("DNI");
            tipos.Add("CUIT");
            tipos.Add("CUIL");
            //otros que vayan surgiendo
        }

        public static IList<string> GetCodigos()
        {
            return tipos;
        }

        public static string DNI
        {
            get
            {
                return tipos[0];
            }
        }

        public static string CUIT
        {
            get
            {
                return tipos[1];
            }
        }

        public static string CUIL
        {
            get
            {
                return tipos[2];
            }
        }
    }
}