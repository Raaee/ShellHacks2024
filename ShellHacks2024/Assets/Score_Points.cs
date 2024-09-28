using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Score_Points : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score; 
    private double time = 0.0;
    private int points = 0;

    private void Update()
    {
        AddPointsToScore();
    }

    private void AddPointsToScore() {
        time += Time.deltaTime * 2;
        //if (Math.Floor(time) % 2 == 0) points++;
        score.text = "Score: " + Math.Floor(time);
    }

}
