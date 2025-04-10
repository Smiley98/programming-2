using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject weaponPrefab;

    Weapon weapon = null;

    public float health = 100.0f;

    void Start()
    {
        weapon = new Rifle();
        weapon.weaponPrefab = weaponPrefab;
        weapon.shooter = gameObject;

        weapon.shootTotal = 0.2f;
        weapon.damage = 5.0f;
        weapon.life = 1.0f;
        weapon.speed = 10.0f;

        weapon.color = GetComponent<SpriteRenderer>().color;
        weapon.team = Team.PLAYER;
    }

    void Update()
    {
        Move();
        Shoot();

        if (health <= 0.0f)
            Debug.Log("Player died :(");
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
        weapon.Tick();

        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0.0f;

        Vector3 direction = (mouse - transform.position).normalized;
        Debug.DrawLine(transform.position, transform.position + direction * 5.0f, GetComponent<SpriteRenderer>().color);

        if (Input.GetKey(KeyCode.Space))
            weapon.Shoot(direction);
    }
}
