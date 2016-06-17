using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpecNodeMaker : MonoBehaviour {

     [SerializeField]
     RectTransform prefab = null;

     public SpecData specData;
     public ScoreData scoreData;
     
     // Use this for initialization
     void Start () {



          specData = GameObject.Find("SpecData").GetComponent<SpecData>();
          scoreData = GameObject.Find("ScoreData").GetComponent<ScoreData>();
          specData.PumpPressure = specData.GetInnerPressureMax();
          specData.Recalculation();

          ItemMaker("現在のスコア", scoreData.GetTotalScore(), 0, "Pts");                               // 今までのトータルスコア
          ItemMaker("打ち上げ回数", scoreData.GetLaunchNumber(), 0, "回");             // 打ち上げ回数
          ItemMaker("最高高度", scoreData.GetMaxDistance(), 0, "m");                     //今までの最高高度


          


          ItemMaker("機体重量", specData.GetRocketWeight() , 2, "kg");              // kg　ロケットの質量
          ItemMaker("燃料重量", specData.GetMass(), 2, "kg");                            // kg　水の質量
          ItemMaker("ノズル径", specData.GetNozzleRadius() * 1000, 1, "mm");        // m　ノズル直径
          ItemMaker("ロケット段数", specData.GetMultistage(), 0, "段");                      //　ロケットの段数
          ItemMaker("ボディの耐圧", specData.GetInnerPressureMax(), 0, "kPa");        // kPa　ボディの耐圧
          ItemMaker("噴射速度", specData.GetNozzleFlowRate(), 1, "m/s");             // m/s 　ノズル通過時の流速
          ItemMaker("本体推力", specData.GetThrustForce(), 1, "N");                      //  N　上昇力
          ItemMaker("噴射時間", specData.GetBurningTime(), 2, "Sec");               // Sec　燃焼時間
          ItemMaker("CD値", specData.GetCd(), 2, "");                                      // CD
          ItemMaker("ポンプ最大圧力", specData.GetPumpMax(), 0, "kPa");               // kPa　ポンプの最大圧
          if (specData.GetSideThrusterForce() > 0.0f)
          {
               ItemMaker("サイドスラスタ推力", specData.GetSideThrusterForce(), 1, "N");      // N 横向きの力
               ItemMaker("サイドスラスタ噴射時間", specData.GetSideThrusterTime(), 1, "Sec");       // Sec スラスタ噴射時間
          }
          if (specData.GetLauncherForce() > 0.0f)
          {
               ItemMaker("発射台追加推力", specData.GetLauncherForce(), 1, "N");            // ランチャーの追加の推力
          }
          if (specData.GetSRBANumber() > 0 )
          {
               ItemMaker("固体補助ブースター", specData.GetSRBANumber(), 0, "本");         //　固体燃料ロケットの本数
               ItemMaker("ブースター推力", specData.GetSRBAThrustForce(), 1, "N/本");        // N　固体燃料ロケットの一本あたりの推力
               ItemMaker("ブースター燃焼時間", specData.GetSRBABurningTime(), 1, "Sec");      // Sec　固体燃料ロケットの燃焼時間
          }
          if (specData.GetPayLoadName() != null)
          {
               ItemMakerNoNumber("ペイロード",  specData.GetPayLoadName());                   // ペイロードの種類
               ItemMaker("ペイロード重量", specData.GetPayLoadWeight(), 1, "kg");           //　ペイロードの質量   
          }
          



     }
	
	// Update is called once per frame
	void Update () {
	
	}

     void ItemMaker(string ItemName, float Number, int digits, string Unit) 
     {
          var item = GameObject.Instantiate(prefab) as RectTransform;
          item.SetParent(transform, false);
          item.name = ItemName;
          item.FindChild("Heading").GetComponent<Text>().text = ItemName;
          item.FindChild("Number").GetComponent<Text>().text = Number.ToString("N"+digits) + " " + Unit;

     }

     void ItemMakerNoNumber(string ItemName, string ItemDiscription)
     {
          var item = GameObject.Instantiate(prefab) as RectTransform;
          item.SetParent(transform, false);
          item.name = ItemName;
          item.FindChild("Heading").GetComponent<Text>().text = ItemName;
          item.FindChild("Number").GetComponent<Text>().text = ItemDiscription;

     }
}
