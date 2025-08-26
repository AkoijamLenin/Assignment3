using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_flip : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] int card_id;
     
    bool isfacingfront;//I add this bool to check if the card is currently facing front or back
    bool iscurrentlyChanging;//I add this so that we can't spam the mouse and the animation finishes playing
    private void OnMouseDown()
    {
        if (iscurrentlyChanging)
        {
            return;
        }
        if (!isfacingfront)
        {   
            iscurrentlyChanging = true;
            animator.SetTrigger("FlipIn");
            SendCardId();
         
            Debug.Log("Card_ID = "+ card_id);
            
        }
        else
        {
            iscurrentlyChanging = true;
            CardFLipBack_Animation();
            GameManager.Instance.ClearList();
        }
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
        //Destroy(this.gameObject);
        gameObject.SetActive(false);
    }
    public void Face()
    {
        iscurrentlyChanging = false;
        isfacingfront = true;
    }
    public void Back()
    {
        iscurrentlyChanging = false;
        isfacingfront =false;
    }
}
