using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{   public TextMeshProUGUI highScoreText;
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;

    int highScore;

    int score = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void AddScore(int amount)
{
    score += amount;

    if(score > highScore)
    {
        highScore = score;

        PlayerPrefs.SetInt("HighScore", highScore);

        PlayerPrefs.Save();
    }

    scoreText.text = "Score: " + score;

    highScoreText.text =
        "High Score: " + highScore;
}
}