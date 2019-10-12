using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke_Effect_Expirer : MonoBehaviour {

	void OnEnable() {

		StartCoroutine("ExpireEffect");
	}

	IEnumerator ExpireEffect() {

		yield return new WaitForSeconds(0.333f);
		gameObject.SetActive(false);
	}
}
