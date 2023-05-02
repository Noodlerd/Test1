using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControler : MonoBehaviour
{
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject MainUI;
    [SerializeField] private GameObject LoseText;

    public static UIControler Instance { get; set; }

    private void Start()
    {
        Instance = this;
    }

    public void ShowMenu(){
        Time.timeScale = 0f;
        Menu.SetActive(true);
        PauseMenu.SetActive(false);
        MainUI.SetActive(false);
    }

    public void HideMenu(){
        Menu.SetActive(false);
    }

    public void ShowPauseMenu(){
        Time.timeScale = 0f;
        LoseText.SetActive(false);
        Menu.SetActive(false);
        PauseMenu.SetActive(true);
        MainUI.SetActive(false);
    }

    public void HidePauseMenu(){
        PauseMenu.SetActive(false);
    }

    public void ShowMainUI(){
        Menu.SetActive(false);
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

    public void Exit(){
        Time.timeScale = 0f;
        ShowMenu();
        ScoreManager.Instance.UpdateBestScoreText();
    }

}
