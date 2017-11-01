using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AttachFPSCamera.csとセット

public class FPSCamera : MonoBehaviour {

    private GameObject mainCam; //third person shooter
    public static GameObject fpsCam;  //first person shooter

    public static GameObject cameraNow;

    // Use this for initialization
    void Start () {
        mainCam = GameObject.Find("Main Camera");
        cameraNow = mainCam;
        fpsCam = AttachFPSCamera.fpsCamera;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z)) {
            Debug.Log(mainCam + ", " + fpsCam);
            if (mainCam.activeSelf) {
                mainCam.SetActive(false);
                fpsCam.SetActive(true);
                cameraNow = fpsCam;
            }
            else {
                mainCam.SetActive(true);
                fpsCam.SetActive(false);
                cameraNow = mainCam;
            }
        }
    }

}
