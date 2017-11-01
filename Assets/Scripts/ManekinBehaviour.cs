using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

//--マネキンに自身にあった服やズボンをくっつけるスクリプト
//現在, 服とズボン3つずつのみ
//あと、アバタがマネキンに近づいたとき(相対距離)矢印をマネキンの上に表示

//アバタが身に着けている衣服のオブジェクトの名前と
//プレハブの名前は統一する！！！

//新たに服等を実装したときに手入力あり★これとあとPrefabInputToList.cs


public class ManekinBehaviour : MonoBehaviour {
    //--マネキンの座標を取得
    private float maneX;
    //private float maneY;
    private float maneZ;

    //--マネキンとアバタの相対距離betweenAvatar
    private float distBetX;
    //private float distBetY;
    private float distBetZ;

    //--インスタンス化したオブジェクトを格納
    //衣服を格納
    private GameObject obj00;
    //矢印を格納
    private GameObject obj01;
    //pressFを格納
    private GameObject obj02;

    //--リストのプレハブを格納★追加時手入力
    private GameObject prefabHuku;
    private GameObject prefabZubon;
    private GameObject prefabKami;
    private GameObject prefabKaburimono;
    private GameObject prefabMegane;

    //--相対距離の判定用変数
    private float DIST = 0.8f;

    //--服を着替えられるか
    private bool canWear = false;

    // Use this for initialization
    void Start () {
        //--アバタの性別によって自身を消す
        //destroyThis();

        if ( IsDestroy() ) {    // 消していいマネキンなら消す
            Destroy(this.gameObject);   
        } else {    // そうでないなら服を着せる
            string manekinName = this.gameObject.name;
            //--マネキンを識別し、各々のマネキンの服を着せる
            manekinJudge(manekinName);
        }
        
    }

    bool IsDestroy() {

        if (AvatarInputToList.genderNow + "Mane" != isManekinGender() ) {    // マネキンと自分の性別が異なる
            return true;    // 消していいマネキン
        }

        return false;    // 消さない
    }
	
	// Update is called once per frame
	void Update () {
        //--マネキンの位置を取得
        maneX = this.transform.position.x;
        //maneY = this.transform.position.y;
        maneZ = this.transform.position.z;

        //--矢印を出現
        appearOrNotYajirushi();

        behaviourBetweenAvaAndMane();
    }

    //--くっつけたマネキンを識別するメソッド----------------------------------------------------------------
    void manekinJudge(string mn) {
        manekinWear(returnClothes(mn));
    }

    //--識別されたマネキンに服やズボンを着せるメソッド
    void manekinWear(GameObject pf) {
        //--プレハブをマネキン自身の場所にインスタンス化

        obj00 = (GameObject)Instantiate(pf, this.transform.position, Quaternion.identity);
        //--インスタンス化されたオブジェクトをマネキンに合わせて回転, xはマネキンの角度から90度マイナスでピッタリ
        obj00.transform.Rotate(this.transform.localEulerAngles.x-90,
            this.transform.localEulerAngles.y,
            this.transform.localEulerAngles.z);
        obj00.name = pf.name;
        obj00.transform.parent = this.transform;
    }

    //--矢印を出現させるかどうか-------------------------------------------------------------------------------
    void appearOrNotYajirushi() {
        //相対距離を計算
        distanceBetweenAvaAndMane();
        if (distJudge(distBetX, distBetZ)) {
            appearYajirushi();
            
        } else {
            destroyYajirushi();
            canWear = false; //着替えられないと判定
        }
        
    }
    //--矢印とpressFを消す
    void destroyYajirushi() {
        Destroy(GameObject.Find(this.name + "yajirushi2") as GameObject);
        Destroy(GameObject.Find(this.name + "PressAbutton") as GameObject);
    }

