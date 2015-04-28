using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.HARNESS
{
    class Program
    {
        static EnigmaMachine enigmaMachine;

        static void Main(string[] args)
        {
            enigmaMachine = EnigmaMachine.Create();

            //create reflector disc
            var reflector = new Disc(6);

            //connect the reflector nodes
            Node.Connect(reflector.Nodes[0], reflector.Nodes[3]);
            Node.Connect(reflector.Nodes[1], reflector.Nodes[5]);
            Node.Connect(reflector.Nodes[2], reflector.Nodes[4]);


            //add reflector to machine (must do this before adding rotors)
            enigmaMachine.ReflectorDisc = reflector;

            //create two rotors (could add as many as we like)
            var r1 = new Rotor(6);
            var r2 = new Rotor(6);

            //manually connect rotor nodes
            Node.Connect(r1.LeftDisc.Nodes[0], r1.RightDisc.Nodes[3]);
            Node.Connect(r1.LeftDisc.Nodes[1], r1.RightDisc.Nodes[1]);
            Node.Connect(r1.LeftDisc.Nodes[2], r1.RightDisc.Nodes[2]);
            Node.Connect(r1.LeftDisc.Nodes[3], r1.RightDisc.Nodes[0]);
            Node.Connect(r1.LeftDisc.Nodes[4], r1.RightDisc.Nodes[4]);
            Node.Connect(r1.LeftDisc.Nodes[5], r1.RightDisc.Nodes[5]);

            Node.Connect(r2.LeftDisc.Nodes[0], r2.RightDisc.Nodes[0]);
            Node.Connect(r2.LeftDisc.Nodes[1], r2.RightDisc.Nodes[5]);
            Node.Connect(r2.LeftDisc.Nodes[2], r2.RightDisc.Nodes[4]);
            Node.Connect(r2.LeftDisc.Nodes[3], r2.RightDisc.Nodes[2]);
            Node.Connect(r2.LeftDisc.Nodes[4], r2.RightDisc.Nodes[3]);
            Node.Connect(r2.LeftDisc.Nodes[5], r2.RightDisc.Nodes[1]);

            //create a couple of letter rings and move move them around a bit...
            var lr1 = LetterRing.FromAlphabet("ABCDEF"); lr1.MoveUp().MoveUp();
            var lr2 = LetterRing.FromAlphabet("ABCDEF"); lr2.MoveDown().MoveDown().MoveDown();

            //output when we move the rotor
            lr1.VisibleLetterChanged += letterRing_VisibleLetterChanged;
            lr2.VisibleLetterChanged += letterRing_VisibleLetterChanged;


            //fix the letter rings onto our rotors
            r1.LetterRing = lr1;
            r2.LetterRing = lr1;

            //insert rotors into machine
            enigmaMachine.InsertRotor(r1);
            enigmaMachine.InsertRotor(r2);

            //create a (default node mapping) plugboard and insert into machine
            enigmaMachine.InsertPlugboard(new Plugboard(6));

            //test the letter rings (moving the rotor should change letter rings visible rotors)
            r1.MoveUp().MoveUp().MoveUp().MoveUp().MoveUp();

            //create a keyboard and lampboard - these are not part of the "machine" as such.  Hook up with events
            var keyboard = Keyboard.FromAlphabet("ABCDEF");
            var lampboard = Lightboard.FromAlphabet("ABCDEF");

            keyboard.KeyPressed += (sender, e) =>
                {
                    int pin = (int)sender;
                    enigmaMachine.Plugboard.ElectrifyPin(pin);
                };

            enigmaMachine.Plugboard.PinElectrified += (sender, e) =>
                {
                    lampboard.LightLamp((int)sender);
                };

            lampboard.LampOn += (sender, e) =>
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" => {0}", (char)sender);
                };


            Console.WriteLine("Enter a character to be encoded, or a rotor number to move");
            while (1 == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                char inputKey = Console.ReadKey(false).KeyChar;

                int intInput;
                if (int.TryParse(inputKey.ToString(), out intInput))
                {
                    Console.WriteLine("Rotating rotor {0}", intInput);
                    enigmaMachine.Rotors[intInput].MoveDown();
                }
                else
                {
                    keyboard.PressKey(char.ToUpper(inputKey));
                }


            }

        }

        static void letterRing_VisibleLetterChanged(object sender, EventArgs e)
        {
            Console.Write("Letter ringa showing: ");
            foreach (var rotor in enigmaMachine.Rotors)
            {
                Console.Write(rotor.LetterRing.VisibleLetter.Char);
            }
            Console.WriteLine();
        }




    }
}
