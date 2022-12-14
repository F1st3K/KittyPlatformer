using System;
using System.Drawing;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class RunnerEnemy : Enemy
{
    [SerializeField] private Transform firstPosition;
    [SerializeField] private Transform secondPosition;
    [SerializeField] private float speed;
    
    private float _firstX;
    private float _secondX;
    private SpriteRenderer _sprite;

    private void Awake()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
        firstPosition = transform;
        _firstX = firstPosition.TransformPoint(0, 0, 0).x;
        _secondX = secondPosition.TransformPoint(0, 0, 0).x;
    }

    private void Wander()
    {
        var prevPosition = transform.position;
        var postPosition = new Vector3(_secondX, prevPosition.y);
        var currentPosition = Vector3.MoveTowards(prevPosition,
                                                          postPosition,
                                                 speed*Time.deltaTime);
        transform.position = currentPosition;
    }
    
    private void CheckWanderPosition()
    {
        if (Math.Abs(transform.position.x - _secondX) == 0)
        {
            _secondX = _firstX;
            _firstX = transform.position.x;
            _sprite.flipX = !_sprite.flipX;
        }
    }

    private void Update()
    {
        Wander();
    }
    
    private void FixedUpdate()
    {
        CheckWanderPosition();
    }

}