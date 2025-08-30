using System.Collections.Generic;

[System.Serializable]
public class CardData
{
    public int id;
    public string state;
    public float x, y, z;
}

[System.Serializable]
public class GameData
{
    public int points;
    public int moves;
    public List<CardData> cards;
}
