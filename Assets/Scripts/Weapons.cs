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

    protected GameObject CreateBullet(Vector3 direction)
    {
        GameObject bullet = GameObject.Instantiate(weaponPrefab);
        bullet.transform.position = shooter.transform.position + direction;
        bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * speed;
        bullet.GetComponent<SpriteRenderer>().color = color;

        Projectile projectile = bullet.GetComponent<Projectile>();
        projectile.team = team;
        projectile.damage = damage;

        GameObject.Destroy(bullet, life);

        return bullet;
    }

    public GameObject weaponPrefab;
    public GameObject shooter;

    public float shootCurrent;  // How far into our shoot cooldown
    public float shootTotal;    // How long it take to shoot

    public float damage;
    public float speed;
    public float life;

    public Color color;
    public Team team;
}

public class Rifle : Weapon
{
    public override void Shoot(Vector3 direction)
    {
        if (shootCurrent >= shootTotal)
        {
            shootCurrent = 0.0f;
            CreateBullet(direction);
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

            CreateBullet(direction);
            CreateBullet(directionLeft);
            CreateBullet(directionRight);
        }
    }
}
