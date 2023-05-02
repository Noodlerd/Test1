using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControler : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject MainUI;
    [SerializeField] private GameObject LoseMenu;
    [SerializeField] private Text scorePauseMenu;

    public static UIControler Instance { get; set; }

    private void Start()
    {
        Instance = this;
    }


    public void ShowPauseMenu(){
        scorePauseMenu.text = "Score : " + PlayerPrefs.GetInt("Score").ToString();
        LoseMenu.SetActive(false);
        PauseMenu.SetActive(true);
        MainUI.SetActive(false);
        Time.timeScale = 0f;
    }

    public void HidePauseMenu(){
        PauseMenu.SetActive(false);
    }

    public void ShowMainUI(){
        PauseMenu.SetActive(false);
        MainUI.SetActive(true);
    }

    public void HideMainUI(){
        MainUI.SetActive(false);
    }

    public void Restart(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Continue(){
        ShowMainUI();
        Time.timeScale = 1f;

    }

    public void ShowLoseMenu()
    {
        MainUI.SetActive(false);
        LoseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Exit(){
        Time.timeScale = 0f;
        SceneManager.LoadScene("Menu");
    }

}
