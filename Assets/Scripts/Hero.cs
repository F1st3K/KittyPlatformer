using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider2D))]
public class Hero : Entity
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform pointJump;
    [SerializeField] private Weapon weapon;
    [SerializeField] private FloatingJoystick joystickMovement;
    [SerializeField] private FloatingJoystick joystickAttack;
    private bool _isStayGround = false;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _sprite;
    
    public static Hero Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Run()
    {
        var dir = transform.right * joystickMovement.Horizontal;
        var currentSpeed = Math.Abs(speed * joystickMovement.Horizontal);
        var position = transform.position;
        position = Vector3.MoveTowards(position,position+dir,currentSpeed*Time.deltaTime);
        transform.position = position;
        _sprite.flipX = dir.x < 0.0f; 
    }

    private void Jump()
    {
        var currentJumpForce = Math.Abs(jumpForce * joystickMovement.Vertical);
        _rigidbody2D.velocity =  Vector2.up * currentJumpForce;
    }

    private void Attack()
    {
        weapon.Attack();
    }

    private void CheckGround()
    {
        var circleCollider = new Collider2D[1];
        var size = Physics2D.OverlapCircleNonAlloc(pointJump.position, 0.01f, circleCollider);
        _isStayGround = size > 0;
    }
    
    private protected override void CheckAlive()
    {
        if (hitPoint <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
    private void Update()
    {
        if (joystickMovement.Horizontal != 0 && joystickMovement.Vertical > -0.75)
            Run();
        if (_isStayGround && joystickMovement.Vertical > 0.5)
            Jump();
        //if (attack.IsPressed)
        //    Attack();
    }
    
    private void FixedUpdate()
    {
        CheckAlive();
        CheckGround();
    }
}
