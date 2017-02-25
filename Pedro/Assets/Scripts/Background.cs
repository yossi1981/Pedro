using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

	public float TileSizeW;
	public float ScrollSpeed;

	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float newPosition = Mathf.Repeat (Time.time * ScrollSpeed, TileSizeW);
		transform.position = startPosition + Vector3.left * newPosition;
	}
}
