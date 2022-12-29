using System;
using KittyPlatformer.Base;
using KittyPlatformer.Interfaces;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace JoysticScripts.Base
{
    public class AttachmentController : MonoBehaviour
    {
        [SerializeField] private Entity attachingEntity;
        [SerializeField] private Joystick joystick;
        [SerializeField] private float idling;

        private bool IsAttack()
        {
            bool condition = joystick.GetPower() > idling &&
                             joystick.LastPossiblePower > idling;
            return condition;
        }
        
        private void Update()
        {
            if (IsAttack())
                (attachingEntity as IAttacking)?.Attack(joystick.GetCurrentVector(), joystick.GetPower());
        }
    }
}