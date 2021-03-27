using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool finnished = false;
    private bool started = false;

    // Start is called before the first frame update
    void Start()
    {
        timerText.color = Color.red;
        timerText.text = "00:00";    
    }

    // Update is called once per frame
    void Update()
    {
        if (finnished) return;

        if(started)
        {
            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString("00");
            string seconds = (t % 60).ToString("00");

            timerText.text = minutes + ":" + seconds;
        }
    }

    public void Finnish()
    {
        finnished = true;
        timerText.color = Color.green;
    }
    public void StartTimer()
    {
        startTime = Time.time;
        timerText.color = Color.white;
        started = true;
    }

}
