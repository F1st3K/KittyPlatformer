using System;
using KittyPlatformer.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace KittyPlatformer.Objects
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private LivingEntity entity;
        [SerializeField] private Image fillHealthBar;

        private ILiving _liver;
        
        private void Awake()
        {
            _liver = (ILiving) entity;
            _liver.HealthChanged += UpdateHealthBar;
        }
        
        private void UpdateHealthBar()
        {
            fillHealthBar.fillAmount = (float)_liver.HealthPoint / _liver.MaxHealthPoint;
        }
    }
}