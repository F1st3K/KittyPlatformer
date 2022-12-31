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
            if (condition)
                joystick.ResetPower();
            return condition;
        }
        
        private void Update()
        {
            if (IsAttack())
                (attachingEntity as IAttacking)?.Attack(joystick.GetCurrentVector(), joystick.GetPower());
        }
    }
}