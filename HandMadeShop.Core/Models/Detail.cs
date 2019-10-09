namespace HandMadeShop.Core.Models
{
    public class Detail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }

        public Detail Parent { get; set; }
    }
}