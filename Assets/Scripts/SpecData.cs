using UnityEngine;
using System.Collections;
using PlayerPrefs = PreviewLabs.PlayerPrefs;
using UnityEngine.UI;

public class SpecData : MonoBehaviour {
    

     public float Gravity ;                  // m/s^2　重力
     public float WaterDensity;        // kg/m^3　水の密度
     public float RocketWeight ;            // kg　ロケットの質量
     public float NoseCornWeight ;         // kg　ノーズコーンの質量
     public float FinWeight ;                   // kg　フィンの質量
     public float FuelCapacity ;          // m^3　水の量
     public float FuelWeight ;                        // kg　水の質量
     public float AverageWeight;                     // kg　平均質量
     public float NozzleRadius ;          // m　ノズル直径
     public float NozzleArea;                         // m^2　ノズル面積　
     public int Multistage;                            //　ロケットの段数

     public float InnerPressureMax ;             // kPa　ボディの耐圧
     public float Speed;                               // 現在のスピード
     public float Altitude;                            // 現在の高度
     public float SpeedMax;                       //  最高速度

     public float AtmospherPresuure  ; // kPa　大気圧

     public float NozzleFlowRate;                // m/s 　ノズル通過時の流速
     public float BodyRadius ;                   // m　ボディ直径
     public float ProjectedArea;                      // m^2　ボディ投影面積
     public float InitialVelocity;                          // m^2　初速

     public float Thrust;                                  //  N　上昇力

     public float BurningTime;                         // Sec　燃焼時間

     public float Temperature ;                         // Deg　外気温
     public float GasConstant ;                         //　気体定数
     public float Cd  ;                                    //　ボディの空気抵抗係数　
     public float NoseCornCD ;                   //　ノーズコーンの空気抵抗係数
     public Sprite NoseCornImage;            // ノーズコーンの画像
     public float FinCD ;                             //　フィンの空気抵抗係数

     public float Stability;                           // 安定性　小さいほど安定する

     public float CDFactor ;                     //　空気抵抗係数補正値
     public float DensityOfAir;                             //  kg/m^3　空気の密度     

     public float PumpMax;                        // kPa　ポンプの最大圧
     public float PumpCapacity;              // kPa　一回のポンピングでの圧力上昇分
     public float PumpPressure;                  // kPa　ポンプ圧

     public float SideThrusterForce;              // N 横向きの力
     public float SideThrusterTime;               // Sec スラスタ噴射時間
     public float SideThrusterRate;                   // スラスタの残りの噴射時間の割合

     public float LauncherForce;                  // ランチャーの追加の推力

     public int SRBANumber;                      //　固体燃料ロケットの本数
     public float SRBAThrustForce;           // N　固体燃料ロケットの一本あたりの推力
     public float SRBABurningTime;           // Sec　固体燃料ロケットの燃焼時間

     public float SRBApositionFactor;        //　SRBA位置合わせ用係数
     public Vector3 SRBAOffset;                   // SRBA位置調整

     public string PayLoadName;              // ペイロードの種類
     public float PayLoadWeight;             //　ペイロードの質量   

     // Use this for initialization

     void Awake() {
          LoadData();
          Recalculation();
     }

     void Start()
     {
          //Recalculation();       
     }

     // Update is called once per frame
     void Update () {         

     }

