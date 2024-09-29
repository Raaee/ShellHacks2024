using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAttack : Ability
{
    [SerializeField] private GameObject projectilePrefab;
    private InputManager inputManager;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform parent;

    private void Awake()
    {
        inputManager = FindObjectOfType<InputManager>();
        inputManager.OnAttackInput.AddListener(ShootIfActive);
    
    }
    private void SpawnProjectile()
    {
        GameObject go = Instantiate(projectilePrefab, parent);
        go.transform.position = firePoint.position;
        NewProjectile projectile = go.GetComponent<NewProjectile>();
        projectile.CurrentDamage = maxDamage;
    }

    private void ShootIfActive()
    {
        if (isOnCoolDown)
        {
            return;
        }
        
        StartCoroutine(UseAbility());
        

    }

    public override void AbilityUsage()
    {
        SpawnProjectile();
    }

    public int GetMaxDanmage()
    {
        return maxDamage;
    }

    public void SetMaxDamage(int amount)
    {
        maxDamage = amount;
    }

    public GameObject GetProjectilePrefab()
    {
        return projectilePrefab;
    }
}
