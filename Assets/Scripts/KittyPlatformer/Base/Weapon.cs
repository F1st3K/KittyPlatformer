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
        private protected LivingEntity Owner;

        public int Damage => damage;
        
        public virtual void Fire(Vector2 direction, float power){}

        private void Awake()
        {
            Owner = ComponentHolderProtocol.GetComponentInParent<LivingEntity>(gameObject);
            ReloadingTimer = new Timer(reloadTime);
            ReloadingTimer.Elapsed += (args, e) => 
                { IsCouldown = true; ReloadingTimer.Stop();};
            ReloadingTimer.Start();
        }
    }
}