﻿using UnityEngine;
using System.Collections;
using System;

public class PlayerMovementScript : MonoBehaviour {

    public float WallLimit, PaddleSize;

	// Use this for initialization
	void Start () {
        WallLimit = 4f;
        PaddleSize = 0.25f;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movem = new Vector3(0f, vertical, horizontal);

        //Debug.Log(movem);

        Vector3 pos = transform.position;
        pos = newPos(pos, movem);
        transform.position = pos;
    }

    private Vector3 newPos(Vector3 pos, Vector3 movem)
    {
        float x, y, z;
        x = pos.x;
        y = Mathf.Max(Mathf.Min(pos.y + movem.y, WallLimit - PaddleSize), -WallLimit + PaddleSize);
        z = Mathf.Max(Mathf.Min(pos.z + movem.z, WallLimit - PaddleSize), -WallLimit + PaddleSize);

        return (new Vector3(x, y, z));
    }
}