using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    //2X2 2X3 5X6
    [SerializeField] GameObject cardPrefab;
    [SerializeField] int rows = 2;
    [SerializeField] int column = 2;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        
        float camHeight = Camera.main.orthographicSize * 2f;
        float camWidth = camHeight * Camera.main.aspect;

         float cellWidth = camWidth / column;
        float cellHeight = camHeight / rows;

        SpriteRenderer sr = cardPrefab.GetComponentInChildren<SpriteRenderer>();
        Vector2 cardSize = sr.bounds.size;

        float scaleX = cellWidth / cardSize.x;
        float scaleY = cellHeight / cardSize.y;
        float finalScale = Mathf.Min(scaleX, scaleY); 

       
        for (int j = 0; j < rows; j++)
        {
             for (int i = 0; i < column; i++)
             {
                float posX = -camWidth / 2 + cellWidth * (i + 0.5f);
                float posY = camHeight / 2 - cellHeight * (j + 0.5f);

                GameObject card = Instantiate(cardPrefab, new Vector3(posX, posY, 0), Quaternion.identity);
                card.transform.localScale = new Vector3(finalScale, finalScale, 0f);
             }
        }
    }

    void FirstLayout()//2X2
    {



    }
    void SecondLayout()//2X3
    {



    }
    void ThirdLayout()//5X6
    {



    }



}
