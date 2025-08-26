using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public event EventHandler onCardMatch;
    public event EventHandler onCardFlip;
    
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
    
   public void AddToPair(Card_flip card)
    {
        if (opened.Contains(card)) return;//new
        opened.Add(card);
        if (opened.Count >=2)
        {
            StartCoroutine(checkCardMatch(opened[0], opened[1]));
        }


   }

        IEnumerator checkCardMatch(Card_flip a, Card_flip b)
        {

            opened.Clear();
        if (a.getID() == b.getID())
        {
            yield return new WaitForSeconds(0.5f);
            a.CardMatch_Animation();
            b.CardMatch_Animation();
            Debug.Log("removed = " + a + " and "+ b);//matched
            onCardMatch?.Invoke(this, EventArgs.Empty);

        }
        else
        {
            Debug.Log("not matched = " + a + " and "+ b);//not_matched
            yield return new WaitForSeconds(0.5f);
            a.CardFLipBack_Animation();
            b.CardFLipBack_Animation();
            onCardFlip?.Invoke(this, EventArgs.Empty);

        }

        }


}
