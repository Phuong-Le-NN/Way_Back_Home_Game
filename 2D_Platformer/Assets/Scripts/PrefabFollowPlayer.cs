using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabFollowPlayer : MonoBehaviour {
    private GameObject target;
    private Vector3 originalScale;

    void Start() {
        target = GameObject.Find("Player"); // Find once (not every frame!)
        if (target != null) {
            originalScale = transform.localScale;
        }
    }

    void Update() {
        if (target == null) return;

        // Follow player
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);

        // Check key input to flip
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z); // Face right
        } 
        else if (Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.A)) {
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z); // Face left
        }
    }
}