using System;

namespace Model
{
    [Serializable]
    public class PlayerDataModel
    {
        public int Coins;
        public int HP;

        public void SetDefoultValues()
        {
            Coins = 0;
            HP = 3;
        }
    }
}