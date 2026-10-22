
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
