using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{   public TextAsset jsonMapa;
    public int[,] terrain;

    private Tile[,] Grid;
    private int height;
    private int width;
    
    void Start()
    {
        this.height = JSONMapReader.GetMapHeight(jsonMapa);
        this.width = JSONMapReader.GetMapWidth(jsonMapa);
        this.Grid = new Tile[this.width,this.height];

        for(int x = 0; x < this.width ; x++)
            for(int y = 0; y < this.height ; y++)
                Grid[x,y] = new Tile(new Vector2Int(x,y));

        this.terrain = new int[this.width, this.height];
        terrain = JSONMapReader.GetMapMatrix(jsonMapa);
    }

    public Piece GetPiece(Vector2Int position)
    {
        return this.Grid[position.x, position.y].GetPiece();
    }

    public bool PieceCanOccupy(Vector2Int position)
    {
        if(ValidPos(position) == true && IsObstacle(position) == false)
        {
            return true;
        }
        return false;
    }

    public bool ValidPos(Vector2Int position)
    {
        if ((position.x < 0 || position.x >= this.width) || (position.y < 0 || position.y >= this.height)){
            return false;
        }
        else{
           return true;
        }
    }

    public bool IsObstacle(Vector2Int vec){
        if (terrain[vec.x,vec.y] != 0 || terrain[vec.x,vec.y] != 453 || terrain[vec.x,vec.y] != 455){
            return true;
        }
        return false;
    }
}

