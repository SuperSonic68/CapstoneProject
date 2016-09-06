using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ClickToLoad : MonoBehaviour {

    public Slider loadingBar;
    public GameObject loadingImage;

    private AsyncOperation async;

    public void ClickAsync(string sceneName)
    {
        loadingImage.SetActive(true);
        StartCoroutine(LoadLevelWithBar(sceneName));
    }

    IEnumerator LoadLevelWithBar(string sceneName)
    {
        async = SceneManager.LoadSceneAsync(sceneName);
        while (!async.isDone)
        {
            loadingBar.value = async.progress;
            yield return null;
        }
    }
}
