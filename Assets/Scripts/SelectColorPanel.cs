using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

//メインカメラに取り付けるクラス

//----新しく衣装を作ったときにマテリアルが増えた場合、修正、追加が必要
//アバタの更新のたびに確認が必要

public class SelectColorPanel : MonoBehaviour {
    public static bool isTouch = false;
    public float distance = 100f;

    private GameObject selectedObject;
    private List<Material> partsMaterialList = new List<Material>();

    //--パネルオブジェクト11種類0~10
    public static List<GameObject> colorPanelList = new List<GameObject>();
    //--パネルオブジェクト0髪、1服、2ズボン、3被り物、4眼鏡、5靴
    public static List<GameObject> partsPanelList = new List<GameObject>();

    private GameObject defaultPartsPanel;

    private GameObject isSelectedPartsPanel;

    private bool isMenuOpen = false;

    // Use this for initialization
    void Start () {
        //--リストにパネルオブジェクトをそれぞれのリストに格納
        seekChildAndInputObjectToList();
        defaultPartsPanel = partsPanelList[0];
        isSelectedPartsPanel = defaultPartsPanel; //最初は0番目の髪を選択
        isSelectedPartsPanel.GetComponent<Renderer>().material.color = Color.red;
        for (int i = colorPanelList.Count - 1; i >= 0; i--) {
            colorPanelList[i].SetActive(false);
        }
        for (int j = partsPanelList.Count - 1; j >= 0; j--) {
            partsPanelList[j].SetActive(false);
        }
        isMenuOpen = false;
    }
	
	// Update is called once per frame
	void Update () {
        //右クリックを取得で色選択メニュを閉じる
        if (Input.GetMouseButtonDown(1) && isMenuOpen ) {
            for (int i = colorPanelList.Count - 1; i >= 0; i--) {
                colorPanelList[i].SetActive(false);
            }
            for (int j = partsPanelList.Count - 1; j >= 0; j--) {
                partsPanelList[j].SetActive(false);
            }
            isMenuOpen = false;
        }
        else if (Input.GetMouseButtonDown(1) && !isMenuOpen) {
            for (int i = colorPanelList.Count - 1; i >= 0; i--) {
                colorPanelList[i].SetActive(true);
            }
            for (int j = partsPanelList.Count - 1; j >= 0; j--) {
                partsPanelList[j].SetActive(true);
            }
            isMenuOpen = true;
        }

        // 左クリックを取得
        if (Input.GetMouseButtonDown(0)) {

            isTouch = true;
            // クリックしたスクリーン座標をrayに変換
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Rayの当たったオブジェクトの情報を格納する
            RaycastHit hit = new RaycastHit();
            // オブジェクトにrayが当たった時
            if (Physics.Raycast(ray, out hit, distance)) {
                // rayが当たったオブジェクトを取得
                string objectName = hit.collider.gameObject.name;  //名前
                selectedObject = hit.collider.gameObject; //オブジェクト

                //もし、部位パネルが選ばれたら現在選択されている部位パネルを更新
                if ( selectedObject == partsPanelList[0] ) {
                    isSelectedPartsPanel.GetComponent<Renderer>().material.color = Color.white;
                    isSelectedPartsPanel = partsPanelList[0];
                    isSelectedPartsPanel.GetComponent<Renderer>().material.color = Color.red;
                }
                else if (selectedObject == partsPanelList[1]) {
                    isSelectedPartsPanel.GetComponent<Renderer>().material.color = Color.white;
                    isSelectedPartsPanel = partsPanelList[1];
                    isSelectedPartsPanel.GetComponent<Renderer>().material.color = Color.red;
                }
                else if (selectedObject == partsPanelList[2]) {
                    isSelectedPartsPanel.GetComponent<Renderer>().material.color = Color.white;
                    isSelectedPartsPanel = partsPanelList[2];
                    isSelectedPartsPanel.GetComponent<Renderer>().material.color = Color.red;
                }
                else if (selectedObject == partsPanelList[3]) {
                    isSelectedPartsPanel.GetComponent<Renderer>().material.color = Color.white;
                    isSelectedPartsPanel = partsPanelList[3];
                    isSelectedPartsPanel.GetComponent<Renderer>().material.color = Color.red;
                }
                else if (selectedObject == partsPanelList[4]) {
                    isSelectedPartsPanel.GetComponent<Renderer>().material.color = Color.white;
                    isSelectedPartsPanel = partsPanelList[4];
                    isSelectedPartsPanel.GetComponent<Renderer>().material.color = Color.red;
                }
                else if (selectedObject == partsPanelList[5]) {
                    isSelectedPartsPanel.GetComponent<Renderer>().material.color = Color.white;
                    isSelectedPartsPanel = partsPanelList[5];
                    isSelectedPartsPanel.GetComponent<Renderer>().material.color = Color.red;
                }

                //もし 色パネルが選ばれたら現在選択されている部位パネルに関連するマテリアルの色を変える
                if (selectedObject == colorPanelList[0]) {
                    changeColorOfParticularObject(colorPanelList[0]);
                }
                else if (selectedObject == colorPanelList[1]) {
                    changeColorOfParticularObject(colorPanelList[1]);
                }
                else if (selectedObject == colorPanelList[2]) {
                    changeColorOfParticularObject(colorPanelList[2]);
                }
                else if (selectedObject == colorPanelList[3]) {
                    changeColorOfParticularObject(colorPanelList[3]);
                }
                else if (selectedObject == colorPanelList[4]) {
                    changeColorOfParticularObject(colorPanelList[4]);
                }
                else if (selectedObject == colorPanelList[5]) {
                    changeColorOfParticularObject(colorPanelList[5]);
                }
                else if (selectedObject == colorPanelList[6]) {
                    changeColorOfParticularObject(colorPanelList[6]);
                }
                else if (selectedObject == colorPanelList[7]) {
                    changeColorOfParticularObject(colorPanelList[7]);
                }
                else if (selectedObject == colorPanelList[8]) {
                    changeColorOfParticularObject(colorPanelList[8]);
                }
                else if (selectedObject == colorPanelList[9]) {
                    changeColorOfParticularObject(colorPanelList[9]);
                }
                else if (selectedObject == colorPanelList[10]) {
                    changeColorOfParticularObject(colorPanelList[10]);
                }

            }
        }
    }

