using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject weaponPrefab;

    Weapon weapon = null;

    void Start()
    {
        weapon = new Shotgun();
        weapon.shootTotal = 0.25f;
        weapon.shooter = gameObject;
        weapon.weaponPrefab = weaponPrefab;
    }

    void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }
        transform.position += direction * 5.0f * Time.deltaTime;
    }

    void Shoot()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0.0f;

        Vector3 direction = (mouse - transform.position).normalized;
        Debug.DrawLine(transform.position, transform.position + direction * 5.0f, GetComponent<SpriteRenderer>().color);

        if (Input.GetKey(KeyCode.Space))
            weapon.Shoot(direction, 10.0f);
        weapon.Tick();
    }
}
