using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_flip : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] int card_id;
     
    bool isfacingfront;
  
    private void OnMouseDown()
    {
      //  Debug.Log("Flip");
        if (!isfacingfront)
        {
            animator.SetTrigger("FlipIn");
            SendCardId();
            ChangeSide();
            Debug.Log("Card_ID = "+ card_id);
            
        }
    }
    public void ChangeSide()
    {
        isfacingfront = !isfacingfront;
    }
    public void SendCardId()
    {
        GameManager.Instance.AddToPair(card_id);
    }
    public int getID()
    {
        return card_id;

    }
}
