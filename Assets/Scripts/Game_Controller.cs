using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour {

  // Scripts
  private Game_Data gameData;
  private Game_Input_Contoller gameInputController;

  // Objects
  public GameObject[] players;
  public GameObject p1WinSprite;
  public GameObject p2WinSprite;

  void OnEnable() {

    if (gameData == null)
      gameData = gameObject.GetComponent<Game_Data>();

    if (gameInputController == null)
      gameInputController = gameObject.GetComponent<Game_Input_Contoller>();

    if (p1WinSprite == null)
      p1WinSprite = p1WinSprite.gameObject.transform.GetChild(0).gameObject;

    if (p2WinSprite == null)
      p2WinSprite = p2WinSprite.gameObject.transform.GetChild(1).gameObject;

    gameData.playerPoints[0] = 0;
    gameData.playerPoints[1] = 0;

    StartCoroutine(CreatePlayer(0, new Vector3(-7, 1, 0), 0));
    StartCoroutine(CreatePlayer(1, new Vector3(7, 1, 0), 0));
  }

  void Update() {

    if (gameInputController.Restart())
      SceneManager.LoadScene("Main Game");

    // if(gameInputController.Quit())
    //   Application.Quit();
  }

  void CheckForWinner() {

    if (gameData.playerPoints[0] >= 5) {

      p1WinSprite.SetActive(true);
      gameData.gameOver = true;
    }

    if (gameData.playerPoints[1] >= 5) {

      p2WinSprite.SetActive(true);
      gameData.gameOver = true;
    }
  }

  IEnumerator CreatePlayer(int player, Vector3 startingPosition, float delay) {

    yield return new WaitForSeconds(delay);

    if (!gameData.gameOver)
      Instantiate(players[player], startingPosition, Quaternion.identity);
  }

  public void GotPoint(GameObject player) {

    if (player.name == "Player 1" || player.name == "Player 1(Clone)") {

      gameData.playerPoints[1] += 1;
      CheckForWinner();
      StartCoroutine(CreatePlayer(0, new Vector3(-7, 1, 0), 2));
    }

    if (player.name == "Player 2" || player.name == "Player 2(Clone)") {

      gameData.playerPoints[0] += 1;
      CheckForWinner();
      StartCoroutine(CreatePlayer(1, new Vector3(7, 1, 0), 2));
    }
  }
}
