using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    string Pos;
    [SerializeField] GameObject contains = null;
    [SerializeField] GameManager gameManager;

    public void place(GameObject piece)
    {
        contains = piece;
        if(contains != null)
            contains.GetComponent<PieceType>().updatePosition(Pos);
    }

    public void label(int Row, int Col)
    {
        Pos = (char)(Col+64) + Row.ToString();
        Debug.Log($"Piece {Pos} labelled");
    }

    public string getPos()
    {
        return Pos;
    }

    public GameObject getPiece()
    {
        return contains;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        gameManager.clickTile(gameObject);
    }
}
