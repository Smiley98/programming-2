using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    GameObject[] waypoints;

    [SerializeField]
    GameObject enemy;

    float speed = 5.0f;
    int curr = 0;
    int next = 1;

    void Start()
    {
        UpdateEnemyVelocity();
    }

    void Update()
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

    void UpdateEnemyVelocity()
    {
        Vector3 A = waypoints[curr].transform.position;
        Vector3 B = waypoints[next].transform.position;
        enemy.transform.position = A;
        enemy.GetComponent<Rigidbody2D>().linearVelocity = (B - A).normalized * speed;
    }
}
