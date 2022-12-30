using System.Timers;
using KittyPlatformer.Interfaces;
using UnityEngine;

namespace KittyPlatformer.Base
{
    public abstract class Weapon : MonoBehaviour, IWeaponer
    {
        [SerializeField] private int damage;
        [SerializeField] private protected double reloadTime;
        private protected Timer ReloadingTimer;
        private protected bool IsCouldown;

        public int Damage => damage;
        
        public virtual void Fire(Vector2 direction, float power){}

        private void Awake()
        {
            ReloadingTimer = new Timer(reloadTime);
            ReloadingTimer.Elapsed += (args, e) => 
                { IsCouldown = true; ReloadingTimer.Stop();};
            ReloadingTimer.Start();
        }
    }
}