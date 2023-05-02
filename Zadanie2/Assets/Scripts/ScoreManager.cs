using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    private int bestScore;

    public static ScoreManager Instance { get; set; }

    private void Start()
    {
        Instance = this;
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        PlayerPrefs.SetInt("Score", 0);
    }

   

    public void AddScore(int points)
    {
        // Добавляем очки и проверяем, не стал ли текущий результат лучшим
        score += points;
        PlayerPrefs.SetInt("Score", score);
        if (score > bestScore)
        {
            bestScore = score;

            // Сохраняем лучший рекорд в PlayerPrefs
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
    }

}
