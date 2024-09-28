using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    [SerializeField] private bool isActive;
    [SerializeField] public GameObject pauseMenu;

    private void Start()
    {
        isActive = false;
    }
    public void ActivatePasueMenu() {
        if (!isActive)
        {
            pauseMenu.SetActive(true);
            isActive = true;
        }
        else
        {
            pauseMenu.SetActive(false);
            isActive = false;
        }
    }

}
