using UnityEngine;

public class Target : TargetBase
{
    public override void TakeDamage(float damage)
    {
        health -= damage;
    }
}
