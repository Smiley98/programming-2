using UnityEngine;

public class Target : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);  // Destroy the bullet
        Destroy(gameObject);            // Destroy the target
    }
}
