using System;
using System.Drawing;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class RunnerEnemy : Enemy
{
    [SerializeField] private Transform eye;
    [SerializeField] private float maxDistance;
    [SerializeField] private float edgeDistance;
    [SerializeField] private float speed;

    private float _firstX;
    private float _secondX;
    private SpriteRenderer _sprite;
    public int Direction => _sprite.flipX ? -1 : 1;

    private void Awake()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
        RotateOnDirection();
    }

    private void Wander()
    {
        Vector3 prevPosition = transform.position;
        var postPosition = new Vector3(_secondX, prevPosition.y);
        var currentPosition = Vector3.MoveTowards(prevPosition,
                                                          postPosition,
                                                 speed*Time.deltaTime);
        transform.position = currentPosition;
    }

    private void RotateOnDirection()
    {
        _firstX = transform.position.x;
        _secondX = _firstX + Direction * maxDistance;
        Vector3 eyeLocalPosition = eye.localPosition;
        eye.localPosition = new Vector3(Math.Abs(eyeLocalPosition.x) * Direction, eyeLocalPosition.y);
    }
    
    private void CheckWanderPosition()
    {
        Vector3 eyePosition = eye.position;
        RaycastHit2D rayOnGround = Physics2D.Raycast(eyePosition, Vector2.down, edgeDistance);
        RaycastHit2D rayOnWall = Physics2D.Raycast(eyePosition, Vector2.right*Direction, edgeDistance);
        if (Math.Abs(transform.position.x - _secondX) < edgeDistance ||
            rayOnGround.collider == false ||
            rayOnWall.collider)
        {
            _sprite.flipX = !_sprite.flipX;
            RotateOnDirection();
        }


    }

    private void Update()
    {
        Wander();
    }
    
    private new void FixedUpdate()
    {
        base.FixedUpdate();
        CheckAlive();
        CheckWanderPosition();
    }

}