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

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(
            transform.position,
            transform.position+dir,
    speed*Time.deltaTime);
        _sprite.flipX = dir.x < 0.0f; 
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);    
        
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        _isStayGround = collider.Length > 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();
        if (_isStayGround && Input.GetButtonDown("Jump"))
            Jump();
    }
    void FixedUpdate()
    {
        CheckGround();
    }
}
