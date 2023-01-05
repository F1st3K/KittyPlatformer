using System;
using KittyPlatformer.Base;
using UnityEngine;

namespace KittyPlatformer.Weapons
{
    public class Gun : RotatingWeapon
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private int countCollisionsBullet;
        
        public override void Fire(float power)
        {
            if (power <= 0)
                return;
            if (IsCouldown)
            {
                var vector3 = (Vector3) AttackPoint;
                vector3.z = bulletPrefab.transform.position.z;
                GameObject obj = Instantiate(bulletPrefab, vector3, Quaternion.identity);
                if (obj.TryGetComponent(out Bullet bullet))
                {
                    bullet.SetDamage(Convert.ToInt32(Damage * power));
                    bullet.SetCountCollisions(countCollisionsBullet);
                    bullet.SetOwner(Owner);
                }
                IsCouldown = false;
                ReloadingTimer.Start();
            }
            
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, innerRadius);
            Gizmos.DrawWireSphere(CreateAttackPoint(Vector2.right), 0.1f);
        }
    }
}