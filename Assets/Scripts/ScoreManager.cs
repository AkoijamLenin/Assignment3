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
        GameManager.Instance.onCardMismatch += GameManager_onCardFlip;
        GameManager.Instance.onCardMatch += GameManager_onCardMatch;
    }

    private void GameManager_onCardMatch(object sender, System.EventArgs e)
    {
       
       increasePoint_Score();
       increaseMove_Score(); 
      
    }

    private void GameManager_onCardFlip(object sender, System.EventArgs e)
    {
        increaseMove_Score();
    }

    void increaseMove_Score()
    {
        move++;
        moves.text = "Moves: " + move;
    }
    void increasePoint_Score()
    {
        point++;
        points.text = "Points: " + point;
    }
  
}
