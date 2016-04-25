using UnityEngine;
using System.Collections;

public class SpecData : MonoBehaviour {

     public Rigidbody2D Rocket;

     public float Gravity = 9.807f;                  // m/s^2
     public float WaterDensity = 1000.0f;        // kg/m^3
     public float RocketWeight = 0.1f;            // kg
     public float FuelCapacity = 0.0002f;          // m^3
     public float FuelWeight ;                        // kg
     public float AverageWeight;                     // kg
     public float NozzleRadius = 0.003f;          // m
     public float NozzleArea;                         // m^2
     public int Multistage;                            //

     public float InnerPressureMax = 303f;             // kPa

     public float AtmospherPresuure = 101.3f; // kPa

     public float NozzleFlowRate;                // m/s 
     public float BodyRadius = 0.05f;                   // m
     public float ProjectedArea;                      // m^2
     public float InitialVelocity;                          // m^2

     public float Thrust;                                  //  N

     public float BurningTime;                         // Sec

     public float Temperature = 20.0f;                         // Deg
     public float GasConstant = 2.87f;                         //
     public float Cd = 1.0f;           //
     public float DensityOfAir;                             //  kg/m^3
     public float AirResistancce;                     // N

     public float PumpMax;                        // kPa
     public float PumpCapacity;              // kPa
     public float PumpPressure;                  // kPa

     public float SideThrusterForce;              // N 横向きの力
     public float SideThrusterTime;               // Sec スラスタ噴射時間
     public float SideThrusterRate;                   // スラスタの残りの噴射時間の割合

     public float LauncherForce;                  // ランチャーの追加の推力

     public int SRBANumber;                      //
     public float SRBAThrustForce;           // N
     public float SRBABurningTime;           // Sec


     public float SRBApositionFactor;        //
     public Vector3 SRBAOffset;                   // SRBA位置調整

     public string PayLoadName;              // ペイロードの種類

     // Use this for initialization
     void Awake() {

          Recalculation();
          StartCoroutine(FuncCoroutine());
     }
	
	// Update is called once per frame
	void Update () {
          //AirResistancce = Cd * DensityOfAir * ProjectedArea * Rocket.velocity.y * Rocket.velocity.y / 2;
          //Rocket.AddForce(-AirResistancce * Rocket.velocity / 10 );
     }

     IEnumerator FuncCoroutine()
     {
          while (true)
          {             
               AirResistancce = Cd * DensityOfAir * ProjectedArea * Rocket.velocity.y * Rocket.velocity.y / 2;
               Rocket.AddForce(-AirResistancce * Rocket.velocity / 10);

               yield return new WaitForSeconds(0.2f);
          }
     }


     public void Recalculation ()
     {
          FuelWeight = FuelCapacity * WaterDensity;
          AverageWeight = FuelWeight / 2 + RocketWeight;
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


