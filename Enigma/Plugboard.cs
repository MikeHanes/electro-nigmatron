using Enigma.INTERFACES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class Plugboard : DoubleSidedDisc
    {

        public event EventHandler PinElectrified;

        public Plugboard(int numberOfConnections)
            : base(numberOfConnections)
        {
            for (int i = 0 ; i < numberOfConnections;i++)
            {
                //a simple plugboard just connects left to right
                Node.Connect(this.LeftDisc.Nodes[i], this.RightDisc.Nodes[i]);
    
                //hook up the electric current signal
                this.RightDisc.Nodes[i].Electrified += Output_Electrified;
            }
        }

        public void ElectrifyPin(int pinNumber)
        {
            this.RightDisc.Nodes[pinNumber].Electrify();
        }

        void Output_Electrified(object sender, EventArgs e)
        {
            //Raise that an electric signal was recieved
            var node = (INode)sender;

            int pin = this.RightDisc.Nodes.IndexOf(node);

            OnPinElectrified(pin);
           
        }


        private void OnPinElectrified(int pinNumber)
        {
            if (PinElectrified != null)
            {
                PinElectrified.Invoke(pinNumber, new EventArgs());
            }
        }

    }

    





}
