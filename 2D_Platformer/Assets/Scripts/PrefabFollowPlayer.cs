using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabFollowPlayer : MonoBehaviour {
	private GameObject target;

	void Update() {
        target = GameObject.Find("Player");
		this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
	}
}