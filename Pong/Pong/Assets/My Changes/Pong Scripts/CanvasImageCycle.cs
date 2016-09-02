using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasImageCycle : MonoBehaviour {

    public GameObject UnityLogo;
    public GameObject SchoolLogos;
    public GameObject Developers;

    public Slider LoadingBar;
    
    private float timeElapsed;
    private AsyncOperation async;
    private bool loading = false;

    IEnumerator LoadLevelWithBar(int level)
    {
        async = Application.LoadLevelAsync(level);

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
            StartCoroutine(LoadLevelWithBar(2));
            loading = true;
        }
    }
}
