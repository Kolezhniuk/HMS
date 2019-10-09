namespace HandMadeShop.Core.ModelAbstractions
{
    public abstract class IDictionaryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
    }
}