using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball_Controller : MonoBehaviour {

	// Scripts
	private Cannonball_Data cannonballData;

	// Components
	private Rigidbody2D rb2D;

	void OnEnable() {

		if(cannonballData == null)
			cannonballData = gameObject.GetComponent<Cannonball_Data>();

		if(rb2D == null)
			rb2D = gameObject.GetComponent<Rigidbody2D>();

		MoveCannonball();
		StartCoroutine("ExpireCannonball");
	}
	void MoveCannonball() {

		rb2D.AddForce(transform.right * cannonballData.cannonballSpeed, ForceMode2D.Impulse);
	}

	IEnumerator ExpireCannonball() {

		yield return new WaitForSeconds(2f);
		gameObject.SetActive(false);
	}
}
