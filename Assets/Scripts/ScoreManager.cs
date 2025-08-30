using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI points;
    [SerializeField]TextMeshProUGUI moves;
   
    private void Start()
    {
        GameManager.Instance.onCardCheck += GameManager_onCardCheck;
        GameManager.Instance.onGameLoad += GameManager_onGameLoad;
    }

    private void GameManager_onGameLoad(object sender, GameManager.CardActionEventArgs e)
    {
        moves.text = "Moves: " + e.moves;
        points.text = "Points: " + e.points;
    }
    private void GameManager_onCardCheck(object sender, GameManager.CardActionEventArgs e)
    {
        moves.text = "Moves: " + e.moves;
        points.text = "Points: " + e.points;

    }
}
