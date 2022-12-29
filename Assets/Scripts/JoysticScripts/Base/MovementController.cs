using System;
using JoysticScripts.Joysticks;
using KittyPlatformer.Base;
using KittyPlatformer.Interfaces;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;

namespace JoysticScripts.Base
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private Entity movingEntity;
        [SerializeField] private Joystick joystick;
        [SerializeField] private float idling;

        private bool IsMove()
        {
            bool condition = joystick.Horizontal != 0 &&
                             joystick.GetPower() > idling;
            return condition;
        }
        
        private bool IsJump()
        {
            bool condition = joystick.GetCurrentQuarter() == Vector2.one &&
                             joystick.GetPower() > idling;
            return condition;
        }
        
        private void Update()
        {
            if (IsMove())
                (movingEntity as IMovable)?.Move(Vector3.right * joystick.Horizontal, joystick.GetPower());
            if (IsJump() && ((IJumper)movingEntity).CheckStayGround())
                (movingEntity as IJumper)?.Jump(joystick.GetPower());
        }
    }
}