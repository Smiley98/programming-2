using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
