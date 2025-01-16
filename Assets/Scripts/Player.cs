using UnityEngine;

public class Player : MonoBehaviour
{
    float moveSpeed = 5.0f;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 direction = Vector3.up;
        Vector3 movement = direction * moveSpeed * Time.deltaTime;
        transform.position += movement;
    }
}
