using Microsoft.Unity.VisualStudio.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Card_flip : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] int card_id;
    [SerializeField] SpriteRenderer cardsprite;
    [SerializeField] Sprite BackGround; 
    [SerializeField] Sprite Front; 
   
    bool iscurrentlyChanging;//I add this so that we can't spam the mouse and the animation finishes playing
    public enum CardState
    {
        face,
        back,
    }
    public CardState card_state;
    private void Start()
    {
     card_state = CardState.back;
     cardsprite.sprite = BackGround; 
    }
    private void OnMouseDown()
    {
        if (iscurrentlyChanging)
        {
            return;
        }
        
        if (card_state==CardState.back)
        {   
            iscurrentlyChanging = true;
            animator.SetTrigger("FlipIn");
            SendCard();
         
        }
        else if(card_state==CardState.face)
        {
            CardFLipBack_Animation();
            SendCard();
        }
    }
   
    private void SendCard()
    {
        GameManager.Instance.AddToPair(this);
      
    }
    public int getID()
    {
        return card_id;

    }
    public void CardFLipBack_Animation()
    {
        iscurrentlyChanging=true;
        //if(iscurrentlyChanging) return;
        animator.SetTrigger("FlipBack");
    }
    public void CardMatch_Animation()
    {
        animator.SetTrigger("CardMatch");
    }
    public void CardDestroy()
    {
        Destroy(this.gameObject);
       // gameObject.SetActive(false);
    }
  
    public void Face()
    {
        iscurrentlyChanging = false;
        card_state = CardState.face;
      
    }
    public void Back()
    {
        iscurrentlyChanging = false;
        card_state = CardState.back;
    }
    public void changeImage()
    {
        Sprite i = cardsprite.sprite;
        if (i==BackGround)
        {
            cardsprite.sprite = Front;
        }
        else
        {
            cardsprite.sprite = BackGround;
        }
    }
}
