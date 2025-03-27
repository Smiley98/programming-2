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

    [SerializeField]
    float ahead;

    float speed = 5.0f;
    int curr = 0;
    int next = 1;

    bool linearPath = false;

    void Start()
    {
        if (linearPath)
            SnapEnemy();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            linearPath = !linearPath;
            if (linearPath)
                SnapEnemy();
        }

        if (linearPath)
        {
            if (Vector3.Distance(enemy.transform.position, waypoints[next].transform.position) <= 0.5f)
            {
                curr++;
                next++;
                curr %= waypoints.Length;
                next %= waypoints.Length;
                SnapEnemy();
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

            float t = Steering.ScalarProjectPointLine(A, B, projNext);
            if (t > 1.0f)
            {
                curr++;
                next++;
                curr %= waypoints.Length;
                next %= waypoints.Length;
            }

            // Path-seek
            EnemySeek(projNext);
        }

        // Orient enemy in its direction of motion
        enemy.transform.up = enemy.gameObject.GetComponent<Rigidbody2D>().linearVelocity.normalized;
        Debug.DrawLine(enemy.transform.position, enemy.transform.position + enemy.transform.up * 5.0f);

        // Mouse-seek
        //EnemySeek(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    void SnapEnemy()
    {
        Rigidbody2D rb = enemy.gameObject.GetComponent<Rigidbody2D>();
        Vector3 A = waypoints[curr].transform.position;
        Vector3 B = waypoints[next].transform.position;
        projCurrObj.transform.position = A;
        projNextObj.transform.position = B;
        rb.linearVelocity = (B - A).normalized * speed;
        rb.position = A;
    }

    void EnemySeek(Vector2 target)
    {
        Vector3 seekForce = Steering.Seek(enemy, target, speed);
        Rigidbody2D rb = enemy.gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(seekForce);
    }
}
