using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.INTERFACES
{
    public interface IOrdered
    {
        object Next { get; set; }
        object Previous { get; set; }
    }
}
