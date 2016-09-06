using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

    public GameObject loadingImage;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
        loadingImage.SetActive(true);
    }
}
