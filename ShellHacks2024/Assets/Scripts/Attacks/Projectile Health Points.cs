using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHealthPoints : HealthPoints
{
    public override void Die()
    {
        OnHealthChange.Invoke();
        OnDead?.Invoke();
        Destroy(this.gameObject);
    }
}
