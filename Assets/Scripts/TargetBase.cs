using UnityEngine;

public abstract class TargetBase : MonoBehaviour
{
    protected float health = 100.0f;

    public abstract void TakeDamage(float damage);

    void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile projectile = collision.GetComponent<Projectile>();
        TakeDamage(projectile.damage);
        if (health <= 0.0f)
            Destroy(gameObject);            // Destroy the target
        Destroy(collision.gameObject);      // Destroy the bullet
    }
}
