﻿using UnityEngine;
using System.Collections;

public class OnStart : MonoBehaviour {

     public GameObject PointStar;
     public ScoreData scoreData;
     public GameObject Rocket;
     private float MaxHight;

	// Use this for initialization
	void Start () {
          QualitySettings.vSyncCount = 0; // VSyncをOFFにする
          Application.targetFrameRate = 60; // ターゲットフレームレートを60に設定

          MaxHight = scoreData.GetMaxDistance();
          StartCoroutine("ScatterStar");          

     }

     // Update is called once per frame
     void Update () {
          	
	}

     private IEnumerator ScatterStar () // 星をばらまく
     {
          
          yield return new WaitForSeconds(1.0f);
          for (int i = 0; i < 20; i++)
          {               
               Vector3 placePosition = new Vector3(Random.Range(-MaxHight / 7, MaxHight / 7), Random.Range(5.0f, MaxHight * 1.2f), 0);
               Quaternion q = new Quaternion();
               q = Quaternion.identity;
               GameObject Star_temp = (GameObject)Instantiate(PointStar, placePosition,q);
                          
               Star_temp.GetComponent<StarController>().scoreData = scoreData.GetComponent<ScoreData>();
               Star_temp.GetComponent<StarController>().Rocket = Rocket.GetComponent<RocketController>();
              yield return null;

          }
     }
}
