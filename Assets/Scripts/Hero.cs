using System;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider2D))]
public class Hero : Entity
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform pointJump;
    [SerializeField] private Weapon weapon;
    [SerializeField] private Joystick joystickMovement;
    [SerializeField] private Joystick joystickAttack;
    [SerializeField] private Canvas dieMenu;

    private bool _isStayGround;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _sprite;
    public int Direction => _sprite.flipX ? -1 : 1;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Run()
    {
        Vector3 dir = transform.right * joystickMovement.Horizontal;
        float currentSpeed = speed * joystickMovement.GetPower();
        Vector3 position = transform.position;
        position = Vector3.MoveTowards(position,position+dir,currentSpeed*Time.deltaTime);
        transform.position = position;
        _sprite.flipX = dir.x < 0.0f;
        
    }

    private void Jump()
    {
        float currentJumpForce = jumpForce * joystickMovement.GetPower();
        _rigidbody2D.velocity =  Vector2.up * currentJumpForce;
    }

    private void CheckGround()
    {
        var circleCollider = new Collider2D[1];
        int size = Physics2D.OverlapCircleNonAlloc(pointJump.position, 0.01f, circleCollider);
        _isStayGround = size > 0;
    }
    
    private protected override void CheckAlive()
    {
        if (IsAlive == false)
        {
            dieMenu.enabled = true;
        }
    }

    private void Update()
    {
        if (joystickMovement.Horizontal != 0)
            Run();
        if (_isStayGround && 
            joystickMovement.GetCurrentQuarter() == Vector2.one)
            Jump();
        if (joystickAttack.GetPower() == 0 &&
            joystickAttack.LastPossiblePower != 0)
        {
            weapon.Attack(joystickAttack.GetCurrentVector(), joystickAttack.GetPower());
            joystickAttack.ResetPower();
        }
        weapon.SetFlipX(_sprite.flipX);
    }
    
    private new void FixedUpdate()
    {
        base.FixedUpdate();
        CheckGround();
    }
}
