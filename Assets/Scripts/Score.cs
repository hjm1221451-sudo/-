using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static Score instance;

    public int score = 0;
    public int goal = 200;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        CheckWin();
    }

    private void CheckWin()
    {
        if (score >= goal)
        {
            ResetScore();
            SceneManager.LoadScene("WinScene");
        }
    }

    public void ResetScore()
    {
        score = 0;
    }
}
