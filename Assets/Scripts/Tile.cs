using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Vector2Int position;
    private int terrain;
    private GameObject piece;


    public Tile(Vector2Int position){
        this.position = position;
        this.terrain = 0;
    }

    public Vector2Int getPosition(){
        return this.position;
    }

    public GameObject getPiece(){
        return this.piece;
    }

    public void setPiece(GameObject newU){
        this.piece = newU;
    }

    public void clearPiece(){
        this.piece = null;
    }

}
