using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Setup_Controller : MonoBehaviour {

	// Scripts
	private Player_Data playerData;

	// Components
	public Rigidbody2D balloonRB2D;
	public Rigidbody2D basketRB2D;
	public Transform cannonTransform;

	void OnEnable() {

		if(playerData == null)
			playerData = gameObject.GetComponent<Player_Data>();

		if(gameObject.name == "Player 1" || gameObject.name == "Player 1(Clone)")
			playerData.playerId = 0;
		else if(gameObject.name == "Player 2" || gameObject.name == "Player 2(Clone)")
			playerData.playerId = 1;

		if(balloonRB2D == null)
			balloonRB2D = gameObject.transform.GetChild(0).GetComponent<Rigidbody2D>();

		if(basketRB2D == null)
			basketRB2D = gameObject.transform.GetChild(1).GetComponent<Rigidbody2D>();

		if(cannonTransform == null)
			cannonTransform = gameObject.transform.GetChild(1).transform.GetChild(0).transform;

		SetupPlayer();
	}

	void SetupPlayer() {

		SetupJoints();

		if(playerData.playerId == 0) {

			cannonTransform.localPosition = new Vector2(0.25f, -0.7f);
			cannonTransform.localRotation = Quaternion.Euler(0, 0, 0);
		} else {

			cannonTransform.localPosition = new Vector2(-0.25f, -0.7f);
			cannonTransform.localRotation = Quaternion.Euler(0, 180, 0);
		}
	}

	void SetupJoints() {

		balloonRB2D.simulated = false;
		basketRB2D.simulated = false;

		SpringJoint2D springJoint1 = gameObject.transform.GetChild(1).gameObject.AddComponent<SpringJoint2D>() as SpringJoint2D;
		SpringJoint2D springJoint2 = gameObject.transform.GetChild(1).gameObject.AddComponent<SpringJoint2D>() as SpringJoint2D;
		SpringJoint2D springJoint3 = gameObject.transform.GetChild(1).gameObject.AddComponent<SpringJoint2D>() as SpringJoint2D;

		springJoint1.connectedBody = balloonRB2D;
		springJoint2.connectedBody = balloonRB2D;
		springJoint3.connectedBody = balloonRB2D;

		springJoint1.anchor = new Vector2(0.5f, 0);
		springJoint2.anchor = new Vector2(-0.5f, 0);
		springJoint3.anchor = new Vector2(0, 0);

		springJoint1.connectedAnchor = new Vector2(0.75f, -0.5f);
		springJoint2.connectedAnchor = new Vector2(-0.75f, -0.5f);
		springJoint3.connectedAnchor = new Vector2(0, 0);

		springJoint1.distance = 0.5f;
		springJoint2.distance = 0.5f;
		springJoint3.distance = 1;

		springJoint1.dampingRatio = 1;
		springJoint2.dampingRatio = 1;
		springJoint3.dampingRatio = 1;

		springJoint1.frequency = 5;
		springJoint2.frequency = 5;
		springJoint3.frequency = 5;

		balloonRB2D.simulated = true;
		basketRB2D.simulated = true;
	}
}
