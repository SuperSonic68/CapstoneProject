using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

    public GameObject loadingImage;
    public int level;

    public void LoadScene(int level)
    {
        LoadScene(level);
        loadingImage.SetActive(true);
    }
}
