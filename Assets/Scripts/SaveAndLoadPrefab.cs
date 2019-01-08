#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;


//参考にしたサイトURL:https://qiita.com/ele_enji/items/7303b94bef2b9bda8a3f
//---このクラスはいまのところ使ってない

public class SaveAndLoadPrefab : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private string prefabDir = "avatarPrefab/"; //「Assets/Resources/」以下のprefabファイルの保存先
                                                // Use this for initialization
    public void savePrefab(GameObject gameobj, string name) {
        //prefabの保存フォルダパス
        string prefabDirPath = Application.dataPath + "/Resources/" + prefabDir;
        if (!Directory.Exists(prefabDirPath)) {
            //prefab保存用のフォルダがなければ作成する
            Directory.CreateDirectory(prefabDirPath);
        }

        //prefabの保存ファイルパス
        string prefabPath = prefabDirPath + name + ".prefab";
        if (!File.Exists(prefabPath)) {
            //prefabファイルがなければ作成する
            File.Create(prefabPath);
        }

        //prefabの保存
        UnityEditor.PrefabUtility.CreatePrefab("Assets/Resources/" + prefabDir + name + ".prefab", gameobj);
        UnityEditor.AssetDatabase.SaveAssets();
    }
}
#endif
