using UnityEditor.SceneManagement;
using UnityEngine;

public class Car
{
    public int gas;
    public bool isAutoDrive;
    public Vector2 velocity;
    public Color color;
    public float traction;

    public void Drive(Vector2 force)
    {
        if (isAutoDrive)
        {
            Debug.Log("Using Telsa navigation!!!");
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("Insert car physics here xD xD xD");
                velocity += force;
            }
        }
    }

    public void Park()
    {
        velocity = Vector2.zero;
    }

    public bool IsMoving()
    {
        return velocity.magnitude > 0.0f;
    }

    public bool IsDrifting()
    {
        return IsMoving() && traction < 0.5f;
    }

    public void Explode()
    {
        // TODO - Find a way to make this explode
        Debug.Log("Tick tick tick...");
    }
}
