using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private protected int damage;
    public virtual void Attack(Vector2 vector, float power)
    {
        Debug.Log("attack " + vector.ToString() + " " + power);
    }
}