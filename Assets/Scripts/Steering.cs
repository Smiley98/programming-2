using System.Threading;
using UnityEngine;

public static class Steering
{
    public static Vector3 Seek(GameObject seeker, Vector3 target, float speed)
    {
        Rigidbody2D rb = seeker.GetComponent<Rigidbody2D>();
        Vector3 currentVelocity = rb.velocity;
        Vector3 desiredVelocity = (target - seeker.transform.position).normalized * speed;
        Vector3 acceleration = desiredVelocity - currentVelocity;
        return acceleration;
    }

    public static Vector3 FollowLine(GameObject seeker, GameObject[] waypoints, ref int curr, ref int next, float speed, float ahead)
    {
        Vector3 A = waypoints[curr].transform.position;
        Vector3 B = waypoints[next].transform.position;
        Vector3 projCurr = ProjectPointLine(A, B, seeker.transform.position);
        Vector3 projNext = projCurr + (B - A).normalized * ahead;

        float t = ScalarProjectPointLine(A, B, projNext);
        if (t > 1.0f)
        {
            curr++;
            next++;
            curr %= waypoints.Length;
            next %= waypoints.Length;
        }

        return Seek(seeker, projNext, speed);
    }

    public static Vector3 ProjectPointLine(Vector3 A, Vector3 B, Vector3 P)
    {
        Vector3 AB = B - A;
        float t = Vector3.Dot(P - A, AB) / Vector3.Dot(AB, AB);
        return A + AB * Mathf.Clamp(t, 0.0f, 1.0f);
    }

    public static float ScalarProjectPointLine(Vector3 A, Vector3 B, Vector3 P)
    {
        Vector3 AB = B - A;
        float t = Vector3.Dot(P - A, AB) / Vector3.Dot(AB, AB);
        return t;
    }
}
