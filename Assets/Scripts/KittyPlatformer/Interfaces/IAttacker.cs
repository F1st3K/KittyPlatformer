using KittyPlatformer.Base;
using KittyPlatformer.Wallets;
using UnityEngine;

namespace KittyPlatformer.Interfaces
{
    public interface IAttacker
    {
        public IWeaponer Weapon { get; }
        public IWallet ManaWallet { get; }
        public void Attack(float power);
        public void TakeAim(Vector2 direction);
        public Weapon ReplaceWeapon(Weapon obj);
    }
}