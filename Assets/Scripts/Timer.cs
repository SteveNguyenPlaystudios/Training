using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float startTime;
    public Text timer;
    public GameManager gameManager;

    float currentTime;
    bool timerStarted = true;
    void Start()
    {
        currentTime = startTime;
        timer.text = currentTime.ToString();
    }


    void Update()
    {
        TimerCounting();
    }

    private void TimerCounting()
    {
        if (timerStarted)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                timerStarted = false;
                currentTime = 0;
                gameManager.GameOver();
            }

            timer.text = currentTime.ToString("f2");
        }
    }
}
