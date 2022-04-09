using UnityEngine;
using System.Collections.Generic;

public abstract class Piece : MonoBehaviour{
    protected bool moveOnce = false;
    protected bool firstMove = true;

    protected List<Vector2Int> movement = new List<Vector2Int>();
    private Vector2Int position = new Vector2Int();
    public GameManager.TurnPlayer team;

    public virtual List<Vector2Int> GetAvailableMoves(ref Board board){
        List<Vector2Int> moves = new List<Vector2Int>();

        for(int i = 0 ; i < movement.Count ; i++){
            Vector2Int pos = position;

            bool checkNextSquare = true;
            while(checkNextSquare){
                pos = pos + movement[i];
                
                checkNextSquare = board.PieceCanOccupy(pos);
                if(checkNextSquare){
                    Piece piece = board.GetPiece(pos);
                    if(piece == null || piece.GetTeam() != this.GetTeam()) moves.Add(pos);
                    if(piece != null) checkNextSquare = false;
                }
                
                if(moveOnce) checkNextSquare = false;
            }
        }

        return moves;
    }

    public void MoveTo(Vector2Int new_position){
        firstMove = false;
        position = new_position;
        this.transform.position = new Vector3(position.x, position.y);
    }

    public Vector2Int GetPosition(){
        return this.position;
    }

    public GameManager.TurnPlayer GetTeam(){
        return this.team;
    }
}
