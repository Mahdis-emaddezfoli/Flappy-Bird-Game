
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameOver = false;

    public GameObject gameOverText;
    public GameObject player;

    void Start()
    {
        Time.timeScale = 1f;
        gameOver = false;

        if (gameOverText != null)
            gameOverText.SetActive(false);

        if (player != null)
            player.SetActive(true);
    }

    public void GameOver()
    {
        if (gameOver)
            return;

        gameOver = true;

        if (gameOverText != null)
            gameOverText.SetActive(true);

        Time.timeScale = 0f;
        Debug.Log("GAME OVER!");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        gameOver = false;

        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }
}
