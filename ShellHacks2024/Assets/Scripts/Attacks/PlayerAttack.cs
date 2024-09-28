using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAttack : Ability
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int maxPiercingAmount = 1;
    private InputManager inputManager;
    [SerializeField] private bool isPlayerShooting;
    [SerializeField] private Transform firePoint;

    private void Awake()
    {
        inputManager = FindObjectOfType<InputManager>();
        inputManager.OnAttackInput.AddListener(ShootIfActive);
    
    }
    private void SpawnProjectile(Vector2 moveDirection)
    {
        GameObject go = Instantiate(projectilePrefab, transform);
        go.transform.position = firePoint.position;
        NewProjectile projectile = go.GetComponent<NewProjectile>();
        projectile.SetMoveDirection(moveDirection,isPlayerShooting);
        projectile.CurrentDamage = currentDamage;
        projectile.SetLifeTime(maxLifeTime);
        
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
        SpawnProjectile(Vector2.right);
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
