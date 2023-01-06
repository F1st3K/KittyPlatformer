using UnityEngine;

namespace KittyPlatformer.Interfaces
{
    public interface IManaCollerctor
    {
        public IWallet ManaWallet { get; }
        public void OnTriggerEnter2D(Collider2D other);
    }
}