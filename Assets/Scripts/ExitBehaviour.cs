using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExitBehaviour : MonoBehaviour {
    private float distBetX;
    private float distBetZ;
    private float exitPosX;
    private float exitPosZ;

    //--相対距離の判定用変数
    private float DIST = 0.85f;
    // Use this for initialization
    void Start() {
        exitPosX = this.transform.position.x;
        exitPosZ = this.transform.position.z;
    }

    // Update is called once per frame
    void Update() {
        distanceBetweenAvaAndExit();
        if (distJudge(distBetX, distBetZ) && Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("exit");
            /*
            //利用準備
            this.gameObject.AddComponent<SaveAndLoadPrefab>(); //記入したScriptがComponentとして登録されているGameObjectにNKPrefabManを追加(手動でも可)
            SaveAndLoadPrefab prefabMan = GetComponent<SaveAndLoadPrefab>();
            //保存
            GameObject saveobj = AvatarInputToList.avatarNow;
            prefabMan.savePrefab(saveobj, System.DateTime.Now.ToString("yyyyMMddHHmmss"));
            */
            Application.Quit();
        }
    }
    void OnTriggerEnter(Collider collider) {
   
    }
    //--相対距離を求める
    void distanceBetweenAvaAndExit() {
        distBetX = PlayerBehaviour.avaX - exitPosX;
        distBetZ = PlayerBehaviour.avaZ - exitPosZ;
    }
    //--相対距離が近いとtrue遠いとfalse
    bool distJudge(float x, float z) {
        if (x <= DIST && x >= -DIST) {
            if (z <= DIST && z >= -DIST) {
                return true;
            }
        }
        return false;
    }
}
