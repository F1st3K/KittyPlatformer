namespace KittyPlatformer.Interfaces
{
    public interface IWallet
    {
        public int CountResources { get; }
        public int MaxResources { get; }
        public void AddResources(int value);
        public void SpendResources(int value);
    }
}