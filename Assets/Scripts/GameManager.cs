using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum TurnPlayer {white, black};

    public TurnPlayer turnPlayer;
    
    public static GameManager Instance;

    private void Awake(){
        if(Instance != null){
            Destroy(gameObject);
        }else{
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void switchPlayer(){
        turnPlayer = (turnPlayer == TurnPlayer.white) ? TurnPlayer.black : TurnPlayer.white;
    }
}
