using Enigma.INTERFACES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class DoubleSidedDisc
    {
        public IDisc LeftDisc { get; set; }
        public IDisc RightDisc { get; set; }

        public DoubleSidedDisc(int numberOfConnections)
        {
            this.LeftDisc = new Disc(numberOfConnections); 
            this.RightDisc = new Disc(numberOfConnections);
        }
    }
}
