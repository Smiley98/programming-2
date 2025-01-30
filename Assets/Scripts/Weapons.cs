using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.RuleTile.TilingRuleOutput;

public enum WeaponType
{
    RIFLE,
    SHOTGUN,
    GRENADE,
    COUNT
}

public abstract class Weapon
{
    public abstract void Shoot(Vector3 direction, float speed);

    public GameObject shooter;
    public GameObject weaponPrefab;
}

public class Rifle : Weapon
{
    public override void Shoot(Vector3 direction, float speed)
    {
        GameObject bullet = GameObject.Instantiate(weaponPrefab);
        bullet.transform.position = shooter.transform.position + direction * 0.75f;
        bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * speed;
        bullet.GetComponent<SpriteRenderer>().color = Color.red;
        GameObject.Destroy(bullet, 1.0f);
    }
}

public class Weapons : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    GameObject grenadePrefab;

    float bulletSpeed = 10.0f;
    float moveSpeed = 5.0f;

    WeaponType weaponType = WeaponType.RIFLE;
    Weapon rifle = new Rifle();

    void Start()
    {
        rifle.weaponPrefab = bulletPrefab;
        rifle.shooter = gameObject;
    }

    // Optional tasks (next week homework will be assigned based on this code):
    // 1. Fire weapons automatically based on a timer instead of on-key-press.
    // 2. Give each weapon a reload duration and disable them until reloaded.
    // 3. Give each projectile a damage value, spawn targets with health values, apply damage to targets on-collision.
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
                    rifle.Shoot(mouseDirection, bulletSpeed);
                    //ShootRifle(mouseDirection);
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
        bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * bulletSpeed;
        bullet.GetComponent<SpriteRenderer>().color = Color.red;
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

        bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * bulletSpeed;
        bulletLeft.GetComponent<Rigidbody2D>().linearVelocity = directionLeft * bulletSpeed;
        bulletRight.GetComponent<Rigidbody2D>().linearVelocity = directionRight * bulletSpeed;

        bullet.GetComponent <SpriteRenderer>().color = Color.green;
        bulletLeft.GetComponent <SpriteRenderer>().color = Color.green;
        bulletRight.GetComponent <SpriteRenderer>().color = Color.green;

        Destroy(bullet, 1.0f);
        Destroy(bulletLeft, 1.0f);
        Destroy(bulletRight, 1.0f);
    }

    void ShootGrenade(Vector3 direction)
    {
        GameObject grenade = Instantiate(grenadePrefab);
        grenade.transform.position = transform.position + direction * 0.75f;
        grenade.GetComponent<Rigidbody2D>().linearVelocity = direction * bulletSpeed;
        Destroy(grenade, 1.0f);
    }
}
