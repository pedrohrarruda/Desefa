using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class layer{
    public int[] data;
    public int height;
    public int id;
    public string name;
    public int opacity;
    public string type;
    public bool visible;
    public int width;
    public int x;
    public int y; 
}

[System.Serializable]
public class tileset{
    public int colunms;
    public int firstgid;
    public string image;
    public int imageheight;
    public int imagewidth;
    public int margin;
    public string name;
    public int spacing;
    public int tilecount;
    public int tileheight;
    public int tilewidth;
}
[System.Serializable]
public class jsonObject{
    public string compressionlevel;
    public int height;
    public bool infinite;
    public layer[] layers;
    public int nextlayerid;
    public int nextobjectid;
    public string orientation;
    public string renderorder;
    public string tiledversion;
    public int tileheight;
    public tileset[] tilesets;
    public string tilewidth;
    public string type;
    public string version;
    public int width;
}



public class Board : MonoBehaviour
{   public TextAsset jsonMapa;
    public int[,] terrain;

    private Tile[,] Grid;
    private int height;
    private int width;
    
    void Start()
    {
        jsonObject json = JsonUtility.FromJson<jsonObject>(jsonMapa.text);
        this.height = json.height;
        this.width = json.width;
        this.Grid = new Tile[this.width,this.height];

        for(int x = 0; x<this.width; x++){
            for(int y = 0; y<this.height; y++){
                Grid[x,y] = new Tile(new Vector2Int(x,y));
            }
        }

        this.terrain = new int[this.width, this.height];
        terrain = Matrixaux(json.layers[1].data);    
    }

    
    void Update()
    {
        
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
        if ((position.x<0 || position.x>=this.width) || (position.y<0 || position.y>=this.height)){
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

    private int[,] Matrixaux(int[] layerInts){
        int[,] temp = new int[this.width, this.height];
        for (int a = 0; a < layerInts.Length; a++) {
            temp[a % this.width, a / this.height] = layerInts[a];
        }
        return temp;
    }
}

