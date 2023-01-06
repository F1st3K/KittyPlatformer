using KittyPlatformer.Interfaces;
using KittyPlatformer.Objects;
using Unity.VisualScripting;
using UnityEngine;
using Timer = System.Timers.Timer;

namespace KittyPlatformer.Base
{
    public abstract class Weapon : MonoBehaviour, IWeaponer
    {
        [SerializeField] private int damage;
        [SerializeField] private protected double reloadTime;
        private protected Timer ReloadingTimer;
        private protected bool IsCouldown;
        private protected Vector2 AttackPoint;
        private protected LivingEntity Owner;

        public int Damage => damage;
        public virtual Vector2 RotationVector2 => Vector2.zero;
        public void SetOwner()
        {
            Owner = ComponentHolderProtocol.GetComponentInParent<LivingEntity>(gameObject);
        }

        public abstract void Fire(float power);
        public abstract void Rotate(Vector2 direction);

        private protected virtual void Awake()
        {
            SetOwner();
            ReloadingTimer = new Timer(reloadTime);
            ReloadingTimer.Elapsed += (args, e) => 
                { IsCouldown = true; ReloadingTimer.Stop();};
            ReloadingTimer.Start();
        }
    }
}