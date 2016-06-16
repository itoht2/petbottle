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

          ItemMaker("機体重量", specData.GetRocketWeight() , 2, "kg");              // kg　ロケットの質量
          ItemMaker("燃料重量", specData.GetMass(), 2, "kg");                            // kg　水の質量
          ItemMaker("ノズル径", specData.GetNozzleRadius() * 1000, 1, "mm");        // m　ノズル直径
          ItemMaker("ロケット段数", specData.GetMultistage(), 0, "段");                      //　ロケットの段数
          ItemMaker("ボディの耐圧", specData.GetInnerPressureMax(), 0, "kPa");        // kPa　ボディの耐圧

          specData.PumpPressure = specData.GetInnerPressureMax();

          ItemMaker("噴射速度", specData.GetNozzleFlowRate(), 1, "m/s");             // m/s 　ノズル通過時の流速
          ItemMaker("本体推力", specData.GetThrustForce(), 1, "N");                      //  N　上昇力
          ItemMaker("噴射時間", specData.GetBurningTime(), 2, "Sec");               // Sec　燃焼時間



          //public float Temperature;                         // Deg　外気温
          //public float GasConstant;                         //　気体定数
          //public float Cd;                                    //　ボディの空気抵抗係数　
          //public float NoseCornCD;                   //　ノーズコーンの空気抵抗係数
          //public Sprite NoseCornImage;            // ノーズコーンの画像
          //public float FinCD;                             //　フィンの空気抵抗係数
          //public float CDFactor;                     //　空気抵抗係数補正値
          //public float DensityOfAir;                             //  kg/m^3　空気の密度     

          //public float PumpMax;                        // kPa　ポンプの最大圧
          //public float PumpCapacity;              // kPa　一回のポンピングでの圧力上昇分
          //public float PumpPressure;                  // kPa　ポンプ圧

          //public float SideThrusterForce;              // N 横向きの力
          //public float SideThrusterTime;               // Sec スラスタ噴射時間
          //public float SideThrusterRate;                   // スラスタの残りの噴射時間の割合

          //public float LauncherForce;                  // ランチャーの追加の推力

          //public int SRBANumber;                      //　固体燃料ロケットの本数
          //public float SRBAThrustForce;           // N　固体燃料ロケットの一本あたりの推力
          //public float SRBABurningTime;           // Sec　固体燃料ロケットの燃焼時間

          //public float SRBApositionFactor;        //　SRBA位置合わせ用係数
          //public Vector3 SRBAOffset;                   // SRBA位置調整

          //public string PayLoadName;              // ペイロードの種類
          //public float PayLoadWeight;             //　ペイロードの質量   





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
          item.FindChild("Number").GetComponent<Text>().text = Number.ToString("N"+digits) + Unit;

     }
}
