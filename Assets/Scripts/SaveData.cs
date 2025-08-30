using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardData
{
    public int id;
    public Sprite sprite;
    public float x, y, z;
}

[System.Serializable]
public class GameData
{
    public int points;
    public int moves;
    public List<CardData> cards;
}
