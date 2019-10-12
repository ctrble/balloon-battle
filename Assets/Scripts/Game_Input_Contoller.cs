using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Game_Input_Contoller : MonoBehaviour {

  // Objects
  // private Player player; // The Rewired Player

  public GameObject p1WinUI;
  public GameObject p2WinUI;

  public bool canReset;

  void OnEnable() {

    // player = ReInput.players.GetPlayer("SYSTEM");
    canReset = false;
  }

  void Update() {
    if (p1WinUI.activeInHierarchy || p2WinUI.activeInHierarchy) {
      // canReset = true;
      StartCoroutine(Timer());
    }
    // else {
    //   canReset = false;
    // }
  }

  IEnumerator Timer() {
    yield return new WaitForSeconds(1f);
    canReset = true;
    yield return null;
  }

  public bool Restart() {

    if (canReset && Input.anyKeyDown)
      return true;
    else
      return false;
  }

  // public bool Quit() {

  //   if (Input.GetButtonDown("Quit"))
  //     return true;
  //   else
  //     return false;
  // }
}
