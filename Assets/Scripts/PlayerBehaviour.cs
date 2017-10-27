using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--アバタにくっつけるスクリプト

public class PlayerBehaviour : MonoBehaviour {
    //--アバタの座標を取得
    public static float avaX;
    public static float avaY;
    public static float avaZ;

    //--初期化用の変数
    public static string hukuNow;
    public static string zubonNow;
    public static string kamiNow;
    public static string akusesariNow;
    public static string kaoNow;
    public static string kutsuNow;

    private string seibetsuNow;
    public static string avatarNow;

    public static List<GameObject> falseClothesList = new List<GameObject>();

    // Use this for initialization
    void Start () {
        
        //--性別選択結果、ほかクラスのフィールド
        seibetsuNow = GameSystem01.seibetsu;
        //--選択されなかった性別のアバタを削除
        deleteAvatar(seibetsuNow);

        //--起動時に自身の着ているものを設定
        hukuNow = "Huku01";
        zubonNow = "Zubon01";
        kamiNow = "Hair01";
        akusesariNow = "Megane01";
        kaoNow = "Body";
        kutsuNow = "Shoes00";

        PracticeWearingInit();
	}

    //--アバター削除用メソッド
    private void deleteAvatar(string ava) {
        if ( ava == "woman" ) {
            avatarNow = "woman00x";
            Destroy(GameObject.Find("man03x"));
        } else {
            avatarNow = "man03x"; //カメラを追従させるために、確定したモデルの名前を格納
            Destroy(GameObject.Find("woman00x")); //選択されたのが男性ならば、女性のアバタを削除
        }
    }

    //--自身の着ているものを初期化するメソッド
    public void PracticeWearingInit() {
        var avatar = GameObject.Find(this.gameObject.name) as GameObject;
        var avaTransform = avatar.GetComponentInChildren<Transform>();

        foreach (Transform avaChild in avaTransform) {
            //--着ている服を判定
            if (nameJudge(hukuNow, avaChild.gameObject.name)) {               
                continue;
            }
            //--ズボン
            if (nameJudge(zubonNow, avaChild.gameObject.name)) {
                continue;
            }
            //--髪のけ
            if (nameJudge(kamiNow, avaChild.gameObject.name)) {
                continue;
            }
            //--アクセサリ
            if (nameJudge(akusesariNow, avaChild.gameObject.name)) {
                continue;
            }
            //--顔
            if (nameJudge(kaoNow, avaChild.gameObject.name)) {
                continue;
            }
            //--靴
            if (nameJudge(kutsuNow, avaChild.gameObject.name)) {
                continue;
            }
            //該当しないものはリストで管理するためfalseClothesに代入し、隠す(着ない)
            falseClothesList.Add(avaChild.gameObject);
            
            avaChild.gameObject.SetActive(false);
        }

    }
    //->名前判定
    private bool nameJudge(string now, string child) {
        if ( now == child ) {
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update () {
        //--アバタの位置を取得
        avaX = this.transform.position.x;
        avaY = this.transform.position.y;
        avaZ = this.transform.position.z;
    }

}
