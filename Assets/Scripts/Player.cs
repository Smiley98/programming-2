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
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
        direction = direction.normalized;

        Vector3 movement = direction * moveSpeed * dt;
        transform.position += movement;
    }
}
