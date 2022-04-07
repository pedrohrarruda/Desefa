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
{
    public jsonObject json = JsonUtility.FromJson(jsonMapa.txt);
    public GameObject place_holder;
    public GameObject tile;
    public Tile[,] Grid = new Tile [40,20];
    public int[,] terrain = new int [40,20];
    
    async void Start()
    {
        for(int x = 0; x<40; x++){
            for(int y = 0; y<20; y++){
                Grid[x,y] = new Tile(x,y);
            }
        }

        terrain = matrixaux(this.json.layers[1].data);    
    }

    
    void Update()
    {
        
    }

    public bool validPos(int x,int y)
    {
        if ((x<0 || x>40) || (y<0 || y>20)){
            return false;
        }
        else{
           return true;
        }
    }

    public bool isObstacle(Vector2Int vec){
        if (terrain[vec.x,vec.y] =! 0 || terrain[vec.x,vec.y] =! 453 ||terrain[vec.x,vec.y] =! 455){
            return true;
        }
        return false;
    }

    public int[,] matrixaux(int[] layerInts){
        int[,] tem = new int[40, 20];
        for (int a = 0; a < layerInts.Length; a++) {
            result[a % 40, a / 40] = arr[a];
        }
        return result;
    }
}

