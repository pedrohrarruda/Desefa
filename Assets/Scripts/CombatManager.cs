using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Piece;

public class CombatManager : MonoBehaviour{
    private List<Piece> pieceRegistry;
    public CombatManager(){
        this.pieceRegistry = new List<Piece>();
    }

    public void StartRegistry(List<Piece> StartingCondition){
        this.pieceRegistry = StartingCondition;
    }

    public void AddToRegistry(Piece OnePiece){
        var registry = this.pieceRegistry;
        this.pieceRegistry = registry.Add(OnePiece);
    }

    public void RemoveFromRegistry(Piece OnePiece){
        var registry = this.pieceRegistry;
        this.pieceRegistry = registry.Where(keepPeace => keepPeace != OnePiece.Id).ToList<Piece>();
    }

    public int Time2Duel(Piece OnePiece, Piece TwoPiece){
        TwoPiece.IsAttackedBy(OnePiece);
        if(TwoPiece.IsAlive()){
            OnePiece.IsAttackedBy(TwoPiece);
            if(OnePiece.IsAlive()){
                return 0;
            }
            else
            return 2;
        }
        else
        return 1;
    }
}