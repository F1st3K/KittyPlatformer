using System;
using KittyPlatformer.Base;
using UnityEngine;

namespace KittyPlatformer.Enemy
{
    public sealed class Enemy : AttackerEntity
    {
        [SerializeField] private float visibilityRadius;

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, visibilityRadius);
        }
    }
}