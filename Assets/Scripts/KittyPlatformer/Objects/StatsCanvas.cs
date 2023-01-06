using KittyPlatformer.Base;
using KittyPlatformer.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KittyPlatformer.Objects
{
    public class StatsCanvas : MonoBehaviour
    {
        [SerializeField] private Interactor entity;
        [SerializeField] private Image fillHealthBar;
        [SerializeField] private Image fillManaBar;
        [SerializeField] private TextMeshPro textCoinCounter;

        private ILiving _liver;
        private IManaCollerctor _maner;
        private ICoinCollector _coiner;
        
        private void Awake()
        {
            _liver = (ILiving) entity;
            _maner = (IManaCollerctor) entity;
            _coiner = (ICoinCollector) entity;
            _liver.HealthChanged += UpdateHealthBar;
            _maner.ManaWallet.CountChanged += UpdateManaBar;
            _coiner.CoinWallet.CountChanged += UpdateCoinText;
        }

        private void UpdateHealthBar()
        {
            fillHealthBar.fillAmount = (float)_liver.HealthPoint / _liver.MaxHealthPoint;
        }
        
        private void UpdateManaBar()
        {
            fillManaBar.fillAmount = (float)_maner.ManaWallet.CountResources / _maner.ManaWallet.MaxResources;
        }

        private void UpdateCoinText()
        {
            textCoinCounter.text = _coiner.CoinWallet.CountResources.ToString();
        }
    }
}