using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//マネキンに服を着せるメソッド

public class PrefabInputToList : MonoBehaviour {
    //--インスタンス化する前のprefab, 服, ズボン, 矢印
    public static List<GameObject> pfHukuList = new List<GameObject>();
    public static List<GameObject> pfZubonList = new List<GameObject>();
    public static GameObject yajirushi;
    public static GameObject pressF;
    // Use this for initialization
    void Start () {
        Debug.Log(AvatarInputToList.genderNow);
        //服をリストに入れていく, loadの中身は★手入力
        pfHukuList.Add((GameObject)Resources.Load("Prefabs/"+ AvatarInputToList.genderNow +"/huku/Huku01"));
        pfHukuList.Add((GameObject)Resources.Load("Prefabs/"+ AvatarInputToList.genderNow +"/huku/Huku02"));
        pfHukuList.Add((GameObject)Resources.Load("Prefabs/"+ AvatarInputToList.genderNow +"/huku/Huku03"));
        
        //pfZubonList.Add((GameObject)Resources.Load("Prefabs/zubon01"));
        //pfZubonList.Add((GameObject)Resources.Load("Prefabs/zubon02"));
        yajirushi = (GameObject)Resources.Load("Prefabs/yajirushi2");
        pressF = (GameObject)Resources.Load("Prefabs/PressF");
    }

	// Update is called once per frame
	void Update () {
		
	}

    

}