     public void LoadData()
     {
          Gravity = PlayerPrefs.GetFloat("Gravity", 9.807f);
          WaterDensity = PlayerPrefs.GetFloat("WaterDensity", 1000.0f);
          RocketWeight = PlayerPrefs.GetFloat("RocketWeight", 0.02f);
          NoseCornWeight = PlayerPrefs.GetFloat("NoseCornWeight", 0.01f);
          FinWeight = PlayerPrefs.GetFloat("FinWeight", 0.03f);
          FuelCapacity = PlayerPrefs.GetFloat("FuelCapacity", 0.0002f);
          NozzleRadius = PlayerPrefs.GetFloat("NozzleRadius", 0.003f);
          InnerPressureMax = PlayerPrefs.GetFloat("InnerPressureMax", 300f);
          AtmospherPresuure = PlayerPrefs.GetFloat("AtmospherPresuure", 101.3f);
          BodyRadius = PlayerPrefs.GetFloat("BodyRadius", 0.05f);
          Temperature = PlayerPrefs.GetFloat("Temperature", 20.0f);
          GasConstant = PlayerPrefs.GetFloat("GasConstant", 2.87f);
          Cd = PlayerPrefs.GetFloat("Cd", 0.6f);
          NoseCornCD = PlayerPrefs.GetFloat("NoseCornCD", 0.2f);
          FinCD = PlayerPrefs.GetFloat("FinCD", 0.2f);
          CDFactor = PlayerPrefs.GetFloat("CDFacto", 1.0f);
          Stability = PlayerPrefs.GetFloat("Stability", 1.0f);

          PumpMax = PlayerPrefs.GetFloat("PumpMax", 300f);
          PumpCapacity = PlayerPrefs.GetFloat("PumpCapacity", 2f);          
          SideThrusterForce = PlayerPrefs.GetFloat("SideThrusterForce",1f);
          SideThrusterTime = PlayerPrefs.GetFloat("SideThrusterTime",5.0f);
          LauncherForce = PlayerPrefs.GetFloat("LauncherForce", 0f);
          SRBANumber = PlayerPrefs.GetInt("SRBANumber", 0);
          SRBAThrustForce = PlayerPrefs.GetFloat("SRBAThrustForce", 0.0f);
          SRBABurningTime = PlayerPrefs.GetFloat("SRBABurningTime", 0.0f);
          PayLoadName = PlayerPrefs.GetString("PayLoadName", "Cansat");
          PayLoadWeight = PlayerPrefs.GetFloat("PayLoadWeight", 0.1f);
    


}

     public void SaveData ()
     {
          PlayerPrefs.SetFloat("Gravity", Gravity);
          PlayerPrefs.SetFloat("WaterDensity", WaterDensity);
          PlayerPrefs.SetFloat("RocketWeight", RocketWeight);
          PlayerPrefs.SetFloat("NoseCornWeight", NoseCornWeight);
          PlayerPrefs.SetFloat("FinWeight", FinWeight);
          PlayerPrefs.SetFloat("FuelCapacity", FuelCapacity);
          PlayerPrefs.SetFloat("NozzleRadius", NozzleRadius);
          PlayerPrefs.SetFloat("InnerPressureMax", InnerPressureMax);
          PlayerPrefs.SetFloat("AtmospherPresuure", AtmospherPresuure);
          PlayerPrefs.SetFloat("BodyRadius", BodyRadius);
          PlayerPrefs.SetFloat("Temperature", Temperature);
          PlayerPrefs.SetFloat("GasConstant", GasConstant);
          PlayerPrefs.SetFloat("Cd", Cd);
          PlayerPrefs.SetFloat("NoseCornCD", NoseCornCD);
          PlayerPrefs.SetFloat("FinCD", FinCD);
          PlayerPrefs.SetFloat("CDFacto", CDFactor);
          PlayerPrefs.SetFloat("Stability", Stability);


          PlayerPrefs.SetFloat("PumpMax", PumpMax);
          PlayerPrefs.SetFloat("PumpCapacity", PumpCapacity);
          PlayerPrefs.SetFloat("SideThrusterForce", SideThrusterForce);
          PlayerPrefs.SetFloat("SideThrusterTime", SideThrusterTime);
          PlayerPrefs.SetFloat("LauncherForce", LauncherForce);
          PlayerPrefs.SetInt("SRBANumber", SRBANumber);
          PlayerPrefs.SetFloat("SRBAThrustForce", SRBAThrustForce);
          PlayerPrefs.SetFloat("SRBABurningTime", SRBABurningTime);
          PlayerPrefs.SetString("PayLoadName", PayLoadName);
          PlayerPrefs.SetFloat("PayLoadWeight", PayLoadWeight);

          PlayerPrefs.Flush();
     }
     
