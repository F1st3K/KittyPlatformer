using UnityEngine;

namespace KittyPlatformer.Interfaces
{
    public interface ICoinCollector
    {
        public IWallet CoinWallet { get; }
        public void OnTriggerEnter2D(Collider2D other);
    }
}