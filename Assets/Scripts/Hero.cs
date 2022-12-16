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
    [SerializeField] private Joystick joystickMovement;
    [SerializeField] private Joystick joystickAttack;
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

    private void Attack()
    {
        weapon.Attack();
    }

    private void CheckGround()
    {
        var circleCollider = new Collider2D[1];
        int size = Physics2D.OverlapCircleNonAlloc(pointJump.position, 0.01f, circleCollider);
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
        Debug.Log(joystickMovement.GetCurrentQuarter());
        if (joystickMovement.Horizontal != 0)
            Run();
        if (_isStayGround && joystickMovement.GetCurrentQuarter() == Vector2.one)
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
