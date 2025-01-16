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
    [SerializeField]
    GameObject bulletPrefab;

    float bulletSpeed = 10.0f;
    float moveSpeed = 5.0f;

    WeaponType weaponType = WeaponType.RIFLE;

    void Start()
    {
        
    }

    void Update()
    {
        // Directional movement
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
        direction = direction.normalized;
        Vector3 movement = direction * moveSpeed * Time.deltaTime;
        transform.position += movement;

        // Aiming with mouse cursor
        Vector3 mouse = Input.mousePosition;
        mouse = Camera.main.ScreenToWorldPoint(mouse);
        mouse.z = 0.0f;
        Vector3 mouseDirection = (mouse - transform.position).normalized;
        Debug.DrawLine(transform.position, transform.position + mouseDirection * 5.0f);

        // Shoot weapon with space
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

        // Cycle weapon with left-shift
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            int weaponNumber = (int)++weaponType;
            weaponNumber %= (int)WeaponType.COUNT;
            weaponType = (WeaponType)weaponNumber;
            Debug.Log("Selected weapon: " + weaponType);
        }
    }

    void ShootRifle(Vector3 direction)
    {
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

        Vector3 directionLeft = Quaternion.Euler(0.0f, 0.0f, 30.0f) * direction;
        Vector3 directionRight = Quaternion.Euler(0.0f, 0.0f, -30.0f) * direction;

        bullet.transform.position = transform.position + direction * 0.75f;
        bulletLeft.transform.position = transform.position + directionLeft * 0.75f;
        bulletRight.transform.position = transform.position + directionRight * 0.75f;

        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        bulletLeft.GetComponent<Rigidbody2D>().velocity = directionLeft * bulletSpeed;
        bulletRight.GetComponent<Rigidbody2D>().velocity = directionRight * bulletSpeed;

        Destroy(bullet, 1.0f);
        Destroy(bulletLeft, 1.0f);
        Destroy(bulletRight, 1.0f);
    }

    void ShootGrenade(Vector3 direction)
    {
        Debug.Log("Grenade not implemented");
    }
}
