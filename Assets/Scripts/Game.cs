using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    GameObject[] waypoints;

    [SerializeField]
    GameObject enemy;

    Rigidbody2D rb;

    float speed = 5.0f;
    int curr = 0;
    int next = 1;

    void Start()
    {
        rb = enemy.GetComponent<Rigidbody2D>();
        //UpdateEnemyVelocity();
    }

    void Update()
    {
        //if (Vector3.Distance(enemy.transform.position, waypoints[next].transform.position) <= 0.5f)
        //{
        //    curr++;
        //    next++;
        //    curr %= waypoints.Length;
        //    next %= waypoints.Length;
        //    UpdateEnemyVelocity();
        //}

        // Move our enemy along a curve
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 seekForce = Steering.Seek(enemy, mouse, 10.0f);
        rb.AddForce(seekForce);

        // Orient our enemy in its direction of motion!
        enemy.transform.up = rb.linearVelocity.normalized;
    }

    void UpdateEnemyVelocity()
    {
        Vector3 A = waypoints[curr].transform.position;
        Vector3 B = waypoints[next].transform.position;
        enemy.transform.position = A;
        enemy.GetComponent<Rigidbody2D>().linearVelocity = (B - A).normalized * speed;
    }
}
