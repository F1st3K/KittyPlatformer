using System;
using KittyPlatformer.Interfaces;
using UnityEngine;

namespace KittyPlatformer.Objects
{
    public class DieSpace : MonoBehaviour
    {
        [SerializeField] private int overDamage;
        
        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out ILiving entity))
                entity.GetDamage(overDamage);
        }
    }
}