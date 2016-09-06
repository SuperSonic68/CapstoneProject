using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CanvasImageCycle : MonoBehaviour {

    public GameObject UnityLogo;
    public GameObject SchoolLogos;
    public GameObject Developers;

    public Slider LoadingBar;
    public string sceneName;

    private float timeElapsed;
    private AsyncOperation async;
    private bool loading = false;

    IEnumerator LoadLevelWithBar(string sceneName)
    {
        async =  SceneManager.LoadSceneAsync(sceneName);

        while (!async.isDone)
        {
            LoadingBar.value = async.progress;
            yield return null;
        }
    }

    // Update is called once per frame
    void Update () {
        timeElapsed += Time.deltaTime;
        
	    if (timeElapsed % 6 < 2.0f)
        {
            Developers.SetActive(false);
            UnityLogo.SetActive(true);
        }
        else if (timeElapsed % 6 < 4.0f)
        {
            UnityLogo.SetActive(false);
            SchoolLogos.SetActive(true);
        }
        else if (timeElapsed % 6 < 6.0f)
        {
            SchoolLogos.SetActive(false);
            Developers.SetActive(true);
        }

        if (timeElapsed >= 8.0f && !loading)
        {
            StartCoroutine(LoadLevelWithBar(sceneName));
            loading = true;
        }
    }
}
