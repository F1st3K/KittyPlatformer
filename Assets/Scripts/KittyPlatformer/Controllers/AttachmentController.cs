using KittyPlatformer.Base;
using KittyPlatformer.Interfaces;
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
            bool condition = joystick.GetPower() < idling &&
                             joystick.LastPossiblePower > idling;
            return condition;
        }
        
        private void Update()
        {
            if (IsAttack())
            {
                (attachingEntity as IAttacking)?.Attack(joystick.LastPossibleVector, joystick.LastPossiblePower);
                joystick.ResetPower();
            }
        }
    }
}