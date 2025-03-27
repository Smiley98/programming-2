using UnityEngine;

public static class Steering
{
    public static Vector3 Seek(GameObject seeker, Vector3 target, float speed)
    {
        Vector3 currentVelocity = seeker.GetComponent<Rigidbody2D>().linearVelocity;
        Vector3 desiredVelocity = (target - seeker.transform.position).normalized * speed;
        Vector3 acceleration = desiredVelocity - currentVelocity;
        return acceleration;
    }
}
