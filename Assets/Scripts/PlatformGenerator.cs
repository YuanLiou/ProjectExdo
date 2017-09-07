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

    public ObjectPooler[] platformPools;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;

    public float maxHeightChange;
    private float heightChange;

    private DiamondsGenerator diamondsGenerator;
    public float diamondsGenerateThreshold;

    // Spike
    public float spikeGenerateThreshold;

    public ObjectPooler spikePooler;

    public int powerUpHeight;
    public float powerUpAppearThreshold;
    public ObjectPooler powerUpPooler;

    // Use this for initialization
    void Start() {
        platformWidths = new float[platformPools.Length];
        for (int i = 0; i < platformPools.Length; i++) {
            platformWidths[i] = platformPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y; // same as PlatformGenerator's Height
        maxHeight = maxHeightPoint.position.y;

        diamondsGenerator = FindObjectOfType<DiamondsGenerator>();
    }

    // Update is called once per frame
    void Update() {
        if (transform.position.x < platformGenerationPoint.position.x) {
            platformSelector = Random.Range(0, platformPools.Length);

            distanceBetweenPlatform = Random.Range(platformDistanceBetweenMin, platformDistanceBetweenMax);
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetweenPlatform, transform.position.y, transform.position.z);

            heightChange = transform.position.y + Random.Range(-maxHeightChange, maxHeightChange);
            if (heightChange > maxHeight) {
                heightChange = maxHeight;
            } else if (heightChange < minHeight) {
                heightChange = minHeight;
            }

            if (Random.Range(0f, 100f) < powerUpAppearThreshold) {
                GameObject newPowerUp = powerUpPooler.GetPoolObject();
                newPowerUp.transform.position = transform.position + new Vector3((platformWidths[platformSelector] / 2) + (distanceBetweenPlatform / 2), Random.Range(powerUpHeight / 2, powerUpHeight), 0f);
                newPowerUp.transform.rotation = transform.rotation;
                newPowerUp.SetActive(true);
            }

            GameObject newPlatform = platformPools[platformSelector].GetPoolObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if (Random.Range(0f, 100f) < diamondsGenerateThreshold) {
                diamondsGenerator.SpawnDiamonds(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }

            if (Random.Range(0f, 100f) < spikeGenerateThreshold) {
                GameObject newSpike = spikePooler.GetPoolObject();
                float currentPlatformWidth = platformWidths[platformSelector];
                float newSpikeXPosition = Random.Range(((currentPlatformWidth / 2) * -1) + 1f, (currentPlatformWidth / 2) - 1f);
                Vector3 newPosition = new Vector3(newSpikeXPosition, .5f, 0f);
                newSpike.transform.position = transform.position + newPosition;
                newSpike.transform.rotation = transform.rotation;
                newSpike.SetActive(true);
            }

            // Adjust the gap's size. move the platform generator to end of platform.
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), heightChange, transform.position.z);
        }
    }
}