using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "ScriptableObjects/Piece", fileName = "newPiece")]
public class PieceSO : ScriptableObject
{
    public string type;
    public int level;

    public List<string> getMoves(string type, string position)
    {
        List<string> possibleMoves = new List<string>();
        char[] positionC = position.ToCharArray();
        switch (type)
        {
            case "king":
                positionC[0]++;
                possibleMoves.Add($"{positionC[0]}{positionC[1]}");
                positionC = position.ToCharArray();
                positionC[0]--;
                possibleMoves.Add($"{positionC[0]}{positionC[1]}");
                positionC = position.ToCharArray();
                positionC[1]++;
                possibleMoves.Add($"{positionC[0]}{positionC[1]}");
                positionC = position.ToCharArray();
                positionC[1]--;
                possibleMoves.Add($"{positionC[0]}{positionC[1]}");
                positionC = position.ToCharArray();
                break;

            case "bishop":
                for (int i = 0; i < 8; i++)
                {
                    positionC[0]++;
                    positionC[1]++;
                    possibleMoves.Add($"{positionC[0]}{positionC[1]}");
                }
                positionC = position.ToCharArray();
                for (int i = 0; i < 8; i++)
                {
                    positionC[0]++;
                    positionC[1]--;
                    possibleMoves.Add($"{positionC[0]}{positionC[1]}");
                }
                positionC = position.ToCharArray();
                for (int i = 0; i < 8; i++)
                {
                    positionC[0]--;
                    positionC[1]++;
                    possibleMoves.Add($"{positionC[0]}{positionC[1]}");
                }
                positionC = position.ToCharArray();
                for (int i = 0; i < 8; i++)
                {
                    positionC[0]--;
                    positionC[1]--;
                    possibleMoves.Add($"{positionC[0]}{positionC[1]}");
                }
                positionC = position.ToCharArray();
                break;
            default:
                break;
        }
        return possibleMoves;
    }
}
