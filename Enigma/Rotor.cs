using Enigma.INTERFACES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class Rotor : DoubleSidedDisc , IRotatable 
    {
        public Rotor(int numberOfConnections)  : base(numberOfConnections)
        {

        }

        public LetterRing LetterRing { get; set; }


        public IRotatable MoveUp()
        {
            this.LetterRing.MoveUp();

            this.ReconnectUp(this.LeftDisc);
            this.ReconnectUp(this.RightDisc);
            return this;
        }

        public IRotatable MoveDown()
        {
            this.LetterRing.MoveDown();

            this.ReconnectDown(this.LeftDisc);
            this.ReconnectDown(this.RightDisc);

            return this;
        }

        private void ReconnectUp(IDisc disk)
        {
            Parallel.ForEach(disk.Nodes, node =>
            {
                var outsideNode = node.ConnectedNodes.First(n => n.Parent != node.Parent);
                Node.Disconnect(node, outsideNode);
                Node.Connect(node, (INode)outsideNode.Next);
            });
        }

        private void ReconnectDown(IDisc disk)
        {
            Parallel.ForEach(disk.Nodes, node =>
            {
                var outsideNode = node.ConnectedNodes.First(n => n.Parent != node.Parent);
                Node.Disconnect(node, outsideNode);
                Node.Connect(node, (INode)outsideNode.Previous);
            });
        }

    }
}
