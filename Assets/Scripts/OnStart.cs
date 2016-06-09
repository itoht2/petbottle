using UnityEngine;
using System.Collections;
using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class OnStart : MonoBehaviour {

     public GameObject PointStar;
     public ScoreData scoreData;
     public GameObject Rocket;
     private float MaxHight;
     public GameObject StarFolder;
     public GameObject noseCorn;
     public SpecData specData;


     // Use this for initialization
     void Start () {
          //QualitySettings.vSyncCount = 0; // VSyncをOFFにする
          //Application.targetFrameRate = 60; // ターゲットフレームレートを60に設定

          //GameObject IsSpecData = GameObject.Find("SpecData");
          scoreData = GameObject.Find("ScoreData").GetComponent<ScoreData>();

          //if (IsSpecData == null) { 
          ////Debug.Log(IsSpecData.name);
          //      GameObject SpecDataprefab = (GameObject)Resources.Load("Prefabs/SpecData");
          //     IsSpecData = Instantiate(SpecDataprefab);
          //     IsSpecData.name = "SpecData";
          //     DontDestroyOnLoad(IsSpecData);

          //}

          specData = GameObject.Find("SpecData").GetComponent<SpecData>();

         

          if  (scoreData.GetMaxDistance() >=50.0f) { 
               MaxHight = scoreData.GetMaxDistance();
          } else
          {
               MaxHight = 50.0f;
          }
          StartCoroutine("ScatterStar");

          ImageChanger();
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

               Star_temp.transform.parent = StarFolder.transform;
               Star_temp.name = "Star" + i;

               
               yield return null;

          }
     }

     public void ImageChanger()         // 表示する画像を変更する。
     {
          // noseCornの画像変更
          Sprite tempImage = NoseCornFolder.GetNowUsedImage();          
               noseCorn.GetComponent<SpriteRenderer>().sprite = tempImage;         
     }

     public void OnApplicationQuit()
     {
          PlayerPrefs.Flush();
     }
}
