using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public event EventHandler<CardActionEventArgs> onCardCheck;
    public event EventHandler<CardActionEventArgs> onGameLoad;
    public event EventHandler onGameOver; 
    public event EventHandler<CellSize> onGridSelect;
    private List<Card_flip> opened;
    private List<GameObject> All_Cards = new List<GameObject>();
    private bool GameStart;
    private int points;
    private int moves;
    [SerializeField] private GameObject cardPrefab;
    public class CellSize
    {
        public int row;
        public int column;
    }
    public class CardActionEventArgs
    {
        public int points;
        public int moves;
        public bool isMatched;
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

    private void Start()
    {
        opened = new List<Card_flip>();
    }
    public void AddToPair(Card_flip card)
    {
        if (opened.Contains(card)) return;//new       
        opened.Add(card);
        CheckCardCount();
   }
    IEnumerator checkCardMatch(Card_flip a, Card_flip b)
    {
        if (a.getID() == b.getID())
        {
            yield return new WaitForSeconds(0.2f);
            a.CardMatch_Animation();
            b.CardMatch_Animation();
            points++;
            moves++;
            onCardCheck?.Invoke(this, new CardActionEventArgs 
            {
                points = points,
                moves = moves,
                isMatched = true
            });
        }
        else
        {
            yield return new WaitForSeconds(0.2f);
            a.CardFLipBack_Animation();
            b.CardFLipBack_Animation();
            moves++;
            onCardCheck?.Invoke(this, new CardActionEventArgs 
            { 
                points = points,
                moves = moves,
                isMatched = false
            });
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
    public void Delete_From_Opened(Card_flip card)
    {
        if(opened.Count > 0&&opened.Contains(card))
        {
            opened.Remove(card);
        }
    }
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
    public void StartGame(List<GameObject>All_Cards)
    {
        onGameLoad?.Invoke(this, new CardActionEventArgs
        {
            moves = moves,
            points = points,
        });
        GameStart = true;
        this.All_Cards = new List<GameObject>(All_Cards);
          
    }
    public void RemoveCard(GameObject card)
    {
        if (All_Cards.Contains(card))
        {
            All_Cards.Remove(card);
            if (All_Cards.Count == 0)
            {
                moves = 0;
                points = 0;
                GameStart = false;
                onGameOver?.Invoke(this, EventArgs.Empty);
            }
        }
    }
    private void OnApplicationQuit()
    {
        if(GameStart)
        SaveGame();
    }
    private void SaveGame()
    {
        GameData gameData_Obj = new GameData();
        gameData_Obj.cards = new List<CardData>();
        foreach(GameObject temp_cards in All_Cards)
        {
            CardData c=new CardData();
            Card_flip card=temp_cards.GetComponent<Card_flip>();
            c.id=card.getID();
            c.sprite = card.getSprite();
            c.x = card.transform.position.x;
            c.y = card.transform.position.y;
            c.z = card.transform.position.z;
            c.scale_x= card.transform.localScale.x;
            c.scale_y= card.transform.localScale.y;
            gameData_Obj.cards.Add(c);
        }
        gameData_Obj.points=points;
        gameData_Obj.moves=moves;
        SaveSystem.SaveGame(gameData_Obj);
    }
    public void LoadGame()
    {   
        GameData game_Data=SaveSystem.LoadGame();
        if (game_Data == null)
        {
            return;
        }
        GameStart = true;
        foreach (GameObject cardObj in All_Cards)
        {
            if (cardObj != null) Destroy(cardObj);
        }
        All_Cards.Clear();
        moves=game_Data.moves;
        points=game_Data.points;
        onGameLoad?.Invoke(this, new CardActionEventArgs
        {
            points = points,
            moves = moves,
        });
        foreach (CardData c in game_Data.cards)
        {
            GameObject cardObj = Instantiate(cardPrefab, new Vector3(c.x, c.y, c.z), Quaternion.identity);
            Card_flip card = cardObj.GetComponent<Card_flip>();
            card.transform.localScale=new Vector3(c.scale_x,c.scale_y,0f);
            card.Card_SetUp(c.id,c.sprite);
            All_Cards.Add(cardObj);
        }
    }
}
