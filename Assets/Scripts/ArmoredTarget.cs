using UnityEngine;

public class ArmoredTarget : MonoBehaviour, IDamageable
{
    float health = 100.0f;

    public void TakeDamage(float damage)
    {
        health -= damage * 0.5f;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile projectile = collision.GetComponent<Projectile>();
        TakeDamage(projectile.damage);
        if (health <= 0.0f)
            Destroy(gameObject);            // Destroy the target
        Destroy(collision.gameObject);      // Destroy the bullet
    }
}
