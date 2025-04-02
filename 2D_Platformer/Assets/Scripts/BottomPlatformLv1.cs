using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomPlatformLv1 : MonoBehaviour {
    public float moveDistance = 5f;  // Total distance the platform moves back and forth
    public float speed = 1f;         // Speed of the movement

    private Vector3 startPos;

    void Start() {
        startPos = transform.position;
    }

    void Update() {
        // Use Mathf.PingPong to create a smooth back-and-forth movement
        float x = Mathf.PingPong(Time.time * speed, moveDistance);
        transform.position = new Vector3(startPos.x + x, transform.position.y, transform.position.z);
    }
}
