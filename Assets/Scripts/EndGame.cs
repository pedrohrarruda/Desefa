using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGame : MonoBehaviour
{
    private TextMeshProUGUI winnerText;

    void Start(){
        winnerText = gameObject.GetComponent<TextMeshProUGUI>();

        if(GameManager.Instance.GetTurnPlayer() == GameManager.TurnPlayer.white) winnerText.text = "White is the winner";
        else winnerText.text = "Black is the winner";
    }

    public void LoadBoard(){
        SceneManager.LoadScene("Board1");
    }
}
