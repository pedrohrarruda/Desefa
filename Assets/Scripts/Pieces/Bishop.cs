using UnityEngine;

public class Bishop : Piece
{
    // Start is called before the first frame update
    void Start(){
        this.movement.Add(Vector2Int.left + Vector2Int.up);
        this.movement.Add(Vector2Int.right + Vector2Int.up);
        this.movement.Add(Vector2Int.right + Vector2Int.down);
        this.movement.Add(Vector2Int.left + Vector2Int.down);

        this.pieceType = PieceType.bishop;
        this.attackPower = 25;
        this.maxHitPoints = 25;
        this.currHitPoints = 25;
    }
}
