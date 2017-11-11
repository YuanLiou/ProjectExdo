using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectComponents : MonoBehaviour {
    public ProjectApplication app {
        get {
            return FindObjectOfType<ProjectApplication>();
        }
    }
}