using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private int[] position;
    private int terrain;
    private GameObject piece;


    public Tile(int x,int y){
        this.position = new int [2] {x,y};
        this.terrain = 0;
    }

    public int[] getPosition(){
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
