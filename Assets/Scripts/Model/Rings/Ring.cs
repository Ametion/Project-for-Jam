using System;

namespace Model.Rings
{
    public class Ring : IRing
    {
        public int Durability { get; private set; }
        public int MaxDurability { get; private set; }

        public string Element { get; set; }

        public Ring(string element)
        {
            Element = element;
        }
    }
}