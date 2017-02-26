using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour {
	
	void Start () {}

	void Update () {
		transform.position = transform.position + Vector3.left * Time.deltaTime * 5.0f;
	}
}