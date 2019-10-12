using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edges_Controller : MonoBehaviour {

	// Scripts
	private Edges_Data edgesData;
	private Game_Controller gameController;

	// Objects
	public GameObject dedIconP1;
	public GameObject dedIconP2;

	void OnEnable() {

		if(edgesData == null)
			edgesData = gameObject.GetComponent<Edges_Data>();

		if(gameController == null)
			gameController = GameObject.Find("Game Controller").GetComponent<Game_Controller>();

		if(dedIconP1 == null)
			dedIconP1 = gameObject.transform.GetChild(0).gameObject;

		if(dedIconP2 == null)
			dedIconP2 = gameObject.transform.GetChild(1).gameObject;
	}

	void OnTriggerExit2D(Collider2D other) {

		if(other.name == "Basket") {

			Vector3 hitPosition = other.transform.position;

			if(other.gameObject.transform.root.gameObject.name == "Player 1" || other.gameObject.transform.root.gameObject.name == "Player 1(Clone)") {

				Vector3 p1Position = new Vector3(-7, 1, 0);
				Vector3 dedPosition = (p1Position + hitPosition) * 0.5f;

				dedIconP1.transform.position = dedPosition;
				dedIconP1.SetActive(true);
			}

			if(other.gameObject.transform.root.gameObject.name == "Player 2" || other.gameObject.transform.root.gameObject.name == "Player 2(Clone)") {

				Vector3 p2Position = new Vector3(7, 1, 0);
				Vector3 dedPosition = (p2Position + hitPosition) * 0.5f;

				dedIconP2.transform.position = dedPosition;
				dedIconP2.SetActive(true);
			}

			Destroy(other.gameObject.transform.root.gameObject);
			gameController.GotPoint(other.gameObject.transform.root.gameObject);
		}
	}
}
