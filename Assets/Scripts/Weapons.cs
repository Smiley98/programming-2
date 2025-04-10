using UnityEngine;

public enum WeaponType
{
    RIFLE,
    SHOTGUN,
    GRENADE,
    COUNT
}

public abstract class Weapon
{
    public abstract void Shoot(Vector3 direction);

    public void Tick()
    {
        shootCurrent += Time.deltaTime;
    }

    public GameObject weaponPrefab;
    public GameObject shooter;

    public float shootCurrent;  // How far into our shoot cooldown
    public float shootTotal;    // How long it take to shoot

    public float damage;
    public float speed;
    public Color color;

    protected GameObject CreateBullet(Vector3 direction)
    {
        GameObject bullet = GameObject.Instantiate(weaponPrefab);
        bullet.transform.position = shooter.transform.position + direction * 0.75f;
        bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * speed;
        bullet.GetComponent<SpriteRenderer>().color = color;
        bullet.GetComponent<Projectile>().damage = damage;
        return bullet;
    }
}

public class Rifle : Weapon
{
    public override void Shoot(Vector3 direction)
    {
        if (shootCurrent >= shootTotal)
        {
            shootCurrent = 0.0f;

            GameObject bullet = CreateBullet(direction);
            GameObject.Destroy(bullet, 1.0f);
        }
    }
}

public class Shotgun : Weapon
{
    public override void Shoot(Vector3 direction)
    {
        if (shootCurrent >= shootTotal)
        {
            shootCurrent = 0.0f;

            Vector3 directionLeft = Quaternion.Euler(0.0f, 0.0f, 20.0f) * direction;
            Vector3 directionRight = Quaternion.Euler(0.0f, 0.0f, -20.0f) * direction;

            GameObject bullet = CreateBullet(direction);
            GameObject bulletLeft = CreateBullet(directionLeft);
            GameObject bulletRight = CreateBullet(directionRight);

            GameObject.Destroy(bullet, 1.0f);
            GameObject.Destroy(bulletLeft, 1.0f);
            GameObject.Destroy(bulletRight, 1.0f);
        }
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
    Weapon weapon = null;

    void Start()
    {
        rifle.weaponPrefab = bulletPrefab;
        rifle.shooter = gameObject;

        rifle.shootCurrent = 0.0f;
        rifle.shootTotal = 0.25f;

        // TODO: Add shotgun & grenade information d(on't forget about reload & clip-size)!

        weapon = rifle;
    }

    // Optional tasks (next week homework will be assigned based on this code):
    // 1. Fire weapons automatically based on a timer instead of on-key-press.
    // 2. Give each weapon a reload duration and disable them until reloaded.
    // 3. Give each projectile a damage value, spawn targets with health values, apply damage to targets on-collision.
    void Update()
    {
        float dt = Time.deltaTime;

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
        Vector3 movement = direction * moveSpeed * dt;
        transform.position += movement;

        // Aiming with mouse cursor
        Vector3 mouse = Input.mousePosition;
        mouse = Camera.main.ScreenToWorldPoint(mouse);
        mouse.z = 0.0f;
        Vector3 mouseDirection = (mouse - transform.position).normalized;
        Debug.DrawLine(transform.position, transform.position + mouseDirection * 5.0f);

        // Shoot weapon with space
        if (Input.GetKey(KeyCode.Space))
        {
            weapon.shootCurrent += dt;
            if (weapon.shootCurrent >= weapon.shootTotal/*Add a check to make sure there are bullets in your clip*/)
            {
                weapon.shootCurrent = 0.0f;
                weapon.Shoot(mouseDirection);

                // TODO: Subtract from clip size after shooting
                // TODO: Add reload timer
            }
        }
        // if there are no bullets in your clip, perform a reload:
        // -tick the reload timer by delta-time
        // -if the reload timer is expired:
        //      -reset the reload timer
        //      -restore clip ammo to max ammo

        // No longer shooting weapons on-key-press. Holding space and shooting via timer instead!
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    switch (weaponType)
        //    {
        //        case WeaponType.RIFLE:
        //            //ShootRifle(mouseDirection);
        //            rifle.Shoot(mouseDirection, bulletSpeed);
        //            break;
        //
        //        case WeaponType.SHOTGUN:
        //            ShootShotgun(mouseDirection);
        //            break;
        //
        //        case WeaponType.GRENADE:
        //            ShootGrenade(mouseDirection);
        //            break;
        //    }
        //}

        // Cycle weapon with left-shift
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            int weaponNumber = (int)++weaponType;
            weaponNumber %= (int)WeaponType.COUNT;
            weaponType = (WeaponType)weaponNumber;
            Debug.Log("Selected weapon: " + weaponType);
            switch (weaponType)
            {
                case WeaponType.RIFLE:
                    weapon = rifle;
                    break;
                
                case WeaponType.SHOTGUN:
                    // TODO: add shotgun
                    break;
                
                case WeaponType.GRENADE:
                    // TODO: add grenade
                    break;
            }
        }
    }

    // Now using polymorphic Shoot methods to fire our weapons
    /*
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
    */
}
