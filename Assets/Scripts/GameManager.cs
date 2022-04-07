using UnityEngine;

public class GameManager : MonoBehaviour
{
    private enum TurnPlayer {white, black};
    private TurnPlayer turnPlayer;

    public CountdownTimer timerWhite, timerBlack;

    

    public void SwitchTurn(){
        turnPlayer = (turnPlayer == TurnPlayer.white) ? TurnPlayer.black : TurnPlayer.white;

        if(turnPlayer == TurnPlayer.white){
            timerWhite.StartTimer();
            timerBlack.StopTimer();
        }else{
            timerWhite.StopTimer();
            timerBlack.StartTimer();
        }
    }
}
