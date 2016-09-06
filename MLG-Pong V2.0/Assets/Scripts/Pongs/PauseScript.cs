using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

	public bool paused;
	public Text PauseText;
	public string MenuSceneName;

	// Use this for initialization
	void Start () {
		paused = false;
		PauseText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			paused = !paused;
			PauseText.enabled = !PauseText.enabled;
		}
			
		if (paused) 
		{
			Time.timeScale = 0.0f;
			if (Input.GetKeyDown (KeyCode.M)) 
			{
				SceneManager.LoadScene (MenuSceneName);
				Time.timeScale = 1.0f;
			}

		}
		else if (!paused)
		{
			Time.timeScale = 1.0f;
		}

	}
}
