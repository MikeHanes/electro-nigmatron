using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class Keyboard
    {
        private Keyboard() { }

        private List<char> keys = new List<char>();

        public static Keyboard FromAlphabet(string alphabet)
        {
            var keyboard = new Keyboard();
            foreach (char character in alphabet.ToCharArray())
            {
                keyboard.keys.Add(character);
            }

            return keyboard;
        }

        public void PressKey(char key)
        {

            OnKeyPressed(keys.IndexOf(key));

        }

        public event EventHandler KeyPressed;

        protected void OnKeyPressed(int pinNumber)
        {
            if (KeyPressed != null)
            {
                KeyPressed.Invoke(pinNumber, new EventArgs());
            }

        }
    }
}
