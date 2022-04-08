using UnityEngine;
using System;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    private float currentTime;
    private float startingTime;
    private bool isRunning;
    
    public TextMeshProUGUI timer;

    public void StartTimer(){
        isRunning = true;
    }

    public void StopTimer(){
        isRunning = false;
    }

    private void updateTimer(){
        timer.text = TimeSpan.FromSeconds(currentTime).ToString(@"h\:mm\:ss");
    }

    void Start() {
        currentTime = startingTime = 60*60;
        isRunning = false;
        timer = gameObject.GetComponent<TextMeshProUGUI>();
        updateTimer();
    }

    void Update(){
        if(!isRunning) return;
        currentTime -= 1*Time.deltaTime;
        updateTimer();
    }
}
