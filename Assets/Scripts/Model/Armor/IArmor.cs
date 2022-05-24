using Model.Abstract;

namespace Model.Armor
{
    public interface IArmor : IDurabilities
    {
        string PeaceOfArmor { get; }
        int Protection { get; set; }
        int MaxProtection { get; set; }
    }
}