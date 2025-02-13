using UnityEngine;

public class Target : MonoBehaviour
{
    float health = 100.0f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Right now, Bullet & Grenade are the only objects with colliders on them.
        // So we're guaranteed to be able to fetch their Projectile component.
        // Realistically, you'd need a null or tag check to ensure the data exists.
        Projectile projectile = collision.GetComponent<Projectile>();
        health -= projectile.damage;
        if (health <= 0.0)
            Destroy(gameObject);

        // Destroy the projectile once we're done using it for logic
        Destroy(collision.gameObject);
    }
}
