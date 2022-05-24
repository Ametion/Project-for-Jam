using System;

namespace Model.Armor
{
    public class Armor : IArmor 
    {
        public int Durability { get; private set; }
        public int MaxDurability { get; private set; }

        public string PeaceOfArmor { get; set; }

        public int Protection { get; set; }
        public int MaxProtection { get; set; }

        public Armor(string peaceOfArmor, int protection)
        {
            PeaceOfArmor = peaceOfArmor;
            Protection = protection;
        }
    }
}