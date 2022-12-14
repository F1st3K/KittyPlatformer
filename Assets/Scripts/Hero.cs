using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Hero : Entity
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
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
        var dir = transform.right * Input.GetAxis("Horizontal");
        var position = transform.position;
        position = Vector3.MoveTowards(position,position+dir,speed*Time.deltaTime);
        transform.position = position;
        _sprite.flipX = dir.x < 0.0f; 
    }

    private void Jump()
    {
        _rigidbody2D.velocity =  Vector2.up * jumpForce;
    }

    private void CheckGround()
    {
        var circleCollider = new Collider2D[1];
        var size = Physics2D.OverlapCircleNonAlloc(transform.position, 0.01f, circleCollider);
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
        if (Input.GetButton("Horizontal"))
            Run();
        if (_isStayGround && Input.GetButtonDown("Jump"))
            Jump();
    }
    
    private void FixedUpdate()
    {
        CheckAlive();
        CheckGround();
    }
}
