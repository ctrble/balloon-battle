using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Effect_Expirer : MonoBehaviour {

	void OnEnable() {

		StartCoroutine("ExpireEffect");
	}

	IEnumerator ExpireEffect() {

		yield return new WaitForSeconds(0.1f);
		gameObject.SetActive(false);
	}
}
