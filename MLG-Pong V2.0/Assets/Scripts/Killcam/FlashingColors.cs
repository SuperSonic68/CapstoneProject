using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlashingColors : MonoBehaviour {
	
	public float delay;
	public float shakeIntensity;
	RectTransform textPos;
	Text text;
	Image image;
	Vector3 shakeMovement;

	// Use this for initialization
	void Start () {
		textPos = this.GetComponent<RectTransform> ();
		text = this.GetComponent<Text> ();
		image = this.GetComponent<Image> ();
		shakeMovement = new Vector3 (Mathf.Infinity, 0, 0);
	}

	float elapsedTime = 0f;
	void Update () {
		if (elapsedTime >= delay) {
			Flash ();
			elapsedTime = 0f;
		}

		elapsedTime += Time.deltaTime;
	}
	
	void Flash () {
		float r = Random.Range (0f, 1f);
		float g = Random.Range (0f, 1f);
		float b = Random.Range (0f, 1f);
		if (text != null) {
			text.color = new Color (r, g, b);
		} else {
			image.color = new Color (r, g, b, .15f);
		}


		if (shakeMovement.x == Mathf.Infinity) {
			float x = Random.Range (-shakeIntensity, shakeIntensity);
			float y = Random.Range (-shakeIntensity, shakeIntensity);
			shakeMovement = new Vector3 (x, y, 0f);
			textPos.localPosition += shakeMovement;
		} else {
			textPos.localPosition -= shakeMovement;
			shakeMovement.x = Mathf.Infinity;
		}
	}
}
