using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    GameObject[] waypoints;

    [SerializeField]
    GameObject enemy;

    [SerializeField]
    float t;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 A = waypoints[0].transform.position;
        Vector3 B = waypoints[1].transform.position;
        Vector3 P = Vector3.Lerp(A, B, t);
        enemy.transform.position = P;
    }
}
