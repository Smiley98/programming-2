using UnityEngine;

public class ArmoredTarget : MonoBehaviour
{
    float health = 100.0f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile projectile = collision.GetComponent<Projectile>();
        health -= projectile.damage * 0.5f;
        if (health <= 0.0f)
            Destroy(gameObject);            // Destroy the target
        Destroy(collision.gameObject);      // Destroy the bullet
    }
}
