using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tile;

public class Board : MonoBehaviour
{
    public GameObject place_holder;
    public GameObject tile;
    public Tile[,] Grid = new Tile [40,20];


    private int mapStartX = 0;
    private int mapStartY = 0;
    
    async void Start()
    {
        for(int x = 0; x<40; x++){
            for(int y = 0; y<20; y++){
                Grid[x,y] = new Tile(x,y);
            }
        }    
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


}

