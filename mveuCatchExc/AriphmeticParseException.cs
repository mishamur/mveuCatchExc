using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mveuCatchExc
{
    public class AriphmeticParseException : Exception
    {

        public AriphmeticParseException(string message) : base(message)
        {
            
        }
    }
}
