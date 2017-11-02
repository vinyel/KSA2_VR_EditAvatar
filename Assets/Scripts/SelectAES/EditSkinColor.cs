using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditSkinColor : MonoBehaviour {
    public Shader skinShader;
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update() {
        if (TouchObject.isTouch) {
            touchColorObject();
        }    
    }

    void touchColorObject() {

        if (TouchObject.selectedObject.name == "SkinColorPanel1") {
            changeAvatarSkinColor(TouchObject.selectedObject);
        }
        else if (TouchObject.selectedObject.name == "SkinColorPanel2") {
            changeAvatarSkinColor(TouchObject.selectedObject);
        }
        else if (TouchObject.selectedObject.name == "SkinColorPanel3") {
            changeAvatarSkinColor(TouchObject.selectedObject);
        }
        else if (TouchObject.selectedObject.name == "SkinColorPanel4") {
            changeAvatarSkinColor(TouchObject.selectedObject);
        }
        else {

        }
    }

    void changeAvatarSkinColor(GameObject go) {
        Material material = null;
        if (AvatarInputToList.genderNow == "man") {
            material = (Material)Resources.Load("Materials/man/man00");
        }
        else if ( AvatarInputToList.genderNow == "woman" ) {
            material = (Material)Resources.Load("Materials/woman/woman002-1");
        }
        material.color = go.GetComponent<Renderer>().material.color;
    }
}
