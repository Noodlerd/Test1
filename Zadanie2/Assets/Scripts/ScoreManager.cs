using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text bestScoreText;
    public int score;
    private int bestScore;

    public static ScoreManager Instance { get; set; }

    private void Start()
    {
        Instance = this;
        // Загружаем лучший рекорд из PlayerPrefs
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateBestScoreText();
    }

    public void AddScore(int points)
    {
        // Добавляем очки и проверяем, не стал ли текущий результат лучшим
        score += points;
        if (score > bestScore)
        {
            bestScore = score;
            UpdateBestScoreText();

            // Сохраняем лучший рекорд в PlayerPrefs
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
    }

    public void UpdateBestScoreText()
    {
        // Обновляем текст лучшего рекорда
        bestScoreText.text = "Best Score: " + bestScore/2;
        scoreText.text = "Current Score:" + score/2;
    }
}
