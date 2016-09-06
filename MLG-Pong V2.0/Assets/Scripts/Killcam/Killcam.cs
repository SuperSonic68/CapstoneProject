using UnityEngine;
using System.Collections;

public class Killcam : MonoBehaviour {

	public GameObject ball;
	public Canvas canvas;
	public float camDistance, zoomSpeed, spinSpeed;
	Vector3 originalPosition;
	public Vector3 OriginalPosition {
		get {return originalPosition;}
	}
	Quaternion originalRotation;
	public Quaternion OriginalRotation {
		get {return originalRotation;}
	}
	bool activated;

	AudioSource wombo;
	AudioSource bangarang;

	void Start () {
		originalPosition = this.transform.position;
		originalRotation = this.transform.rotation;
		activated = false;
		wombo = Camera.main.transform.FindChild ("Dank Sounds").FindChild ("WomboCombo").GetComponent<AudioSource> ();
		bangarang = Camera.main.transform.FindChild ("Dank Sounds").FindChild ("Bangarang").GetComponent<AudioSource> ();
	}

	public void Activate (GameObject target) {
		if (!activated) {
			StartCoroutine (Move (target.transform.position));
			activated = true;
		}
	}

	public void Deactivate () {
		if (activated) {
			StopAllCoroutines ();
			canvas.gameObject.SetActive (false);
			this.transform.position = originalPosition;
			this.transform.rotation = originalRotation;
			wombo.Stop ();
			bangarang.Stop ();
			activated = false;
		}
	}

	IEnumerator Move (Vector3 t) {
		// Play wombo combo, mlg airhorns
		wombo.PlayOneShot (wombo.clip);
		int i = 1;
		while (Vector3.Distance (this.transform.position, t) >= camDistance) {
			this.transform.Translate ((t - this.transform.position).normalized * zoomSpeed, Space.World);
			this.transform.LookAt (t);
			float z = spinSpeed * i;
			this.transform.Rotate (this.transform.right, z, Space.Self);
			++i;

			yield return null;
		}

		bangarang.PlayOneShot (bangarang.clip);

		// Display dank gifs
		canvas.gameObject.SetActive (true);
	}
}
