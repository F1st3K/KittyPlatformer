using KittyPlatformer.Base;
using UnityEngine;

namespace KittyPlatformer.Interfaces
{
    public interface IAttacker
    {
        public IWeaponer Weapon { get; }
        public void Attack(float power);
        public void TakeAim(Vector2 direction);
        public Weapon ReplaceWeapon(Weapon obj);
    }
}