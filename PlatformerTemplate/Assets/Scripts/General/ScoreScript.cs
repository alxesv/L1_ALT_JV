using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{

    private TimerScript timerScript;
    private TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        timerScript = FindObjectOfType<TimerScript>();
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Your time: " + timerScript.formatTime(timerScript.currentTime);
    }

    // Update is called once per frame
    void Update()
    {   
    }
}
