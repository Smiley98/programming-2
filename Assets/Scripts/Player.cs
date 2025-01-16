using UnityEngine;
using UnityEngine.EventSystems;

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
            switch (weaponType)
            {
                case WeaponType.RIFLE:
                    ShootRifle(mouseDirection);
                    break;

                case WeaponType.SHOTGUN:
                    ShootShotgun(mouseDirection);
                    break;

                case WeaponType.GRENADE:
                    ShootGrenade(mouseDirection);
                    break;
            }
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

    void ShootRifle(Vector3 direction)
    {
        // Create bullet and offset it to be spawned outside of the player
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = transform.position + direction * 0.75f;
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        Destroy(bullet, 1.0f);
    }

    void ShootShotgun(Vector3 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab);
        GameObject bulletLeft = Instantiate(bulletPrefab);
        GameObject bulletRight = Instantiate(bulletPrefab);

        // A quaternion is a "rotation". You can apply a rotation to a direction with multiplication.
        Vector3 directionLeft = Quaternion.Euler(0.0f, 0.0f, 30.0f) * direction;
        Vector3 directionRight = Quaternion.Euler(0.0f, 0.0f, -30.0f) * direction;

        // Position bullets forward/left/right
        bullet.transform.position = transform.position + direction * 0.75f;
        bulletLeft.transform.position = transform.position + directionLeft * 0.75f;
        bulletRight.transform.position = transform.position + directionRight * 0.75f;

        // Move bullets forward/left/right
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        bulletLeft.GetComponent<Rigidbody2D>().velocity = directionLeft * bulletSpeed;
        bulletRight.GetComponent<Rigidbody2D>().velocity = directionRight * bulletSpeed;

        Destroy(bullet, 1.0f);
        Destroy(bulletLeft, 1.0f);
        Destroy(bulletRight, 1.0f);
    }

    void ShootGrenade(Vector3 direction)
    {
        
    }
}
