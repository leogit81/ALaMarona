using System.Collections.Generic;

namespace ALaMarona.Domain.Entities
{
    //TODO: ESTO DEBERIA IR A UNA TABLA A LA BASE DE DATOS
    public static class EstadoCivil
    {
        private static IList<string> tipos;

        public static bool IsValid(string estadoCivil)
        {
            return tipos.Contains(estadoCivil);
        }

        static EstadoCivil()
        {
            tipos = new List<string>();

            tipos.Add("Soltero/a");
            tipos.Add("Casado/a");
            tipos.Add("Viudo/a");
            tipos.Add("Divorciado/a");
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