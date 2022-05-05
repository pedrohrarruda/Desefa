using UnityEngine;

public class Endgame : MonoBehaviour
{
    private static bool FindKing(Tile[,] board, int row, int col, GameManager.TurnPlayer color){
        for(int i = 1 ; i <= row ; i++){
            for(int j = 1 ; j <= col ; j++){
                GameObject piece = board[j, i].GetPiece();
                if(piece != null){
                    Piece pieceScript = piece.GetComponent<Piece>();
                    
                    if(pieceScript.GetPieceType() == Piece.PieceType.king && pieceScript.GetTeam() == color) return true;
                }
            }
        }
        return false;
    }

    private static bool FindWhiteKing(Tile[,] board, int row, int col){
        return FindKing(board, row, col, GameManager.TurnPlayer.white);
    }

    private static bool FindBlackKing(Tile[,] board, int row, int col){
        return FindKing(board, row, col, GameManager.TurnPlayer.black);
    }

    public static bool FinishGame(Tile[,] board, int height, int width){
        bool hasWhiteKing = FindWhiteKing(board, height, width);
        bool hasBlackKing = FindBlackKing(board, height, width);
        
        GameManager.TurnPlayer turnPlayer;
        turnPlayer = GameManager.Instance.GetTurnPlayer();

        if(hasWhiteKing && hasBlackKing) return false;

        if(turnPlayer == GameManager.TurnPlayer.white){
            if(!hasBlackKing){
                GameManager.Instance.TurnPlayerWins();
                return true;
            }
            if(!hasWhiteKing){
                GameManager.Instance.TurnPlayerLose();
                return true;
            }
        }else{
            if(!hasWhiteKing){
                GameManager.Instance.TurnPlayerWins();
                return true;
            }
            if(!hasBlackKing){
                GameManager.Instance.TurnPlayerLose();
                return true;
            }
        }

        return true;
    }
}
