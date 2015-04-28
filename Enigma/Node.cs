using Enigma.INTERFACES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class Node : INode
    {
        public IList<INode> ConnectedNodes { get; set; }
        public Object Parent { get; set; }
        public object Next { get; set; }
        public object Previous { get; set; }

        public Node(object parent)
        {
            this.ConnectedNodes = new List<INode>();
            this.Parent = parent;
        }

        public static void Connect(INode node1, INode node2)
        {
            if (!node1.ConnectedNodes.Contains(node2)) node1.ConnectedNodes.Add(node2);
            if (!node2.ConnectedNodes.Contains(node1)) node2.ConnectedNodes.Add(node1);
        }

        public static void Disconnect(INode node1, INode node2)
        {
            if (node1.ConnectedNodes.Contains(node2)) node1.ConnectedNodes.Remove(node2);
            if (node2.ConnectedNodes.Contains(node1)) node2.ConnectedNodes.Remove(node1);
        }



        public void Electrify()
        {
            Parallel.ForEach(this.ConnectedNodes, node => { node.ElectrifyFrom(this); });
        }


        public void ElectrifyFrom(INode callingNode)
        {
            OnElectrified();

            Parallel.ForEach(this.ConnectedNodes, node =>
            {
                if (node != callingNode) node.ElectrifyFrom(this);
            });
        }

        public event EventHandler Electrified;

        public void OnElectrified()
        {
            if (Electrified != null)
            {
                Electrified.Invoke(this, new EventArgs());
            }
        }


       
    }

}
