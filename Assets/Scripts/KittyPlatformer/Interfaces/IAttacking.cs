using UnityEngine;

namespace KittyPlatformer.Interfaces
{
    public interface IAttacking
    {
        public IWeaponer Weapon { get; }
        public void Attack(Vector2 direction, float power);

    }
}