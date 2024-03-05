using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {

	void Update () {
		transform.position += transform.forward * Time.deltaTime * 150f;
	}
}
