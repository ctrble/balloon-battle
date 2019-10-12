using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Actions_Controller : MonoBehaviour {

  // Scripts
  private Player_Input_Controller playerInputController;
  private Player_Data playerData;
  private Object_Pooler objectPooler;

  // Components
  private Rigidbody2D balloonRB2D;
  private Rigidbody2D basketRB2D;
  private Animator fireAnimator;
  private AudioSource audioSource;

  // Objects
  private GameObject cannon;
  private GameObject cannonShootEffect;

  void OnEnable() {

    if (playerInputController == null)
      playerInputController = gameObject.GetComponent<Player_Input_Controller>();

    if (playerData == null)
      playerData = gameObject.GetComponent<Player_Data>();

    if (objectPooler == null)
      objectPooler = GameObject.FindWithTag("GameController").GetComponent<Object_Pooler>();

    if (balloonRB2D == null)
      balloonRB2D = gameObject.transform.GetChild(0).GetComponent<Rigidbody2D>();

    if (basketRB2D == null)
      basketRB2D = gameObject.transform.GetChild(1).GetComponent<Rigidbody2D>();

    if (fireAnimator == null)
      fireAnimator = gameObject.transform.GetChild(1).transform.GetChild(1).GetComponent<Animator>();

    if (audioSource == null)
      audioSource = gameObject.transform.GetChild(2).GetComponent<AudioSource>();

    if (cannon == null)
      cannon = gameObject.transform.GetChild(1).GetChild(0).gameObject;

    if (cannonShootEffect == null)
      cannonShootEffect = cannon.transform.GetChild(0).gameObject;
  }
  void Update() {

    PlayerMove();
    PlayerAdjustCannon();
    PlayerShoot();
  }

  void PlayerMove() {

    if (playerInputController.MoveUp()) {

      balloonRB2D.AddRelativeForce(Vector2.up * playerData.moveAmount);
      fireAnimator.SetTrigger("moveUp");
    }

    if (playerInputController.MoveDown()) {

      balloonRB2D.AddRelativeForce(-Vector2.up * playerData.moveAmount);
      fireAnimator.SetTrigger("moveDown");
    }
  }

  void PlayerAdjustCannon() {

    if (playerInputController.AimUpRight()) {
      cannon.transform.localPosition = new Vector2(0.25f, -0.7f);
      cannon.transform.localRotation = Quaternion.Euler(0, 0, playerData.cannonAngle += playerData.cannonRotateSpeed);
    }

    if (playerInputController.AimDownRight()) {
      cannon.transform.localPosition = new Vector2(0.25f, -0.7f);
      cannon.transform.localRotation = Quaternion.Euler(0, 0, playerData.cannonAngle -= playerData.cannonRotateSpeed);
    }

    if (playerInputController.AimUpLeft()) {
      cannon.transform.localPosition = new Vector2(-0.25f, -0.7f);
      cannon.transform.localRotation = Quaternion.Euler(0, 180, playerData.cannonAngle += playerData.cannonRotateSpeed);
    }

    if (playerInputController.AimDownLeft()) {
      cannon.transform.localPosition = new Vector2(-0.25f, -0.7f);
      cannon.transform.localRotation = Quaternion.Euler(0, 180, playerData.cannonAngle -= playerData.cannonRotateSpeed);
    }
  }

  void PlayerShoot() {

    if (playerInputController.Shoot()) {

      cannonShootEffect.SetActive(true);
      audioSource.PlayOneShot(playerData.cannonShootSound[Mathf.RoundToInt(Random.Range(0, playerData.cannonShootSound.Length))]);
      basketRB2D.AddRelativeForce(-cannon.transform.right * playerData.knockbackAmount, ForceMode2D.Impulse);

      GameObject cannonball = objectPooler.GetPooledObject("cannonball");
      if (cannonball != null) {
        cannonball.transform.position = cannon.transform.position;
        cannonball.transform.rotation = cannon.transform.rotation;
        cannonball.SetActive(true);
      }

      GameObject smoke = objectPooler.GetPooledObject("smoke");
      if (smoke != null) {

        float posX = cannon.transform.localPosition.x;
        smoke.transform.position = new Vector3(cannon.transform.position.x + (posX * 2), cannon.transform.position.y, cannon.transform.position.z);
        smoke.transform.rotation = cannon.transform.rotation;
        smoke.SetActive(true);
      }
    }
  }
}
