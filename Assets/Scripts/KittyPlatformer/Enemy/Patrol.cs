using System;
using KittyPlatformer.Base;
using UnityEngine;

namespace KittyPlatformer.Enemy
{
    public class Patrol
    {
        private Enemy _enemy;
        private float _patrolLength;
        private float _startX;
        private float _endX;
        
        public float CurrentX => _enemy.transform.position.x;

        public Patrol(Enemy enemy, float patrolLength)
        {
            _enemy = enemy;
            _patrolLength = patrolLength;
            _startX = CurrentX;
            _endX = _startX + _patrolLength;
        }
        
        public void Run()
        {
            CheckPosition();
            Vector3 direction = Vector3.zero;
            direction.x = _endX - CurrentX;
            Debug.Log(direction);
            _enemy.Move(direction, 1f);
        }

        private void CheckPosition()
        {
            if (Math.Abs(CurrentX - _endX) > 0 )
                (_startX, _endX) = (_endX, _startX + _patrolLength);
        }
    }
}