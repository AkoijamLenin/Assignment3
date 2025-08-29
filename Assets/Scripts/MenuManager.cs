using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{   
    [SerializeField] GameObject Level_Select;
    [SerializeField] Button Easy;
    [SerializeField] Button Medium;
    [SerializeField] Button Hard;

    [SerializeField] GameObject GameOver;
    [SerializeField] Button Main_Menu_button;

    [SerializeField] GameObject Main_Menu;
    [SerializeField] Button Play_button;
    [SerializeField] Button Load_button;
    [SerializeField] Button Quit_button;

    private void Awake()
    {
        //ShowMenu();
        ShowLevel_Selection();//will be deleated
        Easy.onClick.AddListener(() =>
        {
            CloseLevel_Selection();
            GameManager.Instance.Easyone();
        });

        Medium.onClick.AddListener(() =>
        {
            CloseLevel_Selection();
            GameManager.Instance.Mediumone();
        });

        Hard.onClick.AddListener(() =>
        {
            CloseLevel_Selection();
            GameManager.Instance.Hardone();
        });
        

    }


        private void CloseMenu()
        {
        Main_Menu.SetActive(false);
        }
        private void ShowMenu()
        {
        Main_Menu.SetActive(true);
        }
        private void CloseLevel_Selection()
        {
        Level_Select.SetActive(false);
        }
        private void ShowLevel_Selection()
        {
        Level_Select.SetActive(true);
        }
    
    
    //TO be deleted 
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowLevel_Selection();
            Debug.Log(" Cleared cards from MenuManager");
        }
    }
    private void OnApplicationQuit()
    {
        Debug.Log("SAved");
    }
}
