using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    private void Awake(){
        if(Instance != null && Instance != this){
            Destroy(this);
        }else{
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public enum TurnPlayer {white, black};
    private TurnPlayer turnPlayer;

    public void TurnPlayerWins(){
        //TODO
        Debug.Log(turnPlayer + " wins the game.");
        SceneManager.LoadScene("WinnerScene", LoadSceneMode.Single);
    }

    public void TurnPlayerLose(){
        turnPlayer = (turnPlayer == TurnPlayer.white) ? TurnPlayer.black : TurnPlayer.white;
        TurnPlayerWins();
    }

    public TurnPlayer GetTurnPlayer(){
        return turnPlayer;
    }

    public void SwitchTurn(){
        if(turnPlayer == TurnPlayer.black) turnPlayer = TurnPlayer.white;
        else turnPlayer = TurnPlayer.black;
    }
}
