using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guar
{
    // Item with nothing
    public class ItemNull : IItem
    {
        public int Weight => 0;

        public int Value => 0;

        public string Name => "null";

        public string inEngineName => "null";

        public bool Found { get => false; set => Found = value; }

        public ItemNull(IItem i)
        {
            i = new ItemNull(i);
        }
    }
}
