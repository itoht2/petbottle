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
          
          ItemMaker("機体重量", specData.GetRocketWeight() , 2, "kg");              // kg　ロケットの質量
          ItemMaker("燃料重量", specData.GetMass(), 2, "kg");                            // kg　水の質量
          ItemMaker("ノズル径", specData.GetNozzleRadius() * 1000, 1, "mm");        // m　ノズル直径
     //public float NozzleArea;                         // m^2　ノズル面積　
     //public int Multistage;                            //　ロケットの段数

          //public float InnerPressureMax;             // kPa　ボディの耐圧
          //public float Speed;                               // 現在のスピード
          //public float Altitude;                            // 現在の高度

          //public float AtmospherPresuure; // kPa　大気圧

          //public float NozzleFlowRate;                // m/s 　ノズル通過時の流速
          //public float BodyRadius;                   // m　ボディ直径
          //public float ProjectedArea;                      // m^2　ボディ投影面積
          //public float InitialVelocity;                          // m^2　初速

          //public float Thrust;                                  //  N　上昇力

          //public float BurningTime;                         // Sec　燃焼時間

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
