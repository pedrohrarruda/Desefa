using UnityEngine;
using System.Collections.Generic;

public class Board : MonoBehaviour
{   
    public TextAsset jsonMapa;

    private Tile[,] board;
    private int height;
    private int width;

    public GameObject white_rook, black_rook;

    public GameObject selectedPiece;
    
    void Start()
    {
        this.height = JSONMapReader.GetMapHeight(jsonMapa);
        this.width = JSONMapReader.GetMapWidth(jsonMapa);
        this.board = new Tile[this.width+1,this.height+1];

        int[,] terrain = JSONMapReader.GetMapMatrix(jsonMapa);

        for(int x = 0; x <= this.width ; x++)
            for(int y = 0; y <= this.height ; y++)
                board[x,y] = new Tile(new Vector2Int(x,y), terrain[x, y]);
        
        BoardSetup();
    }

    private void BoardSetup(){
        //White setup
        for(int i = (width - 6)/2 ; i <= (width + 8)/2 ; i++){
            GameObject newPiece = Instantiate(white_rook, new Vector3(), Quaternion.identity);
            board[i, 2].SetPiece(newPiece);
            board[i, 2].GetPiece().GetComponent<Piece>().MoveTo(new Vector2Int(i, 2));
        }

        //Black setup
        for(int i = (width - 6)/2 ; i <= (width + 8)/2 ; i++){
            GameObject newPiece = Instantiate(black_rook, new Vector3(), Quaternion.identity);
            board[i, height-1].SetPiece(newPiece);
            board[i, height-1].GetPiece().GetComponent<Piece>().MoveTo(new Vector2Int(i, height-1));
        }
    }

    private List<Vector2Int> AvailableMoves = new List<Vector2Int>();

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Vector2Int mousePosition = MousePositionOnBoard();
            /*
            TODO
            // movimentar as peças
            // selecionar as peças
            // deselecionar as peças
            */

            if(mousePosition.x > 0){
                if(selectedPiece == null){
                    selectedPiece = board[mousePosition.x, mousePosition.y].GetPiece();

                    if(selectedPiece != null && selectedPiece.GetComponent<Piece>().GetTeam() != GameManager.Instance.GetTurnPlayer()){
                        selectedPiece = null;
                    }

                    if(selectedPiece != null) AvailableMoves = selectedPiece.GetComponent<Piece>().GetAvailableMoves(this);
                }else{
                    if(IsInAvailableMoves(mousePosition)){
                        if(board[mousePosition.x, mousePosition.y].HasPiece()){
                            GameObject otherPiece = board[mousePosition.x, mousePosition.y].GetPiece();
                            if(selectedPiece.GetComponent<Piece>().GetTeam() == otherPiece.GetComponent<Piece>().GetTeam()){
                                Debug.Log("Ally");
                            }else{
                                Debug.Log("Enemy");
                            }
                        }else{
                            Vector2Int piecePosition = selectedPiece.GetComponent<Piece>().GetPosition();
                            board[mousePosition.x, mousePosition.y].SetPiece(board[piecePosition.x, piecePosition.y].GetPiece());
                            board[mousePosition.x, mousePosition.y].GetPiece().GetComponent<Piece>().MoveTo(new Vector2Int(mousePosition.x, mousePosition.y));

                            board[piecePosition.x, piecePosition.y].ClearPiece();
                        }

                        GameManager.Instance.SwitchTurn();
                    }

                    selectedPiece = null;
                    AvailableMoves.Clear();
                }
            }
        }else if(Input.GetKeyDown(KeyCode.Escape)){
            selectedPiece = null;
            AvailableMoves.Clear();
        }
    }

    private Vector2Int MousePositionOnBoard()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2Int selectedTile = new Vector2Int();
        selectedTile.x = Mathf.CeilToInt(mousePosition.x);
        selectedTile.y = Mathf.CeilToInt(mousePosition.y);

        //Out of board position
        if(selectedTile.x <= 0 || selectedTile.x > width) selectedTile = new Vector2Int(0, 0);
        if(selectedTile.y <= 0 || selectedTile.y > height) selectedTile = new Vector2Int(0, 0);

        return selectedTile;
    }

    public bool HasPiece(Vector2Int position)
    {
        return this.board[position.x, position.y].HasPiece();
    }

    public GameObject GetPiece(Vector2Int position)
    {
        return this.board[position.x, position.y].GetPiece();
    }

    public bool PieceCanOccupy(Vector2Int position)
    {
        if(ValidPos(position) && !IsObstacle(position)) return true;
        return false;
    }

    private bool ValidPos(Vector2Int position)
    {
        if(position.x <= 0 || position.x > this.width) return false;
        if(position.y <= 0 || position.y > this.height) return false;
        return true;
    }

    private bool IsObstacle(Vector2Int vec)
    {
        return board[vec.x, vec.y].IsObstacle();
    }

    private bool IsInAvailableMoves(Vector2Int move){
        return AvailableMoves.Contains(move);
    }
}

