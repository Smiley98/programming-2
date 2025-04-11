using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject weaponPrefab;

    Weapon[] weapons = new Weapon[2];
    int selected = 0;

    public float health = 100.0f;

    void Start()
    {
        weapons[0] = new Rifle();
        weapons[0].weaponPrefab = weaponPrefab;
        weapons[0].shooter = gameObject;
        
        weapons[0].shootTotal = 0.2f;
        weapons[0].damage = 5.0f;
        weapons[0].life = 1.0f;
        weapons[0].speed = 10.0f;
        
        weapons[0].color = GetComponent<SpriteRenderer>().color;
        weapons[0].team = Team.PLAYER;

        weapons[1] = new Shotgun();
        weapons[1].weaponPrefab = weaponPrefab;
        weapons[1].shooter = gameObject;

        weapons[1].shootTotal = 0.2f;
        weapons[1].damage = 5.0f;
        weapons[1].life = 1.0f;
        weapons[1].speed = 10.0f;

        weapons[1].color = GetComponent<SpriteRenderer>().color;
        weapons[1].team = Team.PLAYER;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            selected++;
            selected %= weapons.Length;
        }

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
        Weapon weapon = weapons[selected];
        weapon.Tick();

        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0.0f;

        Vector3 direction = (mouse - transform.position).normalized;
        Debug.DrawLine(transform.position, transform.position + direction * 5.0f, GetComponent<SpriteRenderer>().color);

        if (Input.GetKey(KeyCode.Space))
            weapon.Shoot(direction);
    }
}
