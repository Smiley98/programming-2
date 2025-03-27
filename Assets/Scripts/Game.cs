using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    GameObject[] waypoints;

    [SerializeField]
    GameObject enemy;

    float time = 0.0f;

    void Start()
    {
        
    }

    void Update()
    {
        float dt = Time.deltaTime;
        time += dt;
        if (time > 1.0f)
            time = 0.0f;

        Vector3 A = waypoints[0].transform.position;
        Vector3 B = waypoints[1].transform.position;
        Vector3 P = Vector3.Lerp(A, B, time);
        enemy.transform.position = P;
    }
}
