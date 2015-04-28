using Enigma.INTERFACES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Helpers
{
    public static class ListHelper
    {
        public static void MakeOrdered<T>(IList<T> list) where T : IOrdered
        {
            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];

                if (!item.Equals(list.Last()))
                {
                    item.Next = list[i + 1];
                }
                if (!item.Equals(list.First()))
                {
                    item.Previous = list[i - 1];
                }
            }
            list.First().Previous = list.Last();
            list.Last().Next = list.First();

           
        }
    }
}
