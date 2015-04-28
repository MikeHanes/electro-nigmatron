using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.INTERFACES
{
    public interface INode : IOrdered, IChild
    {
        IList<INode> ConnectedNodes  { get; set; }

        void ElectrifyFrom(INode callingNode);
        void Electrify();

        event EventHandler Electrified;

        void OnElectrified(); 

    }
}
