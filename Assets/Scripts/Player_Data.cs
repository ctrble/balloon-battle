using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Data : MonoBehaviour {

	// Settings
	public int playerId; // initialized in Player_Setup_Controller
	public int hits;
	public int moveAmount = 150;
	public float gravityScale = -5f;
	public float cannonAngle = 0;
	public float cannonRotateSpeed = 2;
	public float knockbackAmount = 500;
	public AudioClip[] cannonShootSound;
}
