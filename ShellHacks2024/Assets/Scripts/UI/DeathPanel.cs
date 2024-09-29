using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DeathPanel : MonoBehaviour
{
    // Start is called before the first frame update

    //[SerializeField] private GameObject deathPanels;
    //[SerializeField] private Canvas deathPanel;
    /*public void OnHandleDead()
    {

        //deathPanels.enabled = true;
        Time.timeScale = 0f;


    }*/
    [SerializeField] private Score_Points score;
    [SerializeField] private TextMeshProUGUI TextMesh;

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void setScoreInMenu() {
        TextMesh.text = "Score: " + score.points;
    }

}

