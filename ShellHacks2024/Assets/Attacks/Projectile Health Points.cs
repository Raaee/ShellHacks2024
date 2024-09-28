using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHealthPoints : HealthPoints
{
    // Start is called before the first frame update
    public override void Die()
    {
        OnHealthChange.Invoke();
        OnDead?.Invoke();
        Destroy(this.gameObject);
    }
}
