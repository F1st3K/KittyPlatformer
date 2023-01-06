using KittyPlatformer.Base;
using KittyPlatformer.Interfaces;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;

namespace KittyPlatformer.Controllers
{
    public class AttachmentController : MonoBehaviour
    {
        [SerializeField] private Entity attachingEntity;
        [SerializeField] private Joystick joystick;
        [SerializeField] private float idling;

        private bool IsAttack()
        {
            return joystick.GetPower() >= idling;
        }

        private bool IsAim()
        {
            return joystick.LastPossibleVector != joystick.GetCurrentVector();
        }
        
        private void Update()
        {
            if (IsAim() || IsAttack())
            {
                (attachingEntity as IAttacker)?.TakeAim(joystick.GetCurrentVector());
                joystick.ResetVector();
            }
            if (IsAttack())
            {
                (attachingEntity as IAttacker)?.Attack(joystick.LastPossiblePower);
                joystick.ResetPower();
            }
        }
    }
}