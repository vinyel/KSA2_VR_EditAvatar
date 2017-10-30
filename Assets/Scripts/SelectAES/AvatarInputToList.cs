using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

//アバタ選択画面でのアバタをリスト管理
//同時に選択されたアバタや性別などを管理

public class AvatarInputToList : MonoBehaviour {
    public static List<GameObject> avatarList = new List<GameObject>();
    public static GameObject avatarNow; //gameobject of avatar
    public static string genderNow; //"man" or "woman"

    // Use this for initialization
    void Start () {
        var ava = GameObject.Find("man04x") as GameObject;
        avatarList.Add(ava);
        ava = GameObject.Find("woman01x") as GameObject;
        avatarList.Add(ava);

        //--最初に表示させておくアバタを指定
        manageAvatar(avatarList[0].name);
        avatarNow = avatarList[0];
        genderNow = "man";
    }
	
	// Update is called once per frame
	void Update () {
        //--選択されたパネルのアバタを表示
        string san = TouchObject.selectedAvatarName;
        if ( san != null ) {
            manageAvatar(san);
        }
        
	}

    //--引数のアバタだけをactive(表示状態)にする
    void manageAvatar(string ava) {
        for ( int i = avatarList.Count - 1; i >= 0; i--  ) {
            if ( ava == avatarList[i].name ) {
                avatarList[i].SetActive(true);
                avatarNow = avatarList[i];
                judgeGender(avatarList[i].name);
                PlayerBehaviour pb = avatarList[i].GetComponent<PlayerBehaviour>();
                pb.PracticeWearingInit();
                continue;
            }
            avatarList[i].SetActive(false);
        }
    }

    void judgeGender(string gen) {
        //あいまい検索を活用
        if (Regex.IsMatch(gen, "^man.*$", RegexOptions.Singleline)) {
            genderNow = "man";
            
        }
        else if (Regex.IsMatch(gen, "^woman.*$", RegexOptions.Singleline)) {
            genderNow = "woman";
        }

    }

}
