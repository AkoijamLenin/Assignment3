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
    private void SendCardId()
    {
        GameManager.Instance.AddToPair(this);
      
    }
    public int getID()
    {
        return card_id;

    }
    public void CardFLipBack_Animation()
    {
        animator.SetTrigger("FlipBack");
    }
    public void CardMatch_Animation()
    {
        animator.SetTrigger("CardMatch");
    }
    public void CardMatch()
    {


        selfDestroy();
    }
    private void selfDestroy()
    {
        Destroy(this.gameObject);
    }
}