    //--矢印を出現させる pressFkeyも！
    void appearYajirushi() {
        //--やじるしを初めて生成
        if ( !judegeExistence() ) {
            //--矢印プレハブをマネキン自身の頭上にインスタンス化, obj01は矢印
            obj01 = (GameObject)Instantiate(PrefabInputToList.yajirushi, this.transform.position, Quaternion.identity);
            Vector3 newYajiPosition = this.transform.position;
            newYajiPosition.y += 1.87f;
            obj01.transform.position = newYajiPosition;
            //インスタンス化されたオブジェクトをマネキンに合わせて回転, xはマネキンの角度から90度プラスでピッタリ
            obj01.transform.Rotate(this.transform.localEulerAngles.x+90,
                this.transform.localEulerAngles.y,
                this.transform.localEulerAngles.z);
            obj01.name = this.name + PrefabInputToList.yajirushi.name;
            obj01.transform.parent = this.transform;

            //--pressFkeyをマネキンの頭上に表示する, obj02はpressF
            obj02 = (GameObject)Instantiate(PrefabInputToList.pressAbutton, this.transform.position, Quaternion.identity);
            obj02.transform.Rotate(this.transform.localEulerAngles.x,
                this.transform.localEulerAngles.y,
                this.transform.localEulerAngles.z);
            Vector3 preFPosition = this.transform.position;
            preFPosition.y += 1.68f;
            obj02.name = this.name + PrefabInputToList.pressAbutton.name;

            obj02.transform.position = preFPosition;


            canWear = true; //着替えられると判定
        } else {
            //矢印は表示させたまま何もしない
        }
        
        //--矢印を回転させて見た目をよくするだけ
        obj01.transform.Rotate(0,0,1);
        obj02.transform.Rotate(0,-0.5f,0);

    }
    //--矢印がすでに存在しているかどうか
    bool judegeExistence() {
        var yaji = GameObject.Find(this.name + "yajirushi2") as GameObject;
        if ( yaji == null ) {
            return false;
        }
        return true;
    }

    //--相対距離を求める
    void distanceBetweenAvaAndMane() {
        distBetX = PlayerBehaviour.avaX - maneX;
        //distBetY = PlayerBehaviour.avaY - maneY;
        distBetZ = PlayerBehaviour.avaZ - maneZ;
    }
    //--相対距離が近いとtrue遠いとfalse
    bool distJudge(float x, float z) {
        if ( x  <= DIST && x >= -DIST ) {
            if ( z <= DIST && z >= -DIST ) {
                return true;
            }
        }
        return false;
    }

