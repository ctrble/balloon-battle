using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon_Hit_Detective : MonoBehaviour {

  // Delegate
  public delegate void HitDelegate();
  public static event HitDelegate BalloonWasHit;

  // Scripts
  private Player_Data playerData;

  // Objects
  public GameObject hitHole;

  void OnEnable() {

    if (playerData == null)
      playerData = gameObject.GetComponentInParent<Player_Data>();
  }

  void OnTriggerEnter2D(Collider2D other) {

    if (other.name == "Cannonball(Clone)") {

      playerData.hits += 1;

      Vector3 balloonPosition = new Vector3(transform.position.x, transform.position.y, 0);
      Vector3 hitPosition = new Vector3(other.transform.position.x, other.transform.position.y, 0);
      Vector3 holePosition = (balloonPosition + hitPosition) * 0.5f;

      Instantiate(hitHole, holePosition, other.transform.rotation, gameObject.transform);

      //event call
      BalloonWasHit();
    }
  }
}
