using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Player", fileName = "newPlayer")]
public class PlayerInfo : ScriptableObject
{
    int coins;
    PieceType[] Pieces;
}
