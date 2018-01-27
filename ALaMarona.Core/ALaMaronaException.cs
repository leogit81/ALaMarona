using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALaMarona.Core
{
    public class ALaMaronaException: Exception
    {
        public ALaMaronaException(string message): base(message)
        {
            
        }

        public ALaMaronaException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
