using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    public GameObject pooledObject;
    public int pooledAmount;

    private List<GameObject> pooledObjects;
	
    // Use this for initialization
    void Start () {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++) {
            GameObject gameObject = (GameObject) Instantiate(pooledObject);
            gameObject.SetActive(false);
            pooledObjects.Add(gameObject);
        }
    }

    public GameObject GetPoolObject() {
        for (int i = 0; i < pooledObjects.Count; i++) {
            // Get first non active pooled object.
            if (!pooledObjects[i].activeInHierarchy) {
                return pooledObjects[i];
            }
        }
		
        GameObject gameObject = (GameObject) Instantiate(pooledObject);
        gameObject.SetActive(false);
        pooledObjects.Add(gameObject);
        return gameObject;
    }
}