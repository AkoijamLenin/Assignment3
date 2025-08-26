using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    //2X2 2X3 5X6
 
    [SerializeField] GameObject card_prefab;
    [SerializeField] int starting_xPos;
    [SerializeField] int starting_yPos;
    [SerializeField] int row;
    [SerializeField] int column;
    [SerializeField] int xOffset;
    [SerializeField] int yOffset;
    float size;

    [SerializeField] float offset;
    private void Start()
    {
        size = Camera.main.orthographicSize / 2f;
        int xPos = starting_xPos;
        int yPos = starting_yPos;

        for (int j = 1; j <= column; j++)
        {

         for(int i =1;i<=row;i++)
         {
            SpawnCards(xPos,yPos);
            xPos += xOffset;


         }
            yPos -= yOffset;
            xPos = starting_xPos;
        }
    }







    void SpawnCards(int x, int y)
    {
        GameObject temp=Instantiate(card_prefab,new Vector3(x,y,0),Quaternion.identity);
        temp.transform.localScale = new Vector3(size / offset, size / offset,0f);
        Debug.Log("scale= " + size / offset);

        

    }
   

}
