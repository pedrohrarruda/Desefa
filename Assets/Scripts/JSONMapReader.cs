using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONMapReader : MonoBehaviour
{
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
    
    public static int GetMapHeight(TextAsset jsonMapa){
        jsonObject json = JsonUtility.FromJson<jsonObject>(jsonMapa.text);
        return json.height;
    }

    public static int GetMapWidth(TextAsset jsonMapa){
        jsonObject json = JsonUtility.FromJson<jsonObject>(jsonMapa.text);
        return json.width;
    }

    public static int[,] GetMapMatrix(TextAsset jsonMapa){
        jsonObject json = JsonUtility.FromJson<jsonObject>(jsonMapa.text);
        //TODO
        int[,] todo = new int[2,2];
        return todo;
    }
}
