using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{
    // Start is called before the first frame update
    void Start(){
        this.movement.Add(Vector2Int.up);
        this.movement.Add(Vector2Int.left);
        this.movement.Add(Vector2Int.down);
        this.movement.Add(Vector2Int.right);
    }
}
