using Enigma.INTERFACES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class Letter : IOrdered
    {
        public char Char { get; set; }

        public object Next {get;set;}
        public object Previous { get; set; }
        
    }
}
