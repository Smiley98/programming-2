using UnityEngine;

public enum WeaponType
{
    RIFLE,
    SHOTGUN,
    GRENADE,
    COUNT
}

public class Player : MonoBehaviour
{
    // Makes variable available in the inspector, but NOT in other scripts
    [SerializeField]
    GameObject bulletPrefab;

    float moveSpeed = 5.0f;
    float bulletSpeed = 10.0f;

    WeaponType weaponType = WeaponType.RIFLE;

    void Start()
    {
        
    }

    void Update()
    {
        // Player movement
        float dt = Time.deltaTime;
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
        direction = direction.normalized;
        Vector3 movement = direction * moveSpeed * dt;
        transform.position += movement;

        // Convert mouse from screen-space to world-space
        Vector3 mouse = Input.mousePosition;
        mouse = Camera.main.ScreenToWorldPoint(mouse);
        mouse.z = 0.0f;
        Vector3 mouseDirection = (mouse - transform.position).normalized;
        Debug.DrawLine(transform.position, transform.position + mouseDirection * 5.0f);

        // Optional task: use a timer to fire a bullet every 0.5 seconds when space is held
        // Shoot in mouse direction
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Create bullet and offset it to be spawned outside of the player
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position + mouseDirection * 0.75f;
            bullet.GetComponent<Rigidbody2D>().velocity = mouseDirection * bulletSpeed;
            Destroy(bullet, 1.0f);
        }

        // Cycle weapon
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            int weaponNumber = (int)weaponType;
            weaponNumber++;
            weaponNumber %= (int)WeaponType.COUNT;
            weaponType = (WeaponType)weaponNumber;
        }
    }
}
