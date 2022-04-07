using UnityEngine;
using System.Collections.Generic;

public abstract class Piece : MonoBehaviour{
    private bool moveOnce = false;
    private bool firstMove = true;

    private List<Vector2Int> movement = new List<Vector2Int>();
    private Vector2Int position = new Vector2Int();
    private int team; //white(+1), black(-1)

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
                    if(piece == null || piece.team != this.team) moves.Add(pos);
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
}
