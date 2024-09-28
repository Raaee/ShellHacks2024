using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class Ability : MonoBehaviour
{
    [SerializeField] protected int maxDamage = 10; // The damage normal/max dealt by the projectile
    [SerializeField] protected int currentDamage = 10; // current damage the projectile does
    [SerializeField] protected float maxLifeTime = 2f;
    [SerializeField] public float cooldown;
    [SerializeField] protected bool IsActive;
    protected bool isOnCoolDown = false;
    [HideInInspector] public UnityEvent OnAbilityUsage;


    public IEnumerator UseAbility()
    {
        isOnCoolDown = true;
        AbilityUsage();
        OnAbilityUsage.Invoke();
        yield return new WaitForSeconds(cooldown);
        isOnCoolDown = false;

    }

    public abstract void AbilityUsage();
    public float GetCooldownTime()
    {
        return cooldown;
    }

    public bool GetIsOnCooldown()
    {
        return isOnCoolDown;
    }

    public void SetCooldown(float cd)
    {
        cooldown = cd;
    }
}
