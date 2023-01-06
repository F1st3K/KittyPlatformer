using UnityEngine;

namespace KittyPlatformer.Interfaces
{
    public interface ICoinCollector
    {
        public int CountCoin { get; }
        public void OnTriggerEnter2D(Collider2D other);
    }
}