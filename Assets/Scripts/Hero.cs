using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private int lives = 5;
    [SerializeField] private float jumpForce = 15f;
    private bool _isStayGround = false;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _sprite;
    
    public static Hero Instance { get; set; }

    public void GetDamage()
    {
        lives -= 1;
        Debug.Log(lives);
    }
    
    private void Awake()
    {
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
        _rigidbody2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        var circleCollider = new Collider2D[1];
        var size = Physics2D.OverlapCircleNonAlloc(transform.position, 0.01f, circleCollider);
        _isStayGround = size > 0;
    }
    
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();
        if (_isStayGround && Input.GetButtonDown("Jump"))
            Jump();
    }
    
    private void FixedUpdate()
    {
        CheckGround();
    }
}
