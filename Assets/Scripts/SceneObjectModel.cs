using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObjectModel : ProjectComponent {

    public float platformDistanceBetweenMin;
    public float platformDistanceBetweenMax;
    public float platformMaxHeightChange;
    public ObjectPooler[] platformPools;

    // Diamonds
    public ObjectPooler diamondPool;
    public float distancesBetweenDiamonds;

    // Power Up Diamonds
    public ObjectPooler powerUpDiamondPool;
    public float powerUpDiamondPositionHeight;

    // Spikes
    public ObjectPooler spikePool;
}