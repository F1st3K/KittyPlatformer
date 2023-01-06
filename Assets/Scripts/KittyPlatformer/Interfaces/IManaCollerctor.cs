using UnityEngine;

namespace KittyPlatformer.Interfaces
{
    public interface IManaCollerctor
    {
        public int CountMana { get; }
        public void OnTriggerEnter2D(Collider2D other);
    }
}