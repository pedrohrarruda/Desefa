using UnityEngine;

public class Pawn : Piece
{
    public void Start(){
        this.movement.Add(Vector2Int.up);
        this.movement.Add(Vector2Int.left);
        this.movement.Add(Vector2Int.down);
        this.movement.Add(Vector2Int.right);

        this.moveOnce = true;

        this.pieceType = PieceType.pawn;
        this.attackPower = 10;
        this.maxHitPoints = 10;
        this.currHitPoints = 10;
    }
}
