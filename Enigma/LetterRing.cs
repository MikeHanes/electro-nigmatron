using Enigma.INTERFACES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{

    public class LetterRing : IRotatable
    {

        public IList<Letter> Letters { get; set; }

        public Letter VisibleLetter { get; set; }
        private LetterRing()
        {
            this.Letters = new List<Letter>();
        }

        public static LetterRing FromAlphabet(string alphabet)
        {
            var ring = new LetterRing();

            foreach (char character in alphabet.ToCharArray())
            {
                ring.Letters.Add(new Letter() { Char = character });
            }

            Helpers.ListHelper.MakeOrdered<Letter>(ring.Letters);

            ring.VisibleLetter = ring.Letters.First();

            return ring;
        }

        public IRotatable MoveUp()
        {
            VisibleLetter = (Letter)VisibleLetter.Previous;

            OnVisibleLetterChanged();

            return this;
        }


        public IRotatable MoveDown()
        {
            VisibleLetter = (Letter)VisibleLetter.Next;

            OnVisibleLetterChanged();

            return this;
        }



        public event EventHandler VisibleLetterChanged;

        protected void OnVisibleLetterChanged()
        {
            if (VisibleLetterChanged != null)
            {
                VisibleLetterChanged.Invoke(this.VisibleLetter, new EventArgs());
            }
        }
    }

}
