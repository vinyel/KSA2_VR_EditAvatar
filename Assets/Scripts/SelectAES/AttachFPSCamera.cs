using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachFPSCamera : MonoBehaviour {
    public static GameObject fpsCamera;

    // Use this for initialization
    void Start () {
        fpsCamera = GameObject.Find("FPSCamera");
        fpsCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
