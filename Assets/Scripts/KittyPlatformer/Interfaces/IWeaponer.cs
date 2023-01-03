using UnityEngine;

namespace KittyPlatformer.Interfaces
{
    public interface IWeaponer
    {
        public int Damage { get; }
        public void Fire(float power);
        public void Rotate(Vector2 direction);
    }
}