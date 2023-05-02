using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Text previousScore;
    [SerializeField] private Text bestScore;

    private void Start()
    {
        previousScore.text ="Score : "+ PlayerPrefs.GetInt("Score").ToString();
        bestScore.text = "Best Score : "+ PlayerPrefs.GetInt("BestScore").ToString();
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1f;
    }
}
