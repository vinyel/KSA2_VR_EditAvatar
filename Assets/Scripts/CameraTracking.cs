using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--参考:http://tech.pjin.jp/blog/2016/11/04/unity_skill_5/

public class CameraTracking : MonoBehaviour {

    GameObject targetObj = null;
    Vector3 targetPos;
    private float angle = 90f;

    // Use this for initialization
    void Start () {
        targetObj = AvatarInputToList.avatarNow;
        targetPos = targetObj.transform.position;
    }

    // Update is called once per frame
    void LateUpdate() {
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;

        if ( Input.GetKey(KeyCode.E) || Input.GetKey("joystick button 5") ) {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(targetPos, axis, angle * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q) || Input.GetKey("joystick button 4")) {
            Vector3 axis = transform.TransformDirection(Vector3.down);
            transform.RotateAround(targetPos, axis, angle * Time.deltaTime);
        }
    }
}
