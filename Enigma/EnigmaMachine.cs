using Enigma.INTERFACES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class EnigmaMachine 
    {
        private EnigmaMachine()
        {
            Rotors = new List<Rotor>();
        }

        //Left these public for testing (so you can manually 'Electrify' their nodes)
        public IDisc ReflectorDisc { get; set; }
        public IList<Rotor> Rotors { get;private set; }
        public Plugboard Plugboard { get;private set; }


        public static EnigmaMachine Create()
        {
            return new EnigmaMachine();
        }

        public void InsertRotor(Rotor rotor)
        {
            if (ReflectorDisc == null) throw new Exception("You need to insert the reflector disc first!");

            this.Rotors.Add(rotor);

            if (this.Rotors.Count == 1)
            {
                //The first rotor needs to connect to the reflector
                Disc.Connect(ReflectorDisc, rotor.LeftDisc);
            }
            else
            {
                //just connect to the right disk of the previous rotor to the left disk of this rotor
                var rightDisk = Rotors[Rotors.Count - 2].RightDisc;
                Disc.Connect(rotor.LeftDisc, rightDisk);
            }

        }

        public void InsertPlugboard(Plugboard plugboard)
        {
            this.Plugboard = plugboard;
            Disc.Connect(Rotors.Last().RightDisc, this.Plugboard.LeftDisc);
        }


        

       
    }
}
