using UnityEngine;

public class Queen : Piece
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

        this.pieceType = PieceType.queen;
        this.attackPower = 50;
        this.maxHitPoints = 20;
        this.currHitPoints = 20;
    }
}
