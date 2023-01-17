using KittyPlatformer.Interfaces;
using KittyPlatformer.Objects;
using KittyPlatformer.Wallets;
using UnityEngine;

namespace KittyPlatformer.Base
{
    public abstract class AttackerEntity : LivingEntity, IAttacker
    {
        [SerializeField] private Weapon weapon;
        [SerializeField] private protected ManaWallet manaWallet;

        public IWeaponer Weapon => weapon;
        public IWallet ManaWallet => manaWallet;

        public void Attack(float power)
        {
            if (manaWallet.CountResources >= weapon.ShotPrice &&
                weapon.IsCouldown &&
                power > 0)
            {
                weapon.Fire(power);
                manaWallet.SpendResources(weapon.ShotPrice);
            }
        }
        
        public void TakeAim(Vector2 direction)
        {
            if (direction != Vector2.zero)
            {
                weapon.Rotate(direction);
                Rotate(transform.position + (Vector3) direction);
            }
        }

        public Weapon ReplaceWeapon(Weapon obj)
        {
            if (obj is not null)
            {
                (weapon.transform.position, obj.transform.position) =
                    (obj.transform.position, weapon.transform.position);
                obj.Rotate(((RotatingWeapon) weapon).RotationVector2);
                weapon.Rotate(Vector2.right);
                (obj.transform.parent, weapon.transform.parent) = 
                    (weapon.transform.parent, obj.transform.parent);
                (weapon, obj) = (obj, weapon);
                weapon.SetOwner();
            }
            return obj;
        }
    }
}