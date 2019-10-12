using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Status_Controller : MonoBehaviour {

	// Scripts
	private Player_Data playerData;
	private Game_Data gameData;

	// Components
	private Rigidbody2D balloonRB2D;
	private Animator pointsAnimator;

	// Variables
	private int previousHits;

	void OnEnable() {

		if(playerData == null)
			playerData = gameObject.GetComponent<Player_Data>();

		if(gameData == null)
			gameData = GameObject.Find("Game Controller").GetComponent<Game_Data>();

		if(balloonRB2D == null)
			balloonRB2D = gameObject.transform.GetChild(0).GetComponent<Rigidbody2D>();

		if(pointsAnimator == null)
			pointsAnimator = gameObject.transform.GetChild(0).gameObject.GetComponentInChildren<Animator>();

		previousHits = playerData.hits;

		UpdatePointsAnimation();

		//subscription to the hit
		Ballon_Hit_Detective.BalloonWasHit += MonitorHealth;
	}

	void Update() {

		UpdatePointsAnimation();
	}

	void UpdatePointsAnimation() {

		if (gameObject.name == "Player 1" || gameObject.name == "Player 1(Clone)") {

			pointsAnimator.SetInteger("points", gameData.playerPoints[0]);
		}

		if (gameObject.name == "Player 2" || gameObject.name == "Player 2(Clone)") {

			pointsAnimator.SetInteger("points", gameData.playerPoints[1]);
		}
	}

	void MonitorHealth() {

		if(playerData.hits != previousHits) {

			playerData.gravityScale += playerData.hits * 0.2f;
			balloonRB2D.gravityScale = playerData.gravityScale;
			previousHits = playerData.hits;
		}
		else {
			previousHits = playerData.hits;
		}
	}

	void OnDisable() {

		//unsubscribe to the hits, no memory leaks
		Ballon_Hit_Detective.BalloonWasHit -= MonitorHealth;
	}
}
