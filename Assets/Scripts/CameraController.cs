using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : ProjectComponent {

    public CameraView mainCameraView;
    public PlayerController player;    // TODO:: Refactor to PlayerView
    private Vector3 lastPlayerPosition;
    private float distanceToMove;
	
    // Use this for initialization
    void Start () {
        lastPlayerPosition = player.transform.position;
    }
	
    // Update is called once per frame
    void Update () {
        distanceToMove = player.transform.position.x - lastPlayerPosition.x;
        lastPlayerPosition = player.transform.position;
        mainCameraView.MoveToRight(distanceToMove);
    }
}