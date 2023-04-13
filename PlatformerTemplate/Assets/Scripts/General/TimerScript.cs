using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimerScript : MonoBehaviour
{
    public float currentTime;
    public bool timerOn = false;
    public TMP_Text Timer;
    private GameManager gameManager;

    void Awake()
        {
            gameManager = FindObjectOfType<GameManager>();
        }
    void Start()
    {   
        currentTime = 0f;
        timerOn = true;
    }
    void Update()
    {
        if(!timerOn || gameManager._isOver)
        {
            return;
        }
        currentTime += 1 * Time.deltaTime;
        updateTimer(currentTime);
    }

    public string formatTime(float time){
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        float milliseconds = (time % 1) * 1000;
        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
    public void updateTimer(float time)
    {
        currentTime = time;
        Timer.text = formatTime(currentTime);
    }

}
