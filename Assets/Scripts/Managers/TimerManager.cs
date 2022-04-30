using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public CountdownTimer timerWhite, timerBlack;
    
    public void SwitchTimer(){
        if(GameManager.Instance.GetTurnPlayer() == GameManager.TurnPlayer.white){
            timerWhite.StartTimer();
            timerBlack.StopTimer();
        }else{
            timerWhite.StopTimer();
            timerBlack.StartTimer();
        }
    }
}
