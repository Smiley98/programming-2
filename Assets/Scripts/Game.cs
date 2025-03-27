using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    GameObject[] waypoints;

    [SerializeField]
    GameObject enemy;

    [SerializeField]
    GameObject projCurrObj;

    [SerializeField]
    GameObject projNextObj;

    bool linearPath = false;

    [SerializeField]
    float ahead;

    float speed = 5.0f;
    int curr = 0;
    int next = 1;

    void Start()
    {
        if (linearPath)
            UpdateEnemyVelocity();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            linearPath = !linearPath;
            if (linearPath)
                UpdateEnemyVelocity();
        }

        if (linearPath)
        {
            if (Vector3.Distance(enemy.transform.position, waypoints[next].transform.position) <= 0.5f)
            {
                curr++;
                next++;
                curr %= waypoints.Length;
                next %= waypoints.Length;
                UpdateEnemyVelocity();
            }
        }
        else
        {
            Vector3 A = waypoints[curr].transform.position;
            Vector3 B = waypoints[next].transform.position;
            Vector3 projCurr = Steering.ProjectPointLine(A, B, enemy.transform.position);
            Vector3 projNext = projCurr + (B - A).normalized * ahead;
            projCurrObj.transform.position = projCurr;
            projNextObj.transform.position = projNext;

            // Check if projNext is outside the line segment. If so, advance waypoints!
            float t = Steering.ScalarProjectPointLine(A, B, projNext);
            if (t > 1.0f)
            {
                curr++;
                next++;
                curr %= waypoints.Length;
                next %= waypoints.Length;
            }

            Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
            Vector3 seekForce = Steering.Seek(enemy, projNext, speed);
            rb.AddForce(seekForce);
            enemy.transform.up = rb.linearVelocity.normalized;
        }

        Debug.DrawLine(enemy.transform.position, enemy.transform.position + enemy.transform.up * 5.0f);
    }

    void UpdateEnemyVelocity()
    {
        Vector3 A = waypoints[curr].transform.position;
        Vector3 B = waypoints[next].transform.position;
        projCurrObj.transform.position = A;
        projNextObj.transform.position = B;

        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
        rb.linearVelocity = (B - A).normalized * speed;
        enemy.transform.up = rb.linearVelocity.normalized;
        enemy.transform.position = A;
    }

    void SeekMouse()
    {
        // Move our enemy along a curve
        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 seekForce = Steering.Seek(enemy, mouse, 10.0f);
        rb.AddForce(seekForce);

        // Orient our enemy in its direction of motion!
        enemy.transform.up = rb.linearVelocity.normalized;
    }
}
