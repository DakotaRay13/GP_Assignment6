using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int LIVES = 3;
    public static int SCORE = 0;

    public Text livesText;
    public Text scoreText;

    public List<Prize> prizeList = new List<Prize>();

    private void Start()
    {
        livesText.text = "   LIVES: " + LIVES;
        scoreText.text = "   SCORE: " + SCORE;

        prizeList.AddRange(FindObjectsOfType<Prize>());
    }

    public static void ResetStats()
    {
        LIVES = 3;
        SCORE = 0;
    }

    public void SetLives(int count)
    {
        LIVES = count;
    }

    public void AddScore(int value)
    {
        SCORE += value;
        scoreText.text = "   SCORE: " + SCORE;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ClaimPrize(Prize prize)
    {
        AddScore(prize.Value);
        prizeList.Remove(prize);

        if(prizeList.Count == 0)
        {
            ReloadScene();
        }
    }

    public void GameOver()
    {
        LIVES -= 1;

        if(LIVES <= 0)
        {
            SceneManager.LoadScene("EndScreen");
        }
        else
        {
            ReloadScene();
        }
    }
}
