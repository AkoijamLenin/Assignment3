using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject menu_Screen;
    [SerializeField] Button Easy;
    [SerializeField] Button Medium;
    [SerializeField] Button Hard;

    private void Awake()
    {
        ShowMenu();
        Easy.onClick.AddListener(() =>
        {
            CloseMenu();
            GameManager.Instance.Easyone();
        });

        Medium.onClick.AddListener(() =>
        {
            CloseMenu();
            GameManager.Instance.Mediumone();
        });

        Hard.onClick.AddListener(() =>
        {
            CloseMenu();
            GameManager.Instance.Hardone();
        });
        
    }


        private void CloseMenu()
        {
        menu_Screen.SetActive(false);
        }
    
        private void ShowMenu()
        {
        menu_Screen.SetActive(true);
        }


}
