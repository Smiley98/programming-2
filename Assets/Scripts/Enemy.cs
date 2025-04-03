using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject[] waypoints;
    int curr = 0;
    int next = 1;
    float ahead = 2.0f;
    float moveSpeed = 5.0f;
    float turnSpeed = 250.0f * Mathf.Deg2Rad;
    float detectRadius = 5.0f;

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

        // AB = B - A
        Vector3 toPlayer = (player.transform.position - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, toPlayer, detectRadius);
        bool playerHit = hit && hit.collider.CompareTag("Player");
        Debug.DrawLine(transform.position, transform.position + toPlayer * detectRadius, playerHit ? Color.red : Color.green);
    }
}
