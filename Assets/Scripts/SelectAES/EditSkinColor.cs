using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditSkinColor : MonoBehaviour {
    public Shader skinShader;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        
		if (TouchObject.selectedObject.name == "SkinColorPanel1") {
            changeAvatarSkinColor(TouchObject.selectedObject);
        }
        else if (TouchObject.selectedObject.name == "SkinColorPanel2") {
            changeAvatarSkinColor(TouchObject.selectedObject);
        }
        else if (TouchObject.selectedObject.name == "SkinColorPanel3") {
            changeAvatarSkinColor(TouchObject.selectedObject);
        }
	}

    void changeAvatarSkinColor(GameObject go) {
        Material material = null;
        if (AvatarInputToList.genderNow == "man") {
            material = (Material)Resources.Load("Materials/Man/man00");
        }
        else if ( AvatarInputToList.genderNow == "woman" ) {
            material = (Material)Resources.Load("Materials/Woman/woman002-1");
        }
        material.color = go.GetComponent<Renderer>().material.color;
    }
}
