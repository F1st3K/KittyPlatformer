using System;
using UnityEngine;

namespace KittyPlatformer.Enemy
{
    public class Patrol
    {
        private readonly Enemy _enemy;
        private float _startX;
        private float _endX;

        private float CurrentX => _enemy.transform.position.x;

        public Patrol(Enemy enemy, float patrolLength)
        {
            _enemy = enemy;
            _startX = CurrentX;
            _endX = _startX + patrolLength;
        }
        
        public void Run(float mullSpeed)
        {
            CheckPosition();
            Vector3 direction = Vector3.zero;
            direction.x = _endX - CurrentX;
            Debug.Log(direction);
            _enemy.Move(direction, mullSpeed);
        }

        private void CheckPosition()
        {
            if (Math.Abs(CurrentX - _endX) <= 0 )
                (_startX, _endX) = (_endX, _startX);
        }
    }
}