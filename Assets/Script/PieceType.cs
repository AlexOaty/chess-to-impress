using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceType : MonoBehaviour
{
    List<string> possibleMoves;
    [SerializeField] PieceSO piece;
    string position;
    GameManager gameManager;
    string type;
    bool enemy;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        possibleMoves = new List<string>();
        type = piece.type;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updatePosition(string position)
    {
        possibleMoves = piece.getMoves(type, position);
    }

    public List<string> getPossibleMoves()
    {
        return possibleMoves;
    }

    public bool isEnemy() { return enemy; }

    public void setEnemy(bool enemy) 
    {
        this.enemy = enemy;
    }
}