     public void Recalculation ()
     {
          FuelWeight = FuelCapacity * WaterDensity;
          AverageWeight = FuelWeight / 2 + RocketWeight + NoseCornWeight + FinWeight ;
          NozzleArea = NozzleRadius * NozzleRadius * Mathf.PI;
          ProjectedArea = BodyRadius * BodyRadius * Mathf.PI;
          NozzleFlowRate = Mathf.Sqrt(2 * (PumpPressure - AtmospherPresuure) / WaterDensity * 1000);
          Thrust = WaterDensity * NozzleArea * NozzleFlowRate * NozzleFlowRate;
          BurningTime = FuelCapacity / (NozzleArea * NozzleFlowRate);
          DensityOfAir = AtmospherPresuure * 10 / (GasConstant * (Temperature + 273.15f));

          PlayerPrefs.Flush();

     }

     public int GetMultistage ()
     {
          return Multistage;
     }

     public float GetRocketWeight ()
     {
          return RocketWeight;
     }

     public float GetThrustForce ()
     {
          return Thrust;
         
     }

     public float GetBurningTime ()
     {
          return BurningTime;
     }

     public float GetMass()
     {
          return AverageWeight;

     }

     public float GetGravity ()
     {
          return Gravity;
     }   

     public float GetPumpMax()
     {
          return PumpMax;
     }
    
     public float GetNozzleRadius ()
     {
          return NozzleRadius;
     }

     public float GetPumpCapacity()
     {
          return PumpCapacity;
     }

     public float GetPumpPressure()
     {
          return PumpPressure;
     }

     public float GetInitialVelocity()
     {
          return InitialVelocity;
     }

     public int GetSRBANumber()
     {
          return SRBANumber;
     }

     public float GetSRBAThrustForce()
     {
          return SRBAThrustForce;
     }

     public float GetSRBABurningTime()
     {
          return SRBABurningTime;
     }

     public float GetSRBApositionFactor()
     {
          return SRBApositionFactor;
     }

     public Vector3 GetSRBAOffset()
     {
          return SRBAOffset;
     }

     public float GetSideThrusterForce()
     {
          return SideThrusterForce;
     }

     public float GetSideThrusterTime()
     {
          return SideThrusterTime;
     }

     public float GetSideThrustRate()
     {
          return SideThrusterRate;
     }

     public string GetPayLoadName ()
     {
          return PayLoadName;
     }

     public float GetPayLoadWeight()
     {
          return PayLoadWeight;
     }

     public float GetSpeedMax()
     {
          return SpeedMax;
     }


     public float GetInnerPressureMax()
     {
          return InnerPressureMax;
     }

     public float GetLauncherForce() {
          return LauncherForce;
     }
     public float GetCd()
     {
          return Cd;
     }
     public Sprite GetNoseCornImage()
     {
          return NoseCornImage;
     }
     public float GetNoseCornCD()
     {
          return NoseCornCD;
     }
     public float GetFinCD()
     {
          return FinCD;
     }
     public float GetCDFactor()
     {
          return CDFactor;
     }

     public float GetStability()
     {
          return Stability;
     }

     public float GetDensityOfAir()
     {
          return DensityOfAir;
     }
     public float GetProjectedAera()
     {
          return ProjectedArea;
     }

     public float GetSpeed()
     {
          return Speed;
     }

     public float GetAltitude()
     {
          return Altitude;
     }

     public float GetNozzleFlowRate()
     {
          return NozzleFlowRate;
     }

     public float GetTemperature()
     {
          return Temperature;
     }

     public float GetGasConstant()
     {
          return GasConstant;
     }

     public float GetAtmospherPresuure()
     {
          return AtmospherPresuure;
     }

     public void OnApplicationQuit()
     {
          PlayerPrefs.Flush();
     }

     void OnDestroy()
     {
          PlayerPrefs.Flush();
     }

}


