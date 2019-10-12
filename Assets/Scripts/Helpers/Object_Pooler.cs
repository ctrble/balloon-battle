using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// from https://www.raywenderlich.com/136091/object-pooling-unity
public class Object_Pooler : MonoBehaviour {

	public List<GameObject> pooledBullets;
	public GameObject cannonball;
	public List<GameObject> pooledSmoke;
	public GameObject smoke;
	public int amountToPool;
	public bool shouldExpand = true;

	void OnEnable () {

		amountToPool = 10;

		pooledBullets = new List<GameObject>();
		for (int i = 0; i < amountToPool; i++) {

			GameObject obj = (GameObject)Instantiate(cannonball, gameObject.transform.position, Quaternion.identity, gameObject.transform);
			obj.SetActive(false);
			pooledBullets.Add(obj);
		}

		pooledSmoke = new List<GameObject>();
		for (int i = 0; i < amountToPool; i++) {

			GameObject obj = (GameObject)Instantiate(smoke, gameObject.transform.position, Quaternion.identity, gameObject.transform);
			obj.SetActive(false);
			pooledSmoke.Add(obj);
		}
	}

	public GameObject GetPooledObject(string item) {

		if (item == "cannonball") {

			for (int i = 0; i < pooledBullets.Count; i++) {

				if (!pooledBullets[i].activeInHierarchy) {

					return pooledBullets[i];
				}
			}

			if (shouldExpand) {

				GameObject obj = (GameObject)Instantiate(cannonball, gameObject.transform.position, Quaternion.identity, gameObject.transform);
				obj.SetActive(false);
				pooledBullets.Add(obj);
				return obj;

			} else {
				return null;
			}
		}

		else if (item == "smoke") {

			for (int i = 0; i < pooledSmoke.Count; i++) {

				if (!pooledSmoke[i].activeInHierarchy) {

					return pooledSmoke[i];
				}
			}

			if (shouldExpand) {

				GameObject obj = (GameObject)Instantiate(smoke, gameObject.transform.position, Quaternion.identity, gameObject.transform);
				obj.SetActive(false);
				pooledSmoke.Add(obj);
				return obj;

			} else {
				return null;
			}
		}

		else {
			return null;
		}
	}
}
