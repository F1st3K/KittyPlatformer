using UnityEngine;

public class Weapon : MonoBehaviour
{
    public void Attack(Vector2 vector, float power)
    {
        Debug.Log("attack " + vector.ToString() + " " + power);
    }
}