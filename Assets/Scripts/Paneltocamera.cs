﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paneltocamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}


	public GameObject objectA;
	public GameObject camera;
	// Update is called once per frame
	void Update () {
		objectA.transform.LookAt (camera.transform);
	}
}
