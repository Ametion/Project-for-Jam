using Model.Abstract;

namespace Model.Rings
{
    public interface IRing : IDurabilities
    {
        string Element { get; set; }
    }
}