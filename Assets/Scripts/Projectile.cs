using UnityEngine;

public enum Team
{
    NONE,
    PLAYER,
    ENEMY
}

public class Projectile : MonoBehaviour
{
    public float damage;
    public Team team = Team.NONE;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (team == Team.NONE)
            Debug.LogError("Bullet team uninitialized");

        if (team == Team.PLAYER && collision.CompareTag("Player"))
            return;

        if (team == Team.ENEMY && collision.CompareTag("Enemy"))
            return;

        if (team == Team.PLAYER && collision.CompareTag("Enemy"))
            collision.GetComponent<Enemy>().health -= damage;

        if (team == Team.ENEMY && collision.CompareTag("Player"))
            collision.GetComponent<Player>().health -= damage;

        Destroy(gameObject);
    }
}
