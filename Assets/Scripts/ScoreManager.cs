using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI points;
    [SerializeField]TextMeshProUGUI moves;
    int point;
    int move;
    private void Start()
    {
        GameManager.Instance.onCardFlip += GameManager_onCardFlip;
        GameManager.Instance.onCardMatch += GameManager_onCardMatch;
    }

    private void GameManager_onCardMatch(object sender, System.EventArgs e)
    {
        point++;
        move++;
        points.text = "Points: " + point;
        moves.text = "Moves: " + move;
    }

    private void GameManager_onCardFlip(object sender, System.EventArgs e)
    {
        move++;
        moves.text = "Moves :" + move;
    }
}
