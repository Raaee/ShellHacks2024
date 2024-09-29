using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthManger : MonoBehaviour
{
    [SerializeField] private PlayerHealthPoints totalHeathPoints;
    [SerializeField] private Image healhBar;


    private void Update()
    {
        Debug.Log("Current Heath" + totalHeathPoints.GetCurrentHP());
    }

    private void Start()
    {
        Debug.Log((float)totalHeathPoints.GetMaxHealth());
        healhBar.fillAmount = (float)totalHeathPoints.GetMaxHealth();
        totalHeathPoints.OnHealthChange.AddListener(HealtBar);
    }

    public void HealtBar()
    {
        Debug.Log("Current Heath"+totalHeathPoints.GetCurrentHP());
       


        healhBar.fillAmount = (float)totalHeathPoints.GetCurrentHP() / (float)totalHeathPoints.GetMaxHealth();
    }
}
