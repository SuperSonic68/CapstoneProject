using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ScoreScript : MonoBehaviour {

    public Text Player_Score;
    public Text NPC_Score;

    private int playerScore, npcScore;

    public bool Scored;

	// Use this for initialization
	void Start () {
        playerScore = 0;
        npcScore = 0;
        UpdateScore();
        Scored = false;
	}

    private void UpdateScore()
    {
        Player_Score.text = "Score: " + playerScore.ToString();
        NPC_Score.text = "Score: " + npcScore.ToString();
    }

    void FixedUpdate()
    {
        if (!Scored)
        {
            float x = transform.position.x;
            if (x > 20)
            {
                npcScore++;
                UpdateScore();
                GetComponent<GoalScript>().Goal();
                Scored = true;
            }
            else if (x < -20)
            {
                playerScore++;
                UpdateScore();
                GetComponent<GoalScript>().Goal();
                Scored = true;
            }
        }
    }
}
