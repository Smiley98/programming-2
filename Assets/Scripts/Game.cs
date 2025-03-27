using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    GameObject[] waypoints;

    [SerializeField]
    GameObject enemy;

    float time = 0.0f;
    int curr = 0;
    int next = 1;

    void Start()
    {
        
    }

    void Update()
    {
        float dt = Time.deltaTime;
        time += dt;
        if (time > 1.0f)
        {
            time = 0.0f;
            curr++;
            next++;
            curr %= waypoints.Length;
            next %= waypoints.Length;
        }

        Vector3 A = waypoints[curr].transform.position;
        Vector3 B = waypoints[next].transform.position;
        Vector3 P = Vector3.Lerp(A, B, time);
        enemy.transform.position = P;
    }
}
