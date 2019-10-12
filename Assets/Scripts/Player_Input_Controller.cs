using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Player_Input_Controller : MonoBehaviour {

  // Scripts
  private Player_Data playerData;

  // Objects
  // private Player player; // The Rewired Player
  private string playerNumber;

  void OnEnable() {

    if (playerData == null)
      playerData = gameObject.GetComponent<Player_Data>();

    // player = ReInput.players.GetPlayer(playerData.playerId);

    if (gameObject.name == "Player 1(Clone)") {
      playerNumber = "P1";
    }
    else {
      playerNumber = "P2";
    }
  }

  public bool MoveUp() {

    if (Input.GetButton(playerNumber + " - Up"))
      return true;
    else
      return false;
  }

  public bool MoveDown() {

    if (Input.GetButton(playerNumber + " - Down"))
      return true;
    else
      return false;
  }

  public bool Shoot() {

    if (Input.GetButtonDown(playerNumber + " - Fire Cannon"))
      return true;
    else
      return false;
  }

  public bool AimUpRight() {

    if (Input.GetButton(playerNumber + " - Cannon Right Side Rotate Up"))
      return true;
    else
      return false;
  }

  public bool AimDownRight() {

    if (Input.GetButton(playerNumber + " - Cannon Right Side Rotate Down"))
      return true;
    else
      return false;
  }

  public bool AimUpLeft() {

    if (Input.GetButton(playerNumber + " - Cannon Left Side Rotate Up"))
      return true;
    else
      return false;
  }

  public bool AimDownLeft() {

    if (Input.GetButton(playerNumber + " - Cannon Left Side Rotate Down"))
      return true;
    else
      return false;
  }
}
