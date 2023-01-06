using System;

namespace KittyPlatformer.Interfaces
{
    public interface IWallet
    {
        public int CountResources { get; }
        public int MaxResources { get; }
        public event Action CountChanged;
        public void AddResources(int value);
        public void SpendResources(int value);
    }
}