﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour {

	public Vector2 cameraChange;
	public Vector3 playerChange;
	private CameraMovement cam;
	public bool needText;
	public string placeName;
	public GameObject text;
	public Text placeText;

	// Use this for initialization
	void Start () {
		cam = Camera.main.GetComponent<CameraMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.CompareTag("Player")) {
			cam.minPosition += cameraChange;
			cam.maxPosition += cameraChange;
			collision.transform.position += playerChange;
			if (needText) {
				StartCoroutine(placeNameCo());
			}
		}
	}

	private IEnumerator placeNameCo() {
		text.SetActive(true);
		placeText.text = placeName;
		yield return new WaitForSeconds(2f);
		text.SetActive(false);
	}
}
