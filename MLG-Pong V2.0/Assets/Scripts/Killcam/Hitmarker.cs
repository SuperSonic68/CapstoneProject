using UnityEngine;
using System.Collections;

public class Hitmarker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("SelfDelete", .1f);
	}

	void SelfDelete () {
		Destroy (this.gameObject);
	}
}
