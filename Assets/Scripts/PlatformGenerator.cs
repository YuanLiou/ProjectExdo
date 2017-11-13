using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : ProjectComponent {
    private SceneObjectModel sceneObjectModel;

    public Transform platformGenerationPoint;
    private float distanceBetweenPlatform;

    private int platformSelector;
    private float[] platformWidths;

    public Transform platformMaxHeightPoint;
    private float minHeight;
    private float maxHeight;
    private float heightChange;

    // Diamonds
    private DiamondsGenerator diamondsGenerator;
    public float diamondsGenerateThreshold;

    // Power Up Diamonds
    public float powerUpAppearThreshold;

    // Spike
    public float spikeGenerateThreshold;

    // Use this for initialization
    void Start() {
        sceneObjectModel = app.model.sceneObjectModel;
        diamondsGenerator = app.controller.diamondsGenerator;

        platformWidths = new float[sceneObjectModel.platformPools.Length];
        for (int i = 0; i < sceneObjectModel.platformPools.Length; i++) {
            platformWidths[i] = sceneObjectModel.platformPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;   // same as PlatformGenerator's Height
        maxHeight = platformMaxHeightPoint.position.y;
    }

    // Update is called once per frame
    void Update() {
        if (transform.position.x < platformGenerationPoint.position.x) {
            platformSelector = Random.Range(0, sceneObjectModel.platformPools.Length);
            distanceBetweenPlatform = Random.Range(sceneObjectModel.platformDistanceBetweenMin, sceneObjectModel.platformDistanceBetweenMax);
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetweenPlatform, transform.position.y, transform.position.z);

            GameObject newPlatform = sceneObjectModel.platformPools[platformSelector].GetPoolObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if (Random.Range(0f, 100f) < powerUpAppearThreshold) {
                GameObject newPowerUp = sceneObjectModel.powerUpDiamondPool.GetPoolObject();
                float powerUpHeight = sceneObjectModel.powerUpDiamondPositionHeight;
                newPowerUp.transform.position = transform.position + new Vector3((platformWidths[platformSelector] / 2) + (distanceBetweenPlatform / 2), Random.Range(powerUpHeight / 2, powerUpHeight), 0f);
                newPowerUp.transform.rotation = transform.rotation;
                newPowerUp.SetActive(true);
            }

            if (Random.Range(0f, 100f) < diamondsGenerateThreshold) {
                diamondsGenerator.SpawnDiamonds(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }

            if (Random.Range(0f, 100f) < spikeGenerateThreshold) {
                GameObject newSpike = sceneObjectModel.spikePool.GetPoolObject();
                float currentPlatformWidth = platformWidths[platformSelector];
                float newSpikeXPosition = Random.Range(((currentPlatformWidth / 2) * -1) + 1f, (currentPlatformWidth / 2) - 1f);
                Vector3 newPosition = new Vector3(newSpikeXPosition, .5f, 0f);
                newSpike.transform.position = transform.position + newPosition;
                newSpike.transform.rotation = transform.rotation;
                newSpike.SetActive(true);
            }

            // Adjust the gap's size. move the platform generator to end of platform.
            // And ramdomly change height
            float maxHeightChange = sceneObjectModel.platformMaxHeightChange;
            heightChange = transform.position.y + Random.Range(-maxHeightChange, maxHeightChange);
            if (heightChange > maxHeight) {
                heightChange = maxHeight;
            } else if (heightChange < minHeight) {
                heightChange = minHeight;
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), heightChange, transform.position.z);
        }
    }
}