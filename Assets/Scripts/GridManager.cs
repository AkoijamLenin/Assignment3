using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    //2X2 2X3 5X6
    [SerializeField] GameObject cardPrefab;
    [SerializeField] List<GameObject>cardPrefabs;
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
        GenerateGrid();
        
    }

    void GenerateGrid()
    {
        float camHeight = Camera.main.orthographicSize * 2f;
        camHeight = camHeight - top_Offset;//
        float camWidth =camHeight * Camera.main.aspect;

         float cellWidth =camWidth / column;
        float cellHeight =camHeight /rows;

        SpriteRenderer sr =cardPrefab.GetComponentInChildren<SpriteRenderer>();
        Vector2 cardSize = sr.bounds.size;

        float scaleX = cellWidth /cardSize.x;
        float scaleY = cellHeight  / cardSize.y ;//new
        float finalScale=  Mathf.Min(scaleX, scaleY); 

       //


        for (int j=0;j<rows;j++)
        {
             for (int i=0;i<column;i++)
             {
                float _posX =-camWidth /2 + cellWidth * (i + 0.5f);
                float _posY =camHeight /2 - cellHeight * (j + 0.5f);

                GameObject card =Instantiate(cardPrefab, new Vector3(_posX, _posY, 0), Quaternion.identity);
                card.transform.localScale = new Vector3(finalScale, finalScale+0.5f, 0f);
             }
        }
    }


   



}
