using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum Difficulty
{
    Easy, mid, hard
}
public enum GameState
{
    Start, Playing, End
}

public class GameManager : Singleton<GameManager>
{
    public static int score;
    public float Timer;
    public Difficulty difficulty;
    public GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        _UI.UpdateDifficulty(difficulty);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == GameState.Playing)
        {
            Timer -= (1 * Time.deltaTime);

            Timer = Mathf.Clamp(Timer, 0, 9999);

            _UI.UpdateTimer(Timer);

            //Timee.text = Timer.ToString("F0");

            // Timee.color = Timer < 10 ? Color.red : Color.white;
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                difficulty = Difficulty.Easy;
                _UI.UpdateDifficulty(difficulty);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                difficulty = Difficulty.mid;
                _UI.UpdateDifficulty(difficulty);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                difficulty = Difficulty.hard;
                _UI.UpdateDifficulty(difficulty);
            }
        }   
    }

    public void UpdateScore(int _score)
    {
        score += _score;
        _UI.ScoreCount(score);
    }

    public void ChangeGameState(GameState _state)
    {
        gameState = _state;
        _UI.UpdateDifficulty(difficulty);
    }

    public void ChangeDifficulty(int _Difficulty)
    {
        difficulty = (Difficulty)_Difficulty;
        //_EM.UpdateEnemyDifficulty((int)difficulty);
    }

    /*public void UpdateDifficultyOnLoad()
    {
        _UI.UpdateDifficulty(difficulty);
    }*/
}
