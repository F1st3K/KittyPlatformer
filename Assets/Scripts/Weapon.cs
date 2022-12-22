using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private protected int damage;
    
    private protected SpriteRenderer WeaponSprite;
    
    public int Direction => WeaponSprite.flipX ? -1 : 1;
    
    public virtual void Attack(Vector2 vector, float power)
    {
        Debug.Log("attack " + vector.ToString() + " " + power);
    }

    public void SetFlipX(bool value)
    {
        WeaponSprite.flipX = value;
    }

    private void Awake()
    {
        WeaponSprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        RotateOnDirection();
    }

    private void RotateOnDirection()
    {
        Vector3 localPosition = WeaponSprite.transform.localPosition;
        WeaponSprite.transform.localPosition = new Vector3(Math.Abs(localPosition.x) * Direction, localPosition.y);
    }
}