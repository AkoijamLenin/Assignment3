using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    
    private void Awake()
    {
        Instance = this;
    }

    private List<int> opened;
    private void Start()
    {
        opened = new List<int>();
    }
    
   public void AddToPair(int card_id)
    {
        opened.Add(card_id);
        if (opened.Count >=2)
        {
            checkCardMatch(opened[0],opened[1]);
            opened.Clear();
        }

            /*
            if (room.Contains(card))
            {
            i++;
            }
            room.Add(card);
            if (room[i - 1].GetComponent<Cards_Rotation>().isunderreview)
            {
                Debug.Log("half ");
            }
            else
            {
                if (room[i - 1] == room[i])
                {
                    Debug.Log("removed = " + room[i] + room[i-1]);

                }
                else
                {
                    room[i].GetComponent<Cards_Rotation>().makeunderreview();
                }
            }
            */


   }

        void checkCardMatch(int a, int b)
        {
       // Debug.Log("checking");

        if (a == b)
        {
            Debug.Log("removed = " + a + " and "+ b);
        }
        else
        {
            Debug.Log("not matched = " + a + " and "+ b);

        }

        }


}
