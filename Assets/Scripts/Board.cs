using UnityEngine;
using System.Collections.Generic;

public class Board : MonoBehaviour
{
    [SerializeField]
    public TextAsset jsonMapa;

    private Tile[,] board;
    private int height;
    private int width;

    public GameObject white_rook, black_rook;
    public GameObject highlightTile;

    private GameObject selectedPiece;


    void Start()
    {
        this.height = JSONMapReader.GetMapHeight(jsonMapa);
        this.width = JSONMapReader.GetMapWidth(jsonMapa);
        this.board = new Tile[this.width + 1, this.height + 1];

        int[,] terrain = JSONMapReader.GetMapMatrix(jsonMapa);

        for (int x = 0; x <= this.width; x++)
            for (int y = 0; y <= this.height; y++)
                board[x, y] = new Tile(new Vector2Int(x, y), terrain[x, y]);

        BoardSetup();
    }

    private void BoardSetup()
    {
        //White setup
        for (int i = (width - 6) / 2; i <= (width + 8) / 2; i++)
        {
            GameObject newPiece = Instantiate(white_rook, new Vector3(), Quaternion.identity);
            board[i, 2].SetPiece(newPiece);
            board[i, 2].GetPiece().GetComponent<Piece>().MoveTo(new Vector2Int(i, 2));
        }

        //Black setup
        for (int i = (width - 6) / 2; i <= (width + 8) / 2; i++)
        {
            GameObject newPiece = Instantiate(black_rook, new Vector3(), Quaternion.identity);
            board[i, height - 1].SetPiece(newPiece);
            board[i, height - 1].GetPiece().GetComponent<Piece>().MoveTo(new Vector2Int(i, height - 1));
        }
    }

    private List<Vector2Int> AvailableMoves = new List<Vector2Int>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2Int mousePosition = MousePositionOnBoard();

            if (mousePosition.x > 0)
            {
                if (selectedPiece == null)
                {
                    SelectPiece(mousePosition);
                }
                else
                {
                    if (IsInAvailableMoves(mousePosition))
                    {
                        if (board[mousePosition.x, mousePosition.y].HasPiece())
                        {
                            GameObject otherPiece = board[mousePosition.x, mousePosition.y].GetPiece();
                            Piece selectedPieceScript = selectedPiece.GetComponent<Piece>();
                            Piece otherPieceScript = otherPiece.GetComponent<Piece>();
                            if (selectedPieceScript.GetTeam() == otherPieceScript.GetTeam())
                            {
                                Debug.Log("Ally");
                                if(PieceMergePotara(selectedPiece,otherPiece)){
                                    Vector2Int piecePosition = selectedPieceScript.GetPosition();
                                    board[piecePosition.x, piecePosition.y].DestroyPiece();
                                }
                            }
                            else
                            {
                                Debug.Log("Enemy");
                                var result = Time2Duel(selectedPieceScript,otherPieceScript);
                                if(result == 0){
                                    Debug.Log("draw");
                                }
                                else if(result == 1){
                                    Vector2Int piecePosition = selectedPiece.GetComponent<Piece>().GetPosition();
                                    board[mousePosition.x, mousePosition.y].DestroyPiece();
                                    board[mousePosition.x, mousePosition.y].SetPiece(board[piecePosition.x, piecePosition.y].GetPiece());
                                    board[mousePosition.x, mousePosition.y].GetPiece().GetComponent<Piece>().MoveTo(mousePosition);
                                    board[piecePosition.x, piecePosition.y].ClearPiece();

                                     //TO DO: transformar esse bloco em uma função
                                }
                                else{
                                Vector2Int piecePosition = selectedPiece.GetComponent<Piece>().GetPosition();
                                board[piecePosition.x, piecePosition.y].DestroyPiece();}
                            }
                        }
                        else
                        {
                            Vector2Int piecePosition = selectedPiece.GetComponent<Piece>().GetPosition();
                            board[mousePosition.x, mousePosition.y].SetPiece(board[piecePosition.x, piecePosition.y].GetPiece());
                            board[mousePosition.x, mousePosition.y].GetPiece().GetComponent<Piece>().MoveTo(mousePosition);

                            board[piecePosition.x, piecePosition.y].ClearPiece(); //TO DO: transformar esse bloco em uma função
                        }

                        GameManager.Instance.SwitchTurn();
                    }

                    UnselectPiece();
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnselectPiece();
        }
    }

    private Vector2Int MousePositionOnBoard()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2Int selectedTile = new Vector2Int();
        selectedTile.x = Mathf.CeilToInt(mousePosition.x);
        selectedTile.y = Mathf.CeilToInt(mousePosition.y);

        //Out of board position
        if (selectedTile.x <= 0 || selectedTile.x > width) selectedTile = new Vector2Int(0, 0);
        if (selectedTile.y <= 0 || selectedTile.y > height) selectedTile = new Vector2Int(0, 0);

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
        if (ValidPos(position) && !IsObstacle(position)) return true;
        return false;
    }

    private bool ValidPos(Vector2Int position)
    {
        if (position.x <= 0 || position.x > this.width) return false;
        if (position.y <= 0 || position.y > this.height) return false;
        return true;
    }

    private bool IsObstacle(Vector2Int vec)
    {
        return board[vec.x, vec.y].IsObstacle();
    }

    private bool IsInAvailableMoves(Vector2Int move)
    {
        return AvailableMoves.Contains(move);
    }

    //Highlite Tiles
    private void SelectPiece(Vector2Int mousePosition)
    {
        selectedPiece = board[mousePosition.x, mousePosition.y].GetPiece();

        if (selectedPiece != null && selectedPiece.GetComponent<Piece>().GetTeam() != GameManager.Instance.GetTurnPlayer())
        {
            selectedPiece = null;
        }

        if(selectedPiece == null) return;

        AvailableMoves = selectedPiece.GetComponent<Piece>().GetAvailableMoves(this);

        for (int i = 0; i < AvailableMoves.Count; i++)
        {
            GameObject highlight = Instantiate(highlightTile, new Vector3(AvailableMoves[i].x - 0.5f, AvailableMoves[i].y - 0.5f, 0), Quaternion.identity);
            board[AvailableMoves[i].x, AvailableMoves[i].y].ActivateHighlight(highlight);
        }
    }

    private void UnselectPiece()
    {
        for (int i = 0; i < AvailableMoves.Count; i++)
        {
            board[AvailableMoves[i].x, AvailableMoves[i].y].DeactivateHighlight();
        }

        AvailableMoves.Clear();
        selectedPiece = null;
    }

    public int Time2Duel(Piece onePiece, Piece twoPiece){  // Função de inicio de combate
        twoPiece.IsAttackedBy(onePiece);
        if(twoPiece.IsAlive()){
            onePiece.IsAttackedBy(twoPiece);
            if(onePiece.IsAlive()){
                return 0;
            }
            else
            return -1;
        }
        else
        return 1;
    }

    public bool PieceMergePotara(GameObject onePiece, GameObject twoPiece){  //função para junção de peças
       if(onePiece.GetComponent<Piece>().GetPieceType() == twoPiece.GetComponent<Piece>().GetPieceType()){
        twoPiece.GetComponent<Piece>().MergePiece(onePiece.GetComponent<Piece>().GetCurrHP());
        return true;   
       }
       else
       return false;
    }
}