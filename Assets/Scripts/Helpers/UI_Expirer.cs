using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Expirer : MonoBehaviour {

	void OnEnable() {

		StartCoroutine("ExpireEffect");
	}

	IEnumerator ExpireEffect() {

		yield return new WaitForSeconds(1.5f);
		gameObject.SetActive(false);
	}
}
