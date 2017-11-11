using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectComponent : MonoBehaviour {
    public ProjectApplication app {
        get {
            return FindObjectOfType<ProjectApplication>();
        }
    }
}