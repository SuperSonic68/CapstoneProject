using UnityEngine;
using System.Collections;

public class HitmarkerGenerator : MonoBehaviour {

	public GameObject hitmarker;

	public float soundDelay;

	AudioSource source;

	// Use this for initialization
	void Start () {
		source = Camera.main.transform.FindChild ("Dank Sounds").FindChild ("Fwip").GetComponent<AudioSource> ();
		HitSound ();
	}

	float elapsedTime = 0f;
	void Update () {
		DrawHitmarker ();
		if (elapsedTime >= soundDelay) {
			HitSound ();
			elapsedTime = 0f;
		}

		elapsedTime += Time.deltaTime;
	}

	void DrawHitmarker () {
		GameObject marker = Instantiate (hitmarker) as GameObject;
		marker.transform.SetParent (this.transform);
		float x = Random.Range (-Screen.width / 2, Screen.width / 2);
		float y = Random.Range (-Screen.height / 2, Screen.height / 2);
		float z = -.1f;
		RectTransform markerRect = marker.GetComponent<RectTransform> ();
		markerRect.localPosition = new Vector3 (x, y, z);
		markerRect.localScale = new Vector3 (.3f, .3f, 1f);
	}

	void HitSound () {
		source.PlayOneShot (source.clip);
	}
}
