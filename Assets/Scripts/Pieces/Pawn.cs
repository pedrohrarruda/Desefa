using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    public override List<Vector2Int> GetAvailableMoves(ref Board board)
    {
        List<Vector2Int> moves = new List<Vector2Int>();

        Vector2Int position = this.GetPosition();

        Vector2Int upPosition;
        Vector2Int upPosition2;
        if(this.GetTeam() == GameManager.TurnPlayer.white){
            upPosition = position + Vector2Int.up;
            upPosition2 = upPosition + Vector2Int.up;
        }else{
            upPosition = position + Vector2Int.down;
            upPosition2 = upPosition + Vector2Int.down;
        }
        Vector2Int attackLeftPosition = upPosition + Vector2Int.left;
        Vector2Int attackRightPosition = upPosition + Vector2Int.right;

        if(board.PieceCanOccupy(upPosition) && board.GetPiece(upPosition) == null){
            moves.Add(upPosition);

            if(this.firstMove && board.PieceCanOccupy(upPosition2) && board.GetPiece(upPosition2) == null) {
                moves.Add(upPosition2);
            }
        }

        if(board.PieceCanOccupy(attackLeftPosition)){
            Piece piece = board.GetPiece(attackLeftPosition);

            if(piece != null && piece.GetTeam() != this.GetTeam()) moves.Add(attackLeftPosition);
        }

        if(board.PieceCanOccupy(attackRightPosition)){
            Piece piece = board.GetPiece(attackRightPosition);

            if(piece != null && piece.GetTeam() != this.GetTeam()) moves.Add(attackRightPosition);
        }

        return moves;
    }
}
