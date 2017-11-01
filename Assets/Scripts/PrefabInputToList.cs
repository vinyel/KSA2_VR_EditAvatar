using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//マネキンに服を着せるメソッド
//新たに服等を実装したときに手入力あり★これとManekinBehaviour.csに手入力


public class PrefabInputToList : MonoBehaviour {
    //--インスタンス化する前のprefab, 服, ズボン, 矢印
    public static List<GameObject> pfHukuList = new List<GameObject>();
    public static List<GameObject> pfZubonList = new List<GameObject>();
    public static List<GameObject> pfKamiList = new List<GameObject>();
    public static List<GameObject> pfKaburimonoList = new List<GameObject>();
    public static List<GameObject> pfMeganeList = new List<GameObject>();
    //public static List<GameObject> pf


    public static GameObject yajirushi;
    public static GameObject pressAbutton;
    // Use this for initialization
    void Start () {
        // Listの初期化
        pfHukuList.Clear();
        pfZubonList.Clear();
        pfHukuList.RemoveAll(MatchNullable);
        pfZubonList.RemoveAll(MatchNullable);

        //服をリストに入れていく, loadの中身は★手入力
        pfHukuList.Add((GameObject)Resources.Load("Prefabs/"+ AvatarInputToList.genderNow +"/huku/Huku01"));
        pfHukuList.Add((GameObject)Resources.Load("Prefabs/"+ AvatarInputToList.genderNow +"/huku/Huku02"));
        pfHukuList.Add((GameObject)Resources.Load("Prefabs/"+ AvatarInputToList.genderNow +"/huku/Huku03"));

        pfZubonList.Add((GameObject)Resources.Load("Prefabs/" + AvatarInputToList.genderNow + "/zubon/Zubon01"));
        pfZubonList.Add((GameObject)Resources.Load("Prefabs/" + AvatarInputToList.genderNow + "/zubon/Zubon02"));

        pfKamiList.Add((GameObject)Resources.Load("Prefabs/" + AvatarInputToList.genderNow + "/kami/Kami01"));
        pfKamiList.Add((GameObject)Resources.Load("Prefabs/" + AvatarInputToList.genderNow + "/kami/Kami02"));

        pfKaburimonoList.Add((GameObject)Resources.Load("Prefabs/" + AvatarInputToList.genderNow + "/kaburimono/Kaburimono01"));

        pfMeganeList.Add((GameObject)Resources.Load("Prefabs/" + AvatarInputToList.genderNow + "/megane/Megane01"));

        //pfZubonList.Add((GameObject)Resources.Load("Prefabs/zubon01"));
        //pfZubonList.Add((GameObject)Resources.Load("Prefabs/zubon02"));
        yajirushi = (GameObject)Resources.Load("Prefabs/yajirushi2");
        pressAbutton = (GameObject)Resources.Load("Prefabs/PressAbutton");
    }

	// Update is called once per frame
	void Update () {
		
	}

    private static bool MatchNullable(GameObject game) {
        return (game == null) ? true : false;
    }

}
