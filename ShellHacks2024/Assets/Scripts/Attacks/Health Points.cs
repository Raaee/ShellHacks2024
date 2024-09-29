using System.Collections;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;
using UnityEngine.Events;

public class HealthPoints : MonoBehaviour
{
    [SerializeField] int maxHp = 100;
    [field: SerializeField] public int currentHp { get; set; }
    private bool isDead = false;
    private int previousDamage;

    [HideInInspector] public UnityEvent OnDead;
    [HideInInspector] public UnityEvent OnHurt;
    [HideInInspector] public UnityEvent OnHealthChange;

    public virtual void Start()
    {
        ResetHealth();
    }

    public void RemoveHealth(int damageAmount)
    {
        currentHp -= damageAmount;
        previousDamage = damageAmount;

        if (currentHp <= 0)
        {
            currentHp = 0;
            if (!IsDead())
            {
                isDead = true;
                Die();
            }
            return;
        }
        OnHurt?.Invoke();
        OnHealthChange?.Invoke();
    }
    public bool IsDead()
    {
        return isDead;
    }

    public virtual void Die() { }

    [ProButton]
    public virtual void ResetHealth()
    {
        currentHp = maxHp;
        isDead = false;
        OnHealthChange.Invoke();
    }

    public int GetCurrentHP()
    { 
        return currentHp;
    }
    
    public void SetMaxHealth(int amt)
    {
        maxHp = amt;
        OnHealthChange.Invoke();
    }

    public int GetMaxHealth()
    {
        return maxHp;
    }

    public void SetCurrentHP(int hp)
    {
        currentHp = hp;
    }

    public int GetPreviousDamage()
    {
        return previousDamage;
    }
}
