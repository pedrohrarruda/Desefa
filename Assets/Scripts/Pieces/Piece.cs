using UnityEngine;
using System.Collections.Generic;

public abstract class Piece : MonoBehaviour{
    protected bool moveOnce = false;
    protected bool firstMove = true;

    protected int maxHitPoints;
    protected int currHitPoints;

    protected int attackPower;

    protected List<Vector2Int> movement = new List<Vector2Int>();
    private Vector2Int position = new Vector2Int();
    public GameManager.TurnPlayer team;

    protected enum PieceType {rook, bishop, king, queen, pawn, knight};
    protected PieceType pieceType;

    public virtual List<Vector2Int> GetAvailableMoves(Board board){
        List<Vector2Int> moves = new List<Vector2Int>();

        for(int i = 0 ; i < movement.Count ; i++){
            Vector2Int pos = position;

            bool checkNextSquare = true;
            while(checkNextSquare){
                pos = pos + movement[i];
                
                checkNextSquare = board.PieceCanOccupy(pos);
                if(checkNextSquare){
                    moves.Add(pos);
                    if(board.HasPiece(pos)) checkNextSquare = false;
                }
                
                if(moveOnce) checkNextSquare = false;
            }
        }

        return moves;
    }

    public void MoveTo(Vector2Int new_position){
        firstMove = false;
        position = new_position;
        this.transform.position = new Vector3(position.x - 0.5f, position.y - 0.5f);
    }

    public Vector2Int GetPosition(){
        return this.position;
    }

    public GameManager.TurnPlayer GetTeam(){
        return this.team;
    }

    public void IsAttackedBy(Piece opponent){
        this.currHitPoints = (this.currHitPoints - opponent.GetAP());
    }

    public bool IsAlive(){
        return this.currHitPoints>0;
    } 
    public int GetCurrHP(){
        return this.currHitPoints;
    }
    public int GetAP(){
        return this.attackPower;
    }
}
