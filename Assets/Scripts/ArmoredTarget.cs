using UnityEngine;

public class ArmoredTarget : TargetBase
{
    public override void TakeDamage(float damage)
    {
        health -= damage * 0.5f;
    }
}
