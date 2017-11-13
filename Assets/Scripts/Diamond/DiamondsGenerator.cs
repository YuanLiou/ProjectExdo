using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondsGenerator : ProjectComponent {
    private SceneObjectModel sceneObjectModel;

    void Start() {
        sceneObjectModel = app.model.sceneObjectModel;
    }

    public void SpawnDiamonds(Vector3 spawnPosition) {
        float distancesBetweenDiamonds = sceneObjectModel.distancesBetweenDiamonds;

        GameObject diamond = sceneObjectModel.diamondPool.GetPoolObject();
        diamond.transform.position = spawnPosition;
        diamond.SetActive(true);

        GameObject leftDiamond = sceneObjectModel.diamondPool.GetPoolObject();
        leftDiamond.transform.position = new Vector3(spawnPosition.x - distancesBetweenDiamonds, spawnPosition.y, spawnPosition.z);
        leftDiamond.SetActive(true);

        GameObject rightDiamond = sceneObjectModel.diamondPool.GetPoolObject();
        rightDiamond.transform.position = new Vector3(spawnPosition.x + distancesBetweenDiamonds, spawnPosition.y, spawnPosition.z);
        rightDiamond.SetActive(true);
    }
}