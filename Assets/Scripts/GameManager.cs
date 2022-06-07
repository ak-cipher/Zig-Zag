using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    public int score;
    public Text scoretext;
    public Text highScore;


    private void Awake()
    {
        highScore.text = "High Score : " + HighScore().ToString();
    }
    public void GameStarted()
    {
        gameStarted = true;
        FindObjectOfType<Road>().StartBuilding();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            GameStarted();
        }

    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    public void IncreaseScore()
    {
        score++;
        scoretext.text = score.ToString();

        if(score > HighScore())
        {
            PlayerPrefs.SetInt("highscore", score);
            highScore.text = "High Score : " + score.ToString();
        }
    }

    private int HighScore()
    {
        int high = PlayerPrefs.GetInt("highscore", 0);
        return high;
    }
}
