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
    [SerializeField] Button DeleteSave_button;
    [SerializeField] Button Quit_button;

    [SerializeField] GameObject No_SaveData_Screen;
    [SerializeField] Button cross_button;

    [SerializeField] Button Save_button;

    [SerializeField] SoundManager soundManager;

    private void Awake()
    {
        ShowMenu();
        CloseGameOver();
        CloseLevel_Selection();
        Close_No_Save_Screen();
 
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

        Play_button.onClick.AddListener(() =>
        {
            CloseMenu();
            ShowLevel_Selection();
        });
        Load_button.onClick.AddListener(() =>
        {
            if (SaveSystem.LoadGame() == null)
            {
                Show_No_Save_Screen();
                return;
            } 
            CloseMenu();
            GameManager.Instance.LoadGame();
        });
        DeleteSave_button.onClick.AddListener(() =>
        {
           SaveSystem.DeleteSave();
        });
        Quit_button.onClick.AddListener(() =>
        {
            Application.Quit();
        });

        Main_Menu_button.onClick.AddListener(() =>
        {
            soundManager.stopSound();
            CloseGameOver();
            ShowMenu();
        });

        cross_button.onClick.AddListener(() =>
        {
            Close_No_Save_Screen();
        });

        Save_button.onClick.AddListener(() =>
        {
            GameManager.Instance.SaveGame();
        });
    }
    private void Start()
    {
        GameManager.Instance.onGameOver += GameManager_onGameOver;
    }
    private void GameManager_onGameOver(object sender, System.EventArgs e)
    {
        ShowGameOver();
    }
    private void ShowMenu()
    {
        Main_Menu.SetActive(true);
    }
    private void CloseMenu()
        {
        Main_Menu.SetActive(false);
        }
    private void CloseLevel_Selection()
    {
        Level_Select.SetActive(false);
    }
    private void ShowLevel_Selection()
    {
        Level_Select.SetActive(true);
    }
    private void ShowGameOver()
    {
        GameOver.SetActive(true);
    }
    private void CloseGameOver()
    {
        GameOver.SetActive(false);
    }
    private void Show_No_Save_Screen()
    {
        No_SaveData_Screen.SetActive(true);
    }
    private void Close_No_Save_Screen()
    {
        No_SaveData_Screen.SetActive(false);
    }
}
