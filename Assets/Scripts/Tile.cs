using UnityEngine;

public class Tile : MonoBehaviour
{
    private Vector2Int position;
    private int terrain;
    private Piece piece;


    public Tile(Vector2Int position){
        this.position = position;
        this.terrain = 0;
    }

    public Vector2Int GetPosition(){
        return this.position;
    }

    public Piece GetPiece(){
        return this.piece;
    }

    public void SetPiece(Piece newPiece){
        this.piece = newPiece;
    }

    public void ClearPiece(){
        this.piece = null;
    }

}
