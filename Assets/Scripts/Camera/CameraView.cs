using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraView : ProjectComponent {

    public void MoveToRight(float moveDistances) {
        transform.position = new Vector3(
            transform.position.x + moveDistances,
            transform.position.y,
            transform.position.z
            );
    }
}