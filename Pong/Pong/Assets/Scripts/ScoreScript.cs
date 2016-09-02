using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour {

    public Text Player_Score;
    public Text NPC_Score;
	public Text WinText;
	public string MenuSceneName;

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
        Player_Score.text = "Player 1: " + playerScore.ToString();
        NPC_Score.text = "Player 2: " + npcScore.ToString();
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

				if (npcScore > 4) 
				{
					WinText.color = Color.blue;
					WinText.text = "Player 2 WINS!!";


					StartCoroutine(Wait ());

				}

            }
            else if (x < -20)
            {
                playerScore++;
                UpdateScore();
                GetComponent<GoalScript>().Goal();
                Scored = true;

				if (playerScore > 4) 
				{
					WinText.color = Color.red;
					WinText.text = "Player 1 WINS!!";


					StartCoroutine(Wait ());
				}

            }
        }
    }

	IEnumerator Wait()
	{
		Time.timeScale = 0.0f;
		yield return new WaitForSeconds (3);
		SceneManager.LoadScene (MenuSceneName);
	}

}
