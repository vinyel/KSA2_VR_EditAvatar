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
        PracticeWearingInit();
	}

    //--自身の着ているものを初期化するメソッド
    public void PracticeWearingInit() {

        // Listの初期化
        falseClothesList.Clear();
        falseClothesList.RemoveAll(MatchNullable);

        hukuNow = "Huku01";
        zubonNow = "Zubon01";
        kamiNow = "Hair01";
        //akusesariNow = "Megane01";
        kaoNow = "Body";
        kutsuNow = "Shoes00";

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

    private static bool MatchNullable(GameObject game) {
        return (game == null) ? true : false;
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
