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

    enum State
    {
        PATROL,
        ATTACK
    }

    State state = State.PATROL;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        UpdateState();
        switch (state)
        {
            case State.PATROL:
                Patrol();
                break;

            case State.ATTACK:
                Attack();
                break;
        }
        rb.AddForce(Avoid());
        transform.up = Vector3.RotateTowards(transform.up, rb.velocity.normalized, turnSpeed * Time.deltaTime, 0.0f);
        Debug.DrawLine(transform.position, transform.position + transform.up * 5.0f, Color.green);
    }

    void UpdateState()
    {
        Vector3 toPlayer = (player.transform.position - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, toPlayer, detectRadius);
        bool playerHit = hit && hit.collider.CompareTag("Player");
        state = playerHit ? State.ATTACK : State.PATROL;
        //Debug.DrawLine(transform.position, transform.position + toPlayer * detectRadius, playerHit ? Color.red : Color.green);
    }

    void Patrol()
    {
        rb.AddForce(Steering.FollowLine(gameObject, waypoints, ref curr, ref next, moveSpeed, ahead));
    }

    void Attack()
    {
        // Homework 6:
        // Equip the enemy with a weapon of your choice from Weapons.cs and fire it at the player!
        rb.AddForce(Steering.Seek(gameObject, player.transform.position, moveSpeed));
    }

    Vector3 Avoid()
    {
        float distance = detectRadius * 0.5f;
        Vector3 dirRight = Quaternion.Euler(0.0f, 0.0f, -20.0f) * transform.up;
        Vector3 dirLeft = Quaternion.Euler(0.0f, 0.0f, 20.0f) * transform.up;
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, dirLeft, distance);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, dirRight, distance);

        Vector3 force = Vector3.zero;
        if (hitLeft && hitLeft.collider.CompareTag("Obstacle"))
        {
            force += Steering.Seek(gameObject, transform.right * distance, moveSpeed);
        }
        else if (hitRight && hitRight.collider.CompareTag("Obstacle"))
        {
            force += Steering.Seek(gameObject, -transform.right * distance, moveSpeed);
        }
        return force;
    }
}
