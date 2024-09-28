using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Events;

public class Score_Points : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score; 
    private double time = 0.0;
    public int points = 0;
    [SerializeField] private float timerSpeedMultiplier = 3f;
    [SerializeField] private int speedUpInterval = 50;

    public UnityEvent OnSpeedUpInterval;
    public UnityEvent OnSpawnProjectile2;
    private bool alreadySpedUp = false;

    private void Update()
    {
        AddPointsToScore();
        //if (points % 25 == 0)
        //    OnSpawnProjectile2.Invoke();

    }

    private void AddPointsToScore() {
        time += Time.deltaTime * timerSpeedMultiplier;
        points = (int)Math.Floor(time);
        UpdateScoreText();
        if ((points % speedUpInterval == 0 && !alreadySpedUp) && points != 0)
        {
            Debug.Log("invoke");
            OnSpeedUpInterval.Invoke();
            alreadySpedUp = true;
        }
        if (points % speedUpInterval != 0)
        {
            alreadySpedUp = false;
        }
    }
    private void UpdateScoreText()
    {
        score.text = "Score: " + points;
    }

}
