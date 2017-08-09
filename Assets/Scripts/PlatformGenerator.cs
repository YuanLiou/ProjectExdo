using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject platform;
	public Transform platformGenerationPoint;
	public float distanceBetweenPlatform;

	private float platformWidth;
	
	// Use this for initialization
	void Start () {
		platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < platformGenerationPoint.position.x) {
			transform.position = new Vector3(transform.position.x + platformWidth + distanceBetweenPlatform, transform.position.y, transform.position.z);
			
			// Generate new platform
			Instantiate(platform, transform.position, transform.rotation);
		}
	}
}