    //-------以下アバタとマネキンとのやり取り★マネキンの種類が増えた時★--------------------------------------------------------
    void behaviourBetweenAvaAndMane() {
        GameObject clothes;
        string clothesName;

        string wearingClothesName;
        GameObject wearingClothesObject;

        if (canWear && (Input.GetKeyDown(KeyCode.F) || Input.GetKey("joystick button 0"))) {
            //--今のアバタの服を隠し、マネキンの着ている服を表示する
            //このマネキンが着ている服のゲームオブジェクトの名前を取得
            clothes = returnClothes(this.transform.name);
            clothesName = clothes.transform.name;
            
            //--隠された服のリストの要素から取得した名前と一致するものを検索
            for ( int i = PlayerBehaviour.falseClothesList.Count - 1; i >= 0; i-- ) {
                //--眼鏡など、脱着できるものは別処理
                //眼鏡をかけてない状態から装着する
                if ( isClothes() == "megane" && PlayerBehaviour.meganeNow == null && PlayerBehaviour.falseClothesList[i].name == clothesName ) {
                    //--アバタが着ている該当するものを非表示から表示に
                    //Debug.Log("different1");
                    PlayerBehaviour.falseClothesList[i].SetActive(true);
                    PlayerBehaviour.meganeNow = PlayerBehaviour.falseClothesList[i].name;
                    //PlayerBehaviour.falseClothesList.RemoveAt(i);
                }
                //眼鏡をかけている状態からほかの眼鏡を装着する
                else if ( isClothes() == "megane" && PlayerBehaviour.meganeNow != null && PlayerBehaviour.falseClothesList[i].name == clothesName ) {
                    //--このマネキンのかけている眼鏡とアバタの眼鏡が同じとき
                    if ( clothesName == PlayerBehaviour.meganeNow ) {
                        //Debug.Log("same");
                        wearingClothesObject = seekChildObject(PlayerBehaviour.meganeNow);
                        //falseの管理リストに追加
                        PlayerBehaviour.falseClothesList.Add(wearingClothesObject);
                        wearingClothesObject.SetActive(false);
                        PlayerBehaviour.meganeNow = null;
                    } else { //異なるとき
                        //Debug.Log("different2");
                        PlayerBehaviour.falseClothesList[i].SetActive(true);
                        wearingClothesObject = seekChildObject(PlayerBehaviour.meganeNow);
                        //falseの管理リストに追加
                        PlayerBehaviour.falseClothesList.Add(wearingClothesObject);
                        wearingClothesObject.SetActive(false);
                        PlayerBehaviour.meganeNow = PlayerBehaviour.falseClothesList[i].name;
                        PlayerBehaviour.falseClothesList.RemoveAt(i);
                    }
                }

                //--被り物についても同様
                else if (isClothes() == "kaburimono" && PlayerBehaviour.kaburimonoNow == null && PlayerBehaviour.falseClothesList[i].name == clothesName) {
                    //--アバタが着ている該当するものを非表示から表示に
                    PlayerBehaviour.falseClothesList[i].SetActive(true);
                    PlayerBehaviour.kaburimonoNow = PlayerBehaviour.falseClothesList[i].name;
                    //PlayerBehaviour.falseClothesList.RemoveAt(i);
                }
                //眼鏡をかけている状態からほかの眼鏡を装着する
                else if (isClothes() == "kaburimono" && PlayerBehaviour.kaburimonoNow != null && PlayerBehaviour.falseClothesList[i].name == clothesName) {
                    //--このマネキンのかけている眼鏡とアバタの眼鏡が同じとき
                    if (clothesName == PlayerBehaviour.kaburimonoNow) {
                        wearingClothesObject = seekChildObject(PlayerBehaviour.kaburimonoNow);
                        //falseの管理リストに追加
                        PlayerBehaviour.falseClothesList.Add(wearingClothesObject);
                        wearingClothesObject.SetActive(false);
                        PlayerBehaviour.kaburimonoNow = null;
                    }
                    else { //異なるとき
                        PlayerBehaviour.falseClothesList[i].SetActive(true);
                        wearingClothesObject = seekChildObject(PlayerBehaviour.kaburimonoNow);
                        //falseの管理リストに追加
                        PlayerBehaviour.falseClothesList.Add(wearingClothesObject);
                        wearingClothesObject.SetActive(false);
                        PlayerBehaviour.kaburimonoNow = PlayerBehaviour.falseClothesList[i].name;
                        PlayerBehaviour.falseClothesList.RemoveAt(i);
                    }
                }


                //脱着が必要ないものは以下
                else if ( PlayerBehaviour.falseClothesList[i].name == clothesName ) {
                    //--アバタが着ている該当するものを非表示から表示に
                    PlayerBehaviour.falseClothesList[i].SetActive(true);

                    //--次にこのマネキンの名前から服かズボンか等を判断
                    wearingClothesName = isClothes();
                    //アバタが着ている部位にあったものをsetActiveをfalseに
                    if ( wearingClothesName == "huku" ) {
                        wearingClothesObject = seekChildObject(PlayerBehaviour.hukuNow);
                        //falseの管理リストに追加
                        PlayerBehaviour.falseClothesList.Add(wearingClothesObject);
                        wearingClothesObject.SetActive(false);
                        PlayerBehaviour.hukuNow = PlayerBehaviour.falseClothesList[i].name;
                    }
                    else if (wearingClothesName == "zubon") {
                        wearingClothesObject = seekChildObject(PlayerBehaviour.zubonNow);
                        //falseの管理リストに追加
                        PlayerBehaviour.falseClothesList.Add(wearingClothesObject);
                        wearingClothesObject.SetActive(false);
                        PlayerBehaviour.zubonNow = PlayerBehaviour.falseClothesList[i].name;
                    }
                    else if (wearingClothesName == "kami") {
                        wearingClothesObject = seekChildObject(PlayerBehaviour.kamiNow);
                        //falseの管理リストに追加
                        PlayerBehaviour.falseClothesList.Add(wearingClothesObject);
                        wearingClothesObject.SetActive(false);
                        PlayerBehaviour.kamiNow = PlayerBehaviour.falseClothesList[i].name;
                    }
                    //アクティブがtrueになるのでfalseのlistから削除
                    PlayerBehaviour.falseClothesList.RemoveAt(i);
                }
                
            }
            canWear = false; //複数回入力不可能にするためfasleに
        }
    }

    //--マネキンの着ている服を返り値とするメソッド★マネキンの種類が増えた時★
    GameObject returnClothes(string mn) {
        //--まずは服を着るマネキンかどうか識別
        
        if ( mn == "hukuManekin01_"+ AvatarInputToList.genderNow ) {
            
            return PrefabInputToList.pfHukuList[0];
        }
        else if ( mn == "hukuManekin02_" + AvatarInputToList.genderNow ) {
            
            return PrefabInputToList.pfHukuList[1];
        }
        else if ( mn == "hukuManekin03_" + AvatarInputToList.genderNow ) {
           
            return PrefabInputToList.pfHukuList[2];
        }

        //--続いてズボンを着るマネキンかどうか識別
        if ( mn == "zubonManekin01_" + AvatarInputToList.genderNow ) {
            return PrefabInputToList.pfZubonList[0];
        }
        else if ( mn == "zubonManekin02_" + AvatarInputToList.genderNow ) {
            return PrefabInputToList.pfZubonList[1];
        }

        //--髪を飾るマネキンかどうか
        if (mn == "kamiManekin01_" + AvatarInputToList.genderNow) {
            return PrefabInputToList.pfKamiList[0];
        }
        else if (mn == "kamiManekin02_" + AvatarInputToList.genderNow) {
            return PrefabInputToList.pfKamiList[1];
        }

        //--被り物を飾るマネキンかどうか
        if (mn == "kaburimonoManekin01_" + AvatarInputToList.genderNow) {
            return PrefabInputToList.pfKaburimonoList[0];
        }

        //--眼鏡を飾るマネキンかどうか
        if (mn == "meganeManekin01_" + AvatarInputToList.genderNow) {
            return PrefabInputToList.pfMeganeList[0];
        }

        //見つからなければnull

        return null;
    }
    //--マネキンの名前から服かズボンかなど判定★マネキンの種類が増えた時★
    string isClothes() {
        string thisManekinName = this.transform.name;
        string kinds;
        kinds = null;
        
        //あいまい検索を活用
        if ( Regex.IsMatch(thisManekinName, "^hukuManekin.*$", RegexOptions.Singleline) ) {
            kinds = "huku";
        }
        else if ( Regex.IsMatch(thisManekinName, "^zubonManekin.*$", RegexOptions.Singleline) ) {
            kinds = "zubon";
        }
        else if (Regex.IsMatch(thisManekinName, "^kamiManekin.*$", RegexOptions.Singleline)) {
            kinds = "kami";
        }
        else if (Regex.IsMatch(thisManekinName, "^kaburimonoManekin.*$", RegexOptions.Singleline)) {
            kinds = "kaburimono";
        }
        else if (Regex.IsMatch(thisManekinName, "^meganeManekin.*$", RegexOptions.Singleline)) {
            kinds = "megane";
        }
        return kinds;
    }

    //--このマネキンが男女どちらの性格か判定
    string isManekinGender() {
        string isManekinGender = null;
        //あいまい検索を活用
        if (Regex.IsMatch(this.transform.name, "^.*_man$", RegexOptions.Singleline)) {
            isManekinGender = "manMane";
        }
        else if (Regex.IsMatch(this.transform.name, "^.*_woman$", RegexOptions.Singleline)) {
            isManekinGender = "womanMane";
        }
        return isManekinGender;
    }

    //--子を探すメソッド
    GameObject seekChildObject(string wearingNow) {
        var avaTransform = AvatarInputToList.avatarNow.GetComponentsInChildren<Transform>();
        foreach (Transform child00 in avaTransform) {
 
            if (child00.gameObject.name == wearingNow) {
                return child00.gameObject;
            }
        }
        return null;
    }

}
