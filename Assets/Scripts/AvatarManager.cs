using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarManager : MonoBehaviour {
	// Use this for initialization
	void Start () {
        //--selectMenuシーンでは位置を固定しているため、解除
        AvatarInputToList.avatarNow.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        //--転倒防止のため、rotationはすべて固定
        AvatarInputToList.avatarNow.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
