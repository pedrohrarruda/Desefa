using UnityEngine;

public class Knight : Piece
{
    // Start is called before the first frame update
    void Start(){
        this.movement.Add(2*Vector2Int.left + Vector2Int.down);
        this.movement.Add(2*Vector2Int.left + Vector2Int.up);
        this.movement.Add(2*Vector2Int.up + Vector2Int.left);
        this.movement.Add(2*Vector2Int.up + Vector2Int.right);
        this.movement.Add(2*Vector2Int.right + Vector2Int.up);
        this.movement.Add(2*Vector2Int.right + Vector2Int.down);
        this.movement.Add(2*Vector2Int.down + Vector2Int.right);
        this.movement.Add(2*Vector2Int.down + Vector2Int.left);

        this.moveOnce = true;

        this.pieceType = PieceType.knight;
        this.attackPower = 25;
        this.maxHitPoints = 10;
        this.currHitPoints = 10;
    }
}
