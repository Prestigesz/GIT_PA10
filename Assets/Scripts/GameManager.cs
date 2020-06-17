using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState { GamePaused, GameStarted, GameOver };
    private GameState CurrentState = GameState.GamePaused;

    public static GameManager thisManager = null;  
    [SerializeField] private Text Txt_Score = null;
    [SerializeField] private Text Txt_Message = null;
    private int Score = 0;

    void Start()
    {
        thisManager = this;
        Time.timeScale = 0;
    }

    void Update()
    {
        if (CurrentState == GameState.GamePaused && Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1;
            CurrentState = GameState.GameStarted;
            Txt_Message.text = "";
        }


        if (CurrentState == GameState.GameOver && Input.GetKeyDown(KeyCode.Return))
            SceneManager.LoadScene(0);
        /*if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.Return))
            StartGame();*/
    }

    public void UpdateScore()
    {
        Score ++;
        Txt_Score.text = "SCORE : " + Score;
    }

    private void StartGame()
    {
        Score = 0;
        Time.timeScale = 1;
        Txt_Message.text = "";
        Txt_Score.text = "SCORE : 0";
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        
        SceneManager.LoadScene(1);
        Txt_Message.text = "GAMEOVER! \nPRESS ENTER TO RESTART GAME.";
        Txt_Message.color = Color.red;
        CurrentState = GameState.GameOver;
    }
}
