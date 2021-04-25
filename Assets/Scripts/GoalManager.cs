﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;
 
public class GoalManager : MonoBehaviour
{
    //ユニティちゃんを格納するための変数
    public GameObject player;
    //テキストを格納するための変数
    public GameObject text;
 
    //Goalしたかどうか判定する
    private bool isGoal = false;

    //RestartManager型
    private RestartManager restart;

    //ゴールした後に的を停止するため
    public GameObject enemy;
    
    // Start is called before the first frame update
    void Start()
    {
         //インスタンス生成
        restart = new RestartManager(player, text);
    }
 
    // Update is called once per frame
    void Update()
    {
        //Goal処理
        if(isGoal)
        {
            //敵を停止する
            enemy.SetActive(false);
            enemy.GetComponent<EnemyController>().enabled = false;
//            enemy.GetComponent<EnemyHitController>().enabled = false;

            //Goalした後で画面をクリックされたとき
//          if(isGoal && Input.GetMouseButton(0))
            if(Input.GetMouseButton(0))
            {
//            Restart();
                restart.Restart();
            }
        }
    }

    //当たり判定関数
    private void OnTriggerEnter(Collider other)
    {
        //当たってきたオブジェクトの名前がユニティちゃんの名前と同じとき
        if(other.name == player.name)
        {
            //一旦ログに出力
//            Debug.Log("ユニティちゃんと接触しました！");
            //テキストの内容を変更する
//            text.GetComponent<Text>().text = "Goal!!!";
            text.GetComponent<Text>().text = "Goal!!!\n画面クリックで再スタート";
            //テキストをオンにして非表示→表示にする
            text.SetActive(true);

            //Goal判定をTrueにする
            isGoal = true;
        }
    }
 /*
    //シーンを再読み込みする
    private void Restart()
    {
        // 現在のScene名を取得する
        Scene loadScene = SceneManager.GetActiveScene();
        // Sceneの読み直し
        SceneManager.LoadScene(loadScene.name);
    }
*/
}
