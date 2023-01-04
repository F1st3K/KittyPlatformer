using KittyPlatformer.Base;
using UnityEngine;

namespace KittyPlatformer.Weapons
{
    public class Gun : RotatingWeapon
    {
        public override void Fire(float power)
        {
            throw new System.NotImplementedException();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, innerRadius);
            Gizmos.DrawWireSphere(CreateAttackPoint(Vector2.right), 0.1f);
        }
    }
}