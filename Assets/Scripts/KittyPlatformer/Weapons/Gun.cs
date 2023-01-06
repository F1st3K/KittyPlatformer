using System;
using KittyPlatformer.Base;
using UnityEngine;

namespace KittyPlatformer.Weapons
{
    public class Gun : RotatingWeapon
    {
        [SerializeField] private GameObject bulletPrefab;
        
        public override void Fire(float power)
        {
            if (power <= 0)
                return;
            var vector3 = (Vector3) AttackPoint;
            vector3.z = bulletPrefab.transform.position.z;
            GameObject obj = Instantiate(bulletPrefab, vector3, CreateAttackAngle(RotationVector2));
            if (obj.TryGetComponent(out Bullet bullet))
            {
                bullet.SetDirection(RotationVector2);
                bullet.SetDamage(Convert.ToInt32(Damage * power));
                bullet.SetOwner(Owner);
            }
            IsCouldown = false;
            ReloadingTimer.Start();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, innerRadius);
            Gizmos.DrawWireSphere(CreateAttackPoint(Vector2.right), 0.1f);
        }
    }
}