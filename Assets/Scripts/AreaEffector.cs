using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEffector : MonoBehaviour {

	float time;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		time = time + Time.deltaTime;
		if ((time > 2) && (time < 5)) {
			gameObject.SetActive(false);
		}
		else {
			gameObject.SetActive(true);        
		}
		if ((time > 9) && (time < 12)) {
			gameObject.SetActive(false);
		}
		else {
			gameObject.SetActive(true);
		}
		if (time == 13) {
			time = 0;
		}
	}
}