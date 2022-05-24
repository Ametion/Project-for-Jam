using Model.Armor;
using Model.Rings;

namespace Model
{
    [System.Serializable]
    public class PlayerProtectionModel
    {
        public Armor.Armor Helmet;
        public Armor.Armor Chestplate;
        public Armor.Armor Pants;
        public Armor.Armor Boots;

        public Ring firstRing;
        public Ring secondRing;
        public Ring thirdRing;
    }
}