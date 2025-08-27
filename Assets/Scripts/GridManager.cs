using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    //2X2 2X3 5X6
    
    [SerializeField] List<GameObject>cardPrefabs;
    [SerializeField] List<GameObject>random_Selectable_Cards;
    private int numberofCards;
    private int rows;
    private int column;
    private float top_Offset=2f;// Its to add a offset gap from the top so that the cards stay in screen 
    void Start()
    {
        GameManager.Instance.onGridSelect += GameManager_onGridSelect;
    }

    private void GameManager_onGridSelect(object sender, GameManager.CellSize e)
    {
        rows=e.row;
        column = e.column;
       
        Set_Selectable_Cards();
        GenerateGrid();
        
    }

    void GenerateGrid()
    {
        float camHeight = Camera.main.orthographicSize * 2f;
        camHeight = camHeight - top_Offset;//
        float camWidth =camHeight * Camera.main.aspect;
        float cellWidth =camWidth / column;
        float cellHeight =camHeight /rows;

        SpriteRenderer sr = cardPrefabs[0].GetComponentInChildren<SpriteRenderer>();
        Vector2 cardSize = sr.bounds.size;
        float scaleX = cellWidth /cardSize.x;
        float scaleY = cellHeight  / cardSize.y ;//new
        float finalScale=  Mathf.Min(scaleX, scaleY); 

       //


        for (int j=0;j<rows;j++)
        {
             for (int i=0;i<column;i++)
             {
                float _posX =-camWidth /2 + cellWidth *(i + 0.5f);
                float _posY =camHeight /2 - cellHeight *(j + 0.5f);

                int random_Pos = Random.Range(0, random_Selectable_Cards.Count);
               
                GameObject randomCard = random_Selectable_Cards[random_Pos];
                random_Selectable_Cards.Remove(random_Selectable_Cards[random_Pos]);
                GameObject card =Instantiate(randomCard, new Vector3(_posX, _posY, 0), Quaternion.identity);
                card.transform.localScale = new Vector3(finalScale, finalScale+0.5f, 0f);
             }
        }
    }

   
    void Set_Selectable_Cards()
    {
        List<GameObject>temp=new List<GameObject>(cardPrefabs);
        numberofCards = rows * column;
        

        for (int i = 0; i < numberofCards;)
        {
            int random_Pos = Random.Range(0,temp.Count);
            Debug.Log("count temp =" + temp.Count);
            GameObject randomCard = temp[random_Pos];
            temp.Remove(temp[random_Pos]);
            if (temp.Count == 0) { Debug.Log("count temp before =" + temp.Count); temp = new List<GameObject>(cardPrefabs); Debug.Log("count card  =" + cardPrefabs.Count); Debug.Log("count temp after =" + temp.Count); }
           
            for (int j = 0; j < 2; j++)
            { 
                random_Selectable_Cards.Add(randomCard);
                i++;
            }



        
        }

    }



}
