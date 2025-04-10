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
    float detectRadius = 5.0f;

    Rigidbody2D rb;

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject weaponPrefab;

    Weapon weapon = null;

    enum State
    {
        PATROL,
        ATTACK
    }
    State state = State.PATROL;
    Team team = Team.ENEMY;

    public float health = 50.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        weapon = new Rifle();
        weapon.shootTotal = 0.5f;
        weapon.shooter = gameObject;
        weapon.weaponPrefab = weaponPrefab;

        weapon.life = 1.0f;
        weapon.speed = 10.0f;
        weapon.damage = 25.0f;

        weapon.color = GetComponent<SpriteRenderer>().color;
        weapon.team = team;
    }

    void Update()
    {
        weapon.Tick();
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
        Avoid();
        transform.up = Vector3.RotateTowards(transform.up, rb.linearVelocity.normalized, turnSpeed * Time.deltaTime, 0.0f);
        //Debug.DrawLine(transform.position, transform.position + transform.up * 5.0f, Color.green);

        if (health <= 0.0f)
            Debug.Log("Enemy died :)");
    }

    void UpdateState()
    {
        Vector3 toPlayer = (player.transform.position - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, toPlayer, detectRadius);
        bool playerHit = hit && hit.collider.CompareTag("Player");
        state = playerHit ? State.ATTACK : State.PATROL;
        Debug.DrawLine(transform.position, transform.position + toPlayer * 5.0f, playerHit ? Color.red : Color.green);
    }

    void Patrol()
    {
        Vector3 force = Steering.FollowLine(gameObject, waypoints, ref curr, ref next, moveSpeed, ahead);
        rb.AddForce(force);
    }

    void Attack()
    {
        Vector3 force = Steering.Seek(gameObject, player.transform.position, moveSpeed);
        rb.AddForce(force);
        weapon.Shoot((player.transform.position - transform.position).normalized);
    }

    void Avoid()
    {
        float distance = detectRadius * 0.5f;
        Vector3 dirLeft = Quaternion.Euler(0.0f, 0.0f, 20.0f) * transform.up;
        Vector3 dirRight = Quaternion.Euler(0.0f, 0.0f, -20.0f) * transform.up;
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, dirLeft, distance);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, dirRight, distance);

        Vector3 force = Vector3.zero;
        if (hitLeft && hitLeft.collider.CompareTag("Obstacle"))
        {
            force = Steering.Seek(gameObject, transform.right * distance, moveSpeed);
        }
        else if (hitRight && hitRight.collider.CompareTag("Obstacle"))
        {
            force = Steering.Seek(gameObject, -transform.right * distance, moveSpeed);
        }
        rb.AddForce(force);
    }
}
