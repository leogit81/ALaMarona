using System.Collections.Generic;

namespace ALaMaronaManager
{
    public static class FormModes
    {
        public const string NEW = "NEW";
        public const string VIEW = "VIEW";
        public const string EDIT = "EDIT";

        private static IDictionary<string, string> modeFormattedText;

        static FormModes()
        {
            modeFormattedText = new Dictionary<string, string>();
            modeFormattedText.Add(NEW, "Crear");
            modeFormattedText.Add(EDIT, "Editar");
            modeFormattedText.Add(VIEW, "Ver");
        }

        public static string GetFormattedText(string mode)
        {
            if (modeFormattedText.ContainsKey(mode))
            {
                return modeFormattedText[mode];
            }

            return null;
        }
    }
}
