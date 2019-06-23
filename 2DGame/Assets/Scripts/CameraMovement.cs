using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public Transform target;
	public float smoothing;
	public Vector2 maxPosition;
	public Vector2 minPosition;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	// Use LateUpdate because want camera to move last
	// Sometimes if in update and move, the camera will move first
	// before the player does causing it to look bad
	void LateUpdate () {
		if (transform.position != target.position) {
			Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

			//Adding boundaries to camera
			targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
			targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

			transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
		}
	}
}
