using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Hole_Spriter : MonoBehaviour {

	// Sprites
	public Sprite[] hitHoles;

	// Components
	private SpriteRenderer spriteRenderer;

	void OnEnable() {

		if (spriteRenderer == null)
			spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

		spriteRenderer.sprite = hitHoles[Mathf.RoundToInt(Random.Range(0, 2))];
	}
}
