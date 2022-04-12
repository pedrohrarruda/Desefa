using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    private void Awake(){
        if(Instance != null && Instance != this){
            Destroy(this);
        }else{
            Instance = this;
        }
    }

    public enum TurnPlayer {white, black};
    private TurnPlayer turnPlayer;

    public CountdownTimer timerWhite, timerBlack;

    public void TurnPlayerWins(){
        //TODO
        Debug.Log(turnPlayer + " wins the game.");
    }

    public void TurnPlayerLose(){
        turnPlayer = (turnPlayer == TurnPlayer.white) ? TurnPlayer.black : TurnPlayer.white;
        TurnPlayerWins();
    }

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
