using UnityEngine;

public static class Steering
{
    public static Vector3 Seek(GameObject seeker, Vector3 target, float speed)
    {
        Rigidbody2D rb = seeker.GetComponent<Rigidbody2D>();
        Vector3 currentVelocity = rb.linearVelocity;
        Vector3 desiredVelocity = (target - seeker.transform.position).normalized * speed;
        Vector3 acceleration = desiredVelocity - currentVelocity;
        return acceleration;
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
