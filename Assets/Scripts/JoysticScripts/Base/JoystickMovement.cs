using System;
using JoysticScripts.Joysticks;
using KittyPlatformer.Base;
using KittyPlatformer.Interfaces;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;

namespace JoysticScripts.Base
{
    public class JoystickMovement : MonoBehaviour
    {
        [SerializeField] private Entity movingEntity;
        [SerializeField] private Joystick joystick;

        private bool IsMove()
        {
            bool condition = joystick.Horizontal != 0;
            return condition;
        }
        
        private bool IsJump()
        {
            bool condition = joystick.GetCurrentQuarter() == Vector2.one;
            return condition;
        }
        
        private void Update()
        {
            if (IsMove())
                ((IMovable)movingEntity).Move(Vector3.right * joystick.Horizontal, joystick.GetPower());
            if (IsJump() && ((IJumper)movingEntity).CheckStayGround())
                ((IJumper)movingEntity).Jump(joystick.GetPower());
        }
    }
}