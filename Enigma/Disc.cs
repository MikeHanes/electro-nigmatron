using Enigma.INTERFACES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class Disc : IDisc
    {
        public List<INode> Nodes { get; set; }

        public  Disc(int numberOfConnections)
        {
            this.Nodes = new List<INode>();

            //create nodes
            for (var i = 0; i < numberOfConnections; i++ )
            {
                Nodes.Add(new Node(this));
            }

            Helpers.ListHelper.MakeOrdered<INode>(this.Nodes);
        }

        public static void Connect(IDisc disc1, IDisc disc2)
        {
            if (disc1.Nodes.Count != disc2.Nodes.Count) throw new Exception("Your discs dont have the same number of connections!");
           
            for (int i = 0; i < disc1.Nodes.Count;i++ )
            {
                Node.Connect(disc1.Nodes[i], disc2.Nodes[i]);
            }
        }

       
       
    }
}
