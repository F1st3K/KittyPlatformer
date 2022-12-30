using KittyPlatformer.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace KittyPlatformer.Objects
{
    public class StatsCanvas : MonoBehaviour
    {
        [SerializeField] private LivingEntity entity;
        [SerializeField] private Image fillHealthBar;

        private void Awake()
        {
            (entity as ILiving).HealthChanged += UpdateHealthBar;
        }

        private void UpdateHealthBar()
        {
            fillHealthBar.fillAmount = (float)entity.HealthPoint / entity.MaxHealthPoint;
        }
    }
}