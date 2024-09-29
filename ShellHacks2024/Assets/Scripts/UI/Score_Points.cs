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
    [SerializeField] private KitsuneAttacks waitToStart;
    [SerializeField] private int wallInterval = 100;

    [HideInInspector] public UnityEvent OnSpeedUpInterval;
    [HideInInspector] public UnityEvent OnSpawnProjectile2;
    private bool alreadySpedUp = false;
    private bool alreadySpawn = false;

    private int UIScore;

   [SerializeField] private float UIScoreMultilplier = 1;


    private void Update()
    {
        AddPointsToScore();
        if (points % wallInterval == 0 && !alreadySpawn && points != 0)
        {
            OnSpawnProjectile2.Invoke();
            alreadySpawn = true;
        }
        if (points % wallInterval != 0)
            alreadySpawn = false;

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
            ScoreMultiplier();
        }
        if (points % speedUpInterval != 0)
        {
            alreadySpedUp = false;
        }

    }
    private void UpdateScoreText()
    {
        //UIScore = points * UIScoreMultilplier;
        score.text = "Score: " + points;
    }


    public void ScoreMultiplier() {
        UIScoreMultilplier *= 1.5f;
    }

}
