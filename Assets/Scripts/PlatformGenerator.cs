using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public Transform platformGenerationPoint;
	private float platformWidth;
	
	private float distanceBetweenPlatform;
	public float platformDistanceBetweenMin;
	public float platformDistanceBetweenMax;
	
	private int platformSelector;
	private float[] platformWidths;
	
	public ObjectPooler[] objectPools;

	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;
	
	public float maxHeightChange;
	private float heightChange;
	
	// Use this for initialization
	void Start () {
		platformWidths = new float[objectPools.Length];
		for (int i = 0; i < objectPools.Length; i++) {
			platformWidths[i] = objectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
		}

		minHeight = transform.position.y;    // same as PlatformGenerator's Height
		maxHeight = maxHeightPoint.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < platformGenerationPoint.position.x) {
			platformSelector = Random.Range(0, objectPools.Length);
			
			distanceBetweenPlatform = Random.Range(platformDistanceBetweenMin, platformDistanceBetweenMax);
			transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetweenPlatform, transform.position.y, transform.position.z);

			heightChange = transform.position.y + Random.Range(-maxHeightChange, maxHeightChange);
			if (heightChange > maxHeight) {
				heightChange = maxHeight;
			} else if (heightChange < minHeight) {
				heightChange = minHeight;
			}
			
			GameObject newPlatform = objectPools[platformSelector].GetGameObject();
			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive(true);
			
			// Adjust the gap's size. move the platform generator to end of platform.
			transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), heightChange, transform.position.z);
		}
	}
}
