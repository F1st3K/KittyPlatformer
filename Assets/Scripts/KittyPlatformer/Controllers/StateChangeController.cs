using System;
using KittyPlatformer.Base;
using KittyPlatformer.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace KittyPlatformer.Controllers
{
    public class StateChangeController : MonoBehaviour
    {
        [SerializeField] private Entity attachingEntity;
        [SerializeField] private Button button;

        private void Awake()
        {
            button.onClick.AddListener(OnPressed);
        }

        private void OnPressed()
        {
            (attachingEntity as IStateChanger)?.ToggleCurrentSwitchingEntity();
        }

        private void Update()
        {
            button.enabled = (attachingEntity as IStateChanger)?.StateVariableEntity is not null;
        }
    }
}