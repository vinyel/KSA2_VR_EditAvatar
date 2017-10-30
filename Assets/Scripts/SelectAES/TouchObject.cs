﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchObject : MonoBehaviour {
    // rayが届く範囲
    public float distance = 100f;
    public static string selectedAvatarName;
    void Update() {
        // 左クリックを取得
        if (Input.GetMouseButtonDown(0)) {
            // クリックしたスクリーン座標をrayに変換
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Rayの当たったオブジェクトの情報を格納する
            RaycastHit hit = new RaycastHit();
            // オブジェクトにrayが当たった時
            if (Physics.Raycast(ray, out hit, distance)) {
                // rayが当たったオブジェクトの名前を取得
                string objectName = hit.collider.gameObject.name;
                //Debug.Log(objectName);
                //--アバタが決定し、編集部屋のシーンへ移行
                if (objectName == "DeterminePanel") {
                    DontDestroyOnLoad(AvatarInputToList.avatarNow);
                    for ( int i = AvatarInputToList.avatarList.Count - 1; i >= 0; i-- ) {
                        if ( AvatarInputToList.avatarList[i] != AvatarInputToList.avatarNow ) {
                            Debug.Log(AvatarInputToList.avatarList[i]);
                            Destroy(AvatarInputToList.avatarList[i]);
                        }
                    }
                    SceneManager.LoadScene("AES");
                }
                selectedAvatarName = selectedAvatarNameFromPanel(objectName);
            }
        }
    }

    string selectedAvatarNameFromPanel(string panelName) {
        if ( panelName == "SelectPanel01" ) {
            return "man04x";
        }
        else if ( panelName == "SelectPanel11" ) {
            return "woman01x";
        }
        return null;
    }

}
