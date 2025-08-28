using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public event EventHandler onCardMatch;
    public event EventHandler onCardMismatch; 
    public event EventHandler<CellSize> onGridSelect;
    public class CellSize
    {
        public int row;
        public int column;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private List<Card_flip> opened;
    private void Start()
    {
        opened = new List<Card_flip>();
    }
    //

   public void AddToPair(Card_flip card)
    {
        if (opened.Contains(card))
        {
            opened.Remove(card);
            return;//new
        }
        opened.Add(card);
        CheckCardCount();


   }

   IEnumerator checkCardMatch(Card_flip a, Card_flip b)
   {
   if (a.getID() == b.getID())
   {
       yield return new WaitForSeconds(0.1f);
       a.CardMatch_Animation();
       b.CardMatch_Animation();
       onCardMatch?.Invoke(this, EventArgs.Empty);
   }
   else
   {
       yield return new WaitForSeconds(0.2f);
       a.CardFLipBack_Animation();
       b.CardFLipBack_Animation();
       onCardMismatch?.Invoke(this, EventArgs.Empty);

   }
        CheckCardCount();
   }
   
    public void CheckCardCount()
    {
        if (opened.Count >= 2)
        {
            Card_flip first_Card = opened[0];
            Card_flip second_Card = opened[1];
            opened.RemoveRange(0, 2);
            StartCoroutine(checkCardMatch(first_Card, second_Card));
        }
    }
    //


    public void Easyone()
    {
        onGridSelect?.Invoke(this, new CellSize { 
            row=2,
            column=2 
        });
           
    }
    public void Mediumone()
    {
        onGridSelect?.Invoke(this, new CellSize
        {
            row = 2,
            column = 3
        });

    }
    public void Hardone()
    {
        onGridSelect?.Invoke(this, new CellSize
        {
            row = 5,
            column = 6
        });

    }
}
