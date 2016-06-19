﻿using UnityEngine;
using System.Collections;
using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class OnStart : MonoBehaviour {

     public GameObject PointStar;
     public ScoreData scoreData;
     public GameObject Rocket;

     public GameObject StarFolder;
     public GameObject noseCorn;
     public SpecData specData;
     private float HightRenge;


     // Use this for initialization
     void Start () {
          QualitySettings.vSyncCount = 0; // VSyncをOFFにする
          Application.targetFrameRate = 60; // ターゲットフレームレートを60に設定

          Time.timeScale = 1.0f;

          //GameObject IsSpecData = GameObject.Find("SpecData");
          scoreData = GameObject.Find("ScoreData").GetComponent<ScoreData>();
          scoreData.Score = 0.0f;
          scoreData.ScoreNow = 0.0f;
          specData = GameObject.Find("SpecData").GetComponent<SpecData>();
          specData.PumpPressure = 0.0f;

          HightRenge = 25.0f;

          StartCoroutine(ScatterStar(HightRenge));
          ImageChanger();
                   
     }

     // Update is called once per frame
     void Update () {
          if (specData.GetAltitude() > HightRenge)
          {
               StartCoroutine(ScatterStar(HightRenge ));
               HightRenge = HightRenge * 2;
          }


     }

     private IEnumerator ScatterStar (float HightLevel) // 星をばらまく
     {
          
          yield return new WaitForSeconds(1.0f);
          for (int i = 0; i < 10; i++)
          {               
               Vector3 placePosition = new Vector3(Random.Range(-HightLevel *2 , HightLevel *2), Random.Range(HightLevel * 0.75f  , HightLevel * 2.5f), 0);
               Quaternion q = new Quaternion();
               q = Quaternion.identity;
               GameObject Star_temp = (GameObject)Instantiate(PointStar, placePosition,q);
                          
               Star_temp.GetComponent<StarController>().scoreData = scoreData.GetComponent<ScoreData>();
               Star_temp.GetComponent<StarController>().Rocket = Rocket.GetComponent<RocketController>();

               Star_temp.transform.parent = StarFolder.transform;
               Star_temp.name = "Star" + i;
               
               yield return null;

          }
     }

     public void ImageChanger()         // 表示する画像を変更する。
     {
          NoseCornFolder noseCornFolder = GameObject.Find("NoseCornFolder").GetComponent<NoseCornFolder>();
          noseCorn.GetComponent<SpriteRenderer>().sprite = noseCornFolder.GetImage(noseCornFolder.GetNowUsed());
          //Debug.Log(noseCornFolder.GetImage(noseCornFolder.GetNowUsed()));
     }

     public void OnApplicationQuit()
     {
          PlayerPrefs.Flush();
     }
}
