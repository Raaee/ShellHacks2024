using System.Collections;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;
using UnityEngine.Events;


public class PlayerHealthPoints : HealthPoints
{
    [SerializeField] private DamageFlash damageFlash;
    [SerializeField] private DeathHandler deathHandler;
    public override void Start()
    {
        base.Start();  
        OnHurt.AddListener(damageFlash.TriggerDamageFlash);
    }
    [ProButton]
    public override void Die()
    {
        deathHandler.OnHandleDead();
        OnHealthChange?.Invoke();
        OnDead?.Invoke();
        Destroy(this.gameObject);
    }

    public override void ResetHealth()
    {
        base.ResetHealth();
    }
}
