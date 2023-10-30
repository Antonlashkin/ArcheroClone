using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField] private float time = 3;
    [SerializeField] public Text timerLabel;
    
    void Start()
    {
        timerLabel.text = time.ToString();
        //Debug.Log("3");
        //Debug.Log(timerLabel.text);
        //Time.timeScale = 0f;
        Thread thread = new Thread(Wait);
        thread.Start();
        //Time.timeScale = 0f;
    }


    private void Wait()
    {
        Time.timeScale = 1f;
        Debug.Log("Thread");
        for (int i = 0; i < 3; i++)
        {
            time -= 1;
            timerLabel.text = time.ToString();
            Thread.Sleep(1000);
            Debug.Log("Thread" + i);
        }
    }








    void Incriment()
    {
        time -= 1;
        timerLabel.text = Mathf.Round(time).ToString();
        if (time == 0)
        {
            timerLabel.text = "";
            Time.timeScale = 1f;
        }
    }

    void On()
    {
        Debug.Log("On");
        Time.timeScale = 0f;
    }
    
    void Off()
    {
        Debug.Log("Off");
        Time.timeScale = 1f;
    }
}
