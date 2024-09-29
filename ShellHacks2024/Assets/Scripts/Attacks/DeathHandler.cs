using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    private PlayerHealthPoints playerHealthPoints;
    [SerializeField] private Canvas deathPanel;
    
  

    private void Awake()
    {
        playerHealthPoints = GetComponent<PlayerHealthPoints>();
        deathPanel.enabled = false;
        playerHealthPoints.OnDead.AddListener(OnHandleDead);
        
    }
    
    private void OnHandleDead()
    {
        
        deathPanel.enabled = true;
        Time.timeScale = 0f;

        
    }

  

    

   

    
}
