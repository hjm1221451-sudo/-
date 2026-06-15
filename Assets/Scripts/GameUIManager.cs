using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public Text hpText;
    public Text scoreText;
    public Text goalText;

    public Hp hpComponent;

    void Update()
    {
        if (hpComponent != null)
        {
            hpText.text = "HP: " + hpComponent.hp;
        }

        if (Score.instance != null)
        {
            scoreText.text = "Score: " + Score.instance.score;
            goalText.text = "Goal: " + Score.instance.goal;
        }
    }
}
