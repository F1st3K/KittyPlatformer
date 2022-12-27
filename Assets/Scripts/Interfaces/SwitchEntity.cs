using System;
using UnityEngine;

namespace Interfaces
{
    public abstract class SwitchEntity : MonoBehaviour, ISwitching
    {
        [SerializeField] private bool isActivate;
        public bool IsActivate => isActivate;

        public void Activate()
        {
            isActivate = true;
            OnActivate();
        }

        public void DeActivate()
        {
            isActivate = false;
            OnDeActivate();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out IStateChanger changer) &&
                changer.SwitchingEntity is null)
                changer.SetSwitchingEntity(this);
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out IStateChanger changer) &&
                changer.SwitchingEntity is not null)
                changer.SetSwitchingEntity(null);
        }

        private protected virtual void OnActivate()
        {
        
        }
        
        private protected virtual void OnDeActivate()
        {
        
        }
    }
}