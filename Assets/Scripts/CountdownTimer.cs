using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CountdownTimer : MonoBehaviour
{
    private string timeToString(float time){
        return TimeSpan.FromSeconds(time).ToString(@"mm\:ss");
    }
    public float currentTime;
    public float startingTime;

    public TMPro.TextMeshProUGUI timer;

    void Start() {
        currentTime = startingTime;
    }

    void Update(){
        if(GameManager.Instance.turnPlayer == GameManager.TurnPlayer.black) return;
        currentTime -= 1*Time.deltaTime;
        timer.text = timeToString(currentTime);
    }
}
