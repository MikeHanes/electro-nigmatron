using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.INTERFACES
{
    public interface IRotatable
    {
        IRotatable MoveUp ();
        IRotatable MoveDown();
    }
}
