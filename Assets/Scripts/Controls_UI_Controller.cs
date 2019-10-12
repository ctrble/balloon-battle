using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls_UI_Controller : MonoBehaviour {

	// Variables
	private bool gotPlayers;

	// Scripts
	private Game_Controller gameController;

	// Objects
	public GameObject player1;
	public GameObject player2;

	void OnEnable() {

		StartCoroutine("ExpireEffect");
	}

	void Update() {

		if(gotPlayers) {

			if(player1 != null)
				gameObject.transform.GetChild(0).localPosition = new Vector3(player1.transform.GetChild(0).localPosition.x - 7, player1.transform.GetChild(0).localPosition.y + 1, 0);
			else
				gameObject.transform.GetChild(0).gameObject.SetActive(false);

			if(player2 != null)
				gameObject.transform.GetChild(1).localPosition = new Vector3(player2.transform.GetChild(0).localPosition.x + 7, player2.transform.GetChild(0).localPosition.y + 1, 0);
			else
				gameObject.transform.GetChild(1).gameObject.SetActive(false);
		}
	}

	IEnumerator ExpireEffect() {

		yield return new WaitForSeconds(0.2f);

		if(player1 == null)
			player1 = GameObject.Find("Player 1(Clone)");

		if(player2 == null)
			player2 = GameObject.Find("Player 2(Clone)");

		if(player1 !=  null && player2 != null)
			gotPlayers = true;

		yield return new WaitForSeconds(20f);
		gameObject.SetActive(false);
	}
}
