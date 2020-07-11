using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameStartUI;

    private void Awake()
    {
        instance = this;
        if (PlayerPrefs.GetInt("score") != null)
        {
            highScoreText.text = PlayerPrefs.GetInt("score").ToString();
        }
        else
        {
            highScoreText.text = 0.ToString();
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        //this can be adjusted to be dynamic
        if(score > PlayerPrefs.GetInt("score"))
        {
            PlayerPrefs.SetInt("score", score);
            highScoreText.text = score.ToString();
        }
        SceneManager.LoadScene("Game");
    }

    public void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();//
    }

    public void GameStart()
    {
        gameStartUI.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }
}
