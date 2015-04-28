using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class Lightboard
    {
        private Lightboard() { }

        private List<char> lamps = new List<char>();

        public static Lightboard FromAlphabet(string alphabet)
        {
            var lightboard = new Lightboard();
            foreach (char lamp in alphabet.ToCharArray())
            {
                lightboard.lamps.Add(lamp);
            }

            return lightboard;
        }

        public void LightLamp(int pinNumber)
        {
            OnLampOn(lamps[pinNumber]);
        }

        public event EventHandler LampOn;

        public void OnLampOn(char lamp)
        {
            if (LampOn != null)
            {
                LampOn.Invoke(lamp, new EventArgs());
            }
        }
    }
}
