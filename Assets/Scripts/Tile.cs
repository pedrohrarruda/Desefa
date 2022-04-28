using UnityEngine;

public class Tile : MonoBehaviour
{
    private Vector2Int position;
    private int terrain;
    private GameObject piece = null;
    private GameObject highlighTile = null;


    public Tile(Vector2Int position, int terrain)
    {
        this.position = position;
        this.terrain = terrain;
    }

    public Vector2Int GetPosition()
    {
        return this.position;
    }

    public bool HasPiece()
    {
        return this.piece != null;
    }

    public GameObject GetPiece()
    {
        return this.piece;
    }

    public void SetPiece(GameObject newPiece)
    {   
        this.piece = newPiece;
    }

    public void ClearPiece()
    {
        this.piece = null;
    }
    public void DestroyPiece()
    {    
        Destroy(this.piece);
        this.piece = null;
    }

    public bool IsObstacle()
    {
        if (terrain != 0 && terrain != 453 && terrain != 455)
        {
            return true;
        }
        return false;
    }

    public void ActivateHighlight(GameObject highlight)
    {
        highlighTile = highlight;
    }

    public void DeactivateHighlight()
    {
        Destroy(highlighTile);
    }
}
