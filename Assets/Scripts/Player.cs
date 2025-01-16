using UnityEngine;

public class Player : MonoBehaviour
{
    float moveSpeed = 5.0f;

    void Start()
    {
        
    }

    void Update()
    {
        float dt = Time.deltaTime;
        Vector2 direction = Vector2.up;
        Vector3 movement = direction * moveSpeed * dt;
        transform.position += movement;
    }
}
