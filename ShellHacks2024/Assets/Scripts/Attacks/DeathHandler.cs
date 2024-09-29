using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    private ProjectileHealthPoints projectileHealthPoints;
    private SpriteRenderer spriteRenderer;
  

    private void Awake()
    {
        projectileHealthPoints = GetComponent<ProjectileHealthPoints>();
        projectileHealthPoints.OnDead.AddListener(OnHandleDead);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void OnHandleDead()
    {
        StopMoving();
        StopAttacking();
        
    }

    private void StopAttacking()
    {
     
    }

    private void StopMoving()
    {
        //Enemy Movement

    }

    

   

    
}
