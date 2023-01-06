namespace KittyPlatformer.Interfaces
{
    public interface IItem
    {
        public int Count { get; }
        public void Collect();
    }
}