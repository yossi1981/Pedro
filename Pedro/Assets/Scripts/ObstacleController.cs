﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController
	: MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + Vector3.left * Time.deltaTime * 5.0f;
	}
}
