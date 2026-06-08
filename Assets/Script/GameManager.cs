using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Burst.CompilerServices;
using UnityEditor.Rendering;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject WhiteCell;
    [SerializeField] private GameObject BlackCell;
    [SerializeField] private GameObject StartCell;
    [SerializeField] private List<GameObject> pieces;
    private GameObject[] Tiles;
    GameObject selected;
    Tile selectedTile;
    // Start is called before the first frame update
    void Start()
    {
        BuildBoard();
        Tiles = GameObject.FindGameObjectsWithTag("Tile");
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var tile in Tiles)
        {
            Tile tileScr = tile.GetComponent<Tile>();
            if(tileScr.getPiece() != null)
            {
                tileScr.getPiece().transform.position = tile.transform.position;
            }
        }
    }

    void BuildBoard()
    {
        GameObject newCell;
        GameObject newPiece;
        int cellColour = 0;
        int Row = 0;
        int Col = 0;
        float x = StartCell.transform.position.x;
        float y = StartCell.transform.position.y;
        for (int i = 0; i < 8; i++)
        {
            Row++;
            Col = 0;
            if(i > 0)
            {
                y += StartCell.transform.localScale.y;
                x = StartCell.transform.localPosition.x;
                cellColour++;
            }
            for (int j = 0; j < 8; j++)
            {
                Col++;
                if (cellColour % 2 == 0) { 

                    newCell = Instantiate(WhiteCell, new Vector3(x, y, 0f), Quaternion.identity);
                }
                else
                {
                    newCell = Instantiate(BlackCell, new Vector3(x, y, 0f), Quaternion.identity);
                }
                newCell.GetComponent<Tile>().label(Row, Col);
                if(cellColour == 0)
                {
                    newPiece = Instantiate(pieces[0]);
                    newCell.GetComponent<Tile>().place(pieces[0]);
                }
                if(cellColour == 10)
                {
                    newPiece = Instantiate(pieces[1]);
                    newCell.GetComponent<Tile>().place(pieces[1]);
                }
                if(cellColour == 20)
                {
                    newPiece = Instantiate(pieces[2]);
                    newCell.GetComponent<Tile>().place(pieces[2]);
                    newCell.GetComponent<Tile>().getPiece().GetComponent<PieceType>().setEnemy(true);
                }
                newCell.tag = "Tile";
                cellColour++;
                x += StartCell.transform.localScale.x;
            }
        }
    }

    public void clickTile(GameObject tileGO)
    {
        Tile tile = tileGO.GetComponent<Tile>();
        if (tile.getPiece() != null && selected == null)
        {
            if (!tile.getPiece().GetComponent<PieceType>().isEnemy())
            {
                selected = tile.getPiece();
                selectedTile = tile;
            }
        }
        else if (tile.getPiece() == null && selected != null)
        {
            if (selected.GetComponent<PieceType>().getPossibleMoves().Contains(tile.getPos()))
            {
                selectedTile.place(null);
                tile.place(selected);
            }
            selected = null;
            selectedTile = null;
        }
        else if (tile.getPiece() != null && tile.getPiece().GetComponent<PieceType>().isEnemy() && selected != null)
        {
            if (selected.GetComponent<PieceType>().getPossibleMoves().Contains(tile.getPos()))
            {
                Destroy(tile.getPiece());
                tile.place(null);
                selectedTile.place(null);
                tile.place(selected);
            }
            selected = null;
            selectedTile = null;
        }
        else
        {
            selected = null;
            selectedTile = null;
        }
            Debug.Log($"Tile Clicked: {tile.getPos()}");
    }
}
