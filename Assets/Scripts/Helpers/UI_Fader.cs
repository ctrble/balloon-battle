using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Fader : MonoBehaviour {

	// Components
	private SpriteRenderer spriteRenderer;

	void OnEnable () {

		if (spriteRenderer == null)
			spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

	}

	void Update () {

		spriteRenderer.color -= new Color(0, 0, 0, Time.deltaTime * 0.05f);
	}
}
