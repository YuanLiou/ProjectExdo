using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondsGenerator : MonoBehaviour {
    public ObjectPooler diamondPooler;
    public float distancesBetweenDiamonds;

    public void SpawnDiamonds(Vector3 spawnPosition) {
        GameObject diamond = diamondPooler.GetPoolObject();
        diamond.transform.position = spawnPosition;
        diamond.SetActive(true);

        GameObject leftDiamond = diamondPooler.GetPoolObject();
        leftDiamond.transform.position = new Vector3(spawnPosition.x - distancesBetweenDiamonds, spawnPosition.y, spawnPosition.z);
        leftDiamond.SetActive(true);

        GameObject rightDiamond = diamondPooler.GetPoolObject();
        rightDiamond.transform.position = new Vector3(spawnPosition.x + distancesBetweenDiamonds, spawnPosition.y, spawnPosition.z);
        rightDiamond.SetActive(true);
    }
}