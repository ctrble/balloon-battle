using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Data : MonoBehaviour {

	// Settings
	public int players = 2;
	public int[] playerPoints = new int[2]; // inititalized in Game_Controller
	public bool gameOver = false;
}
