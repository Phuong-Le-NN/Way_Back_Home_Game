using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformLv1 : MonoBehaviour {
	public Vector3 finishPos = Vector3.zero;
	public float speed = 0.5f;
	[SerializeField] private GameObject startingPosObj;
	[SerializeField] private GameObject endingPosObj;
	private Vector3 startPos;
	private Vector3 endPos;
	private float trackPercent = 0;
	private int direction = 1;

	void Start() {
		startPos = startingPosObj.transform.position;
		endPos = endingPosObj.transform.position;
	}

	// void OnDrawGizmos() {	
	// 	Gizmos.color = Color.red;
	// 	Gizmos.DrawLine(transform.position, finishPos);
	// }

	void Update() {
		trackPercent += direction * speed * Time.deltaTime;
		float x = (finishPos.x - startPos.x) * trackPercent + startPos.x;
		float y = (finishPos.y - startPos.y) * trackPercent + startPos.y;
		transform.position = new Vector3(x, startPos.y, startPos.z);

		if ((direction == -1 && (x > endPos.x || x < -endPos.x)) || (direction == 1 && (x < -endPos.x || x > endPos.x))) {
			direction *= -1;
		}
	}
} 