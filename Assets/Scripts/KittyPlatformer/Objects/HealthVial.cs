using KittyPlatformer.Base;
using KittyPlatformer.Interfaces;
using UnityEngine;

namespace KittyPlatformer.Objects
{
    public sealed class HealthVial : StateVariableEntity
    {
        [SerializeField] private int countHealth;
        
        private protected override void OnActivate()
        {
            if (Entity is ILiving liver)
            {
                liver.GetHealth(countHealth);
                Destroy(gameObject);
            }
            DeActivate();
        }
    }
}