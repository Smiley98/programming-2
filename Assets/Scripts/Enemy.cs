using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject[] waypoints;
    int curr = 0;
    int next = 1;
    float ahead = 2.0f;
    float moveSpeed = 5.0f;
    float turnSpeed = 250.0f * Mathf.Deg2Rad;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float dt = Time.deltaTime;
        rb.AddForce(Steering.FollowLine(gameObject, waypoints, ref curr, ref next, moveSpeed, ahead));
        transform.up = Vector3.RotateTowards(transform.up, rb.velocity.normalized, turnSpeed * dt, 0.0f);
        Debug.DrawLine(transform.position, transform.position + transform.up * 5.0f, Color.green);
    }
}