    //--このクラスをつけているメインカメラの子を探し、カラーパネルと部位パネルをリストに入れるメソッド
    void seekChildAndInputObjectToList() {
        var panelTransform = this.GetComponentsInChildren<Transform>();
        foreach (Transform child00 in panelTransform) {
            if (Regex.IsMatch(child00.gameObject.name, "^color.*$", RegexOptions.Singleline)) {
                colorPanelList.Add(child00.gameObject);
            }
            else if (Regex.IsMatch(child00.gameObject.name, "^.*Panel$", RegexOptions.Singleline)) {
                partsPanelList.Add(child00.gameObject);
            }
        }
    }
    //選択された項目を選択された色で変える
    void changeColorOfParticularObject ( GameObject colorPanel ) {
        //選択されたカラーパネルオブジェクトをマテリアル型で取得
        Material colorMaterial = colorPanel.GetComponent<Renderer>().material;
        inputMaterialToList(isSelectedPartsPanel); //現在選択されている部位のpartsMaterialList(Material型のリスト)を取得
        for (int i = partsMaterialList.Count - 1; i >= 0; i-- ) {
            partsMaterialList[i].color = colorMaterial.color;
        }
        
    }

    //--部位パネルから、マテリアルを選んでリストに入れる,マテリアル名は男女ばらばらになるかもしれんので場合分け。ディレクトリはAssets/Resources/...
    void inputMaterialToList(GameObject partsPanel) {
        //マテリアルのリストの初期化
        partsMaterialList.Clear();
        partsMaterialList.RemoveAll(MatchNullable);

        if ( AvatarInputToList.genderNow == "man" ) {
            //色を変えさせたい髪の毛のマテリアル群
            if (partsPanel.name == "kamiPanel") {
                partsMaterialList.Add((Material)Resources.Load("Materials/man/kami/kaminoke1"));
                partsMaterialList.Add((Material)Resources.Load("Materials/man/kami/kaminoke2"));
            }
            //服のマテリアル群
            else if (partsPanel.name == "hukuPanel") {
                partsMaterialList.Add((Material)Resources.Load("Materials/man/huku/huku1"));
                partsMaterialList.Add((Material)Resources.Load("Materials/man/huku/huku2"));
            }
            //ズボンのマテリアル
            else if (partsPanel.name == "zubonPanel") {
                partsMaterialList.Add((Material)Resources.Load("Materials/man/zubon/zubon1"));
                partsMaterialList.Add((Material)Resources.Load("Materials/man/zubon/zubon2"));
            }
            //被り物のマテリアル
            else if (partsPanel.name == "kaburimonoPanel") {
                partsMaterialList.Add((Material)Resources.Load("Materials/man/kaburimono/Suzanne"));
            }
            //眼鏡のマテリアル
            else if (partsPanel.name == "meganePanel") {
                partsMaterialList.Add((Material)Resources.Load("Materials/man/megane/megane1"));
            }
            //靴のマテリアル
            else if (partsPanel.name == "kutsuPanel") {
                partsMaterialList.Add((Material)Resources.Load("Materials/man/kutsu/Shoes00-1"));
            }
        }
        else if (AvatarInputToList.genderNow == "woman") {

            //髪の毛のマテリアル群
            if (partsPanel.name == "kamiPanel") {
                partsMaterialList.Add((Material)Resources.Load("Materials/woman/kami/Hair01"));
            }
            //服のマテリアル群
            else if (partsPanel.name == "hukuPanel") {
                partsMaterialList.Add((Material)Resources.Load("Materials/woman/huku/huku1"));
            }
            //ズボンのマテリアル
            else if (partsPanel.name == "zubonPanel") {
                partsMaterialList.Add((Material)Resources.Load("Materials/woman/zubon/zubon1"));
                partsMaterialList.Add((Material)Resources.Load("Materials/woman/zubon/zubon2"));
            }
            //被り物のマテリアル
            else if (partsPanel.name == "kaburimonoPanel") {
                partsMaterialList.Add((Material)Resources.Load("Materials/woman/kaburimono/Suzanne"));
            }
            //眼鏡のマテリアル
            else if (partsPanel.name == "meganePanel") {
                partsMaterialList.Add((Material)Resources.Load("Materials/woman/megane/megane1"));
            }
            //靴のマテリアル
            else if (partsPanel.name == "kutsuPanel") {
                partsMaterialList.Add((Material)Resources.Load("Materials/woman/kutsu/Shoes00-1"));
            }
        }

    }
    //マテリアルのリストの初期化のために
    private static bool MatchNullable(Material mat) {
        return (mat == null) ? true : false;
    }
}
