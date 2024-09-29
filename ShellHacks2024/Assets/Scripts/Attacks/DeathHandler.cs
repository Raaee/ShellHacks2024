using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    private PlayerHealthPoints playerHealthPoints;
    [SerializeField] public GameObject deathPanel;
    
  

    private void Awake()
    {
        playerHealthPoints = GetComponent<PlayerHealthPoints>();
        deathPanel.SetActive(false);
        //playerHealthPoints.OnDead.AddListener(OnHandleDead);
        
    }
    
    public void OnHandleDead()
    {
        
        deathPanel.SetActive(true);
        deathPanel.GetComponentInParent<DeathPanel>().setScoreInMenu();
        Time.timeScale = 0f;

        
    }

  

    

   

    
}
