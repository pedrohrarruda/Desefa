using UnityEngine;

public class King : Piece
{
    // Start is called before the first frame update
    void Start(){
        this.movement.Add(Vector2Int.up + Vector2Int.left); //up-left
        this.movement.Add(Vector2Int.up); //up
        this.movement.Add(Vector2Int.up + Vector2Int.right); //up-right
        this.movement.Add(Vector2Int.right); //right
        this.movement.Add(Vector2Int.down + Vector2Int.right); //down right
        this.movement.Add(Vector2Int.down); //down
        this.movement.Add(Vector2Int.down + Vector2Int.left); //down left
        this.movement.Add(Vector2Int.left); //left

        this.moveOnce = true;
        this.pieceType = PieceType.king;
        this.attackPower = 100;
        this.maxHitPoints = 1;
        this.currHitPoints = 1;
    }
}
