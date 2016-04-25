using UnityEngine;
using System.Collections;

public class AirResistance : MonoBehaviour {

     public float coefficient;   // 空気抵抗係数
     public Rigidbody2D Rocket;
     public SpecData specData;
    
     // Use this for initialization
     void Start () {
          
     }
	


	// Update is called once per frame
	void Update () {
	
	}


     void FixedUpdate()
     {
          // 空気抵抗を与える

          coefficient = specData.GetAirResistancce() / 100;
          Rocket.AddForce(-coefficient * Rocket.velocity);
         
     }
}
