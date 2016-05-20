using UnityEngine;
using System.Collections;

public class SpecData : MonoBehaviour {

     public Rigidbody2D Rocket;

     public float Gravity = 9.807f;                  // m/s^2　重力
     public float WaterDensity = 1000.0f;        // kg/m^3　水の密度
     public float RocketWeight = 0.07f;            // kg　ロケットの質量
     public float NoseCornWeight = 0.02f;         // kg　ノーズコーンの質量
     public float FinWeight = 0.01f;                   // kg　フィンの質量
     public float FuelCapacity = 0.0002f;          // m^3　水の量
     public float FuelWeight ;                        // kg　水の質量
     public float AverageWeight;                     // kg　平均質量
     public float NozzleRadius = 0.003f;          // m　ノズル直径
     public float NozzleArea;                         // m^2　ノズル面積　
     public int Multistage;                            //　ロケットの段数

     public float InnerPressureMax = 303f;             // kPa　ボディの耐圧

     public float AtmospherPresuure = 101.3f; // kPa　大気圧

     public float NozzleFlowRate;                // m/s 　ノズル通過時の流速
     public float BodyRadius = 0.05f;                   // m　ボディ直径
     public float ProjectedArea;                      // m^2　ボディ投影面積
     public float InitialVelocity;                          // m^2　初速

     public float Thrust;                                  //  N　上昇力

     public float BurningTime;                         // Sec　燃焼時間

     public float Temperature = 20.0f;                         // Deg　外気温
     public float GasConstant = 2.87f;                         //　気体定数
     public float Cd = 0.6f;                                    //　ボディの空気抵抗係数　
     public float NoseCornCD = 0.2f;                   //　ノーズコーンの空気抵抗係数
     public float FinCD = 0.2f;                             //　フィンの空気抵抗係数
     public float CDFactor = 1.0f;                     //　空気抵抗係数補正値
     public float DensityOfAir;                             //  kg/m^3　空気の密度
     public float AirResistancce;                     // N　空気抵抗

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

          Recalculation();
          StartCoroutine(FuncCoroutine());
     }
	
	// Update is called once per frame
	void Update () {
         
     }

     IEnumerator FuncCoroutine()
     {
          while (Rocket != null)
          {             
               AirResistancce = (Cd + NoseCornCD + FinCD) * CDFactor * DensityOfAir * ProjectedArea * Rocket.velocity.y * Rocket.velocity.y / 2;
               Rocket.AddForce(-AirResistancce * Rocket.velocity / 10);

               yield return new WaitForSeconds(0.5f);
          }
     }


     public void Recalculation ()
     {
          FuelWeight = FuelCapacity * WaterDensity;
          AverageWeight = FuelWeight / 2 + RocketWeight + NoseCornWeight + FinWeight ;
          NozzleArea = NozzleRadius * NozzleRadius * Mathf.PI;
          ProjectedArea = BodyRadius * BodyRadius * Mathf.PI;
          NozzleFlowRate = Mathf.Sqrt(2 * (PumpPressure ) / WaterDensity * 1000);
          Thrust = WaterDensity * NozzleArea * NozzleFlowRate * NozzleFlowRate;
          BurningTime = FuelCapacity / (NozzleArea * NozzleFlowRate);
          DensityOfAir = AtmospherPresuure * 10 / (GasConstant * (Temperature + 273.15f));
          
     }

     public int GetMultistage ()
     {
          return Multistage;
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

     public float GetAirResistancce()
     {
          return AirResistancce;
     }

     public float GetPumpMax()
     {
          return PumpMax;
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

     public float GetInnerPressureMax()
     {
          return InnerPressureMax;
     }

     public float GetLauncherForce() {
          return LauncherForce;
     }
}


