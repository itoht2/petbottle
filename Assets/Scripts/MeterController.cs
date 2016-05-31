using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MeterController : MonoBehaviour {
     public GameObject needle;
     public GameObject pressureNumber;
     public SpecData specData;
     //public TextMesh tm;
     public Text PressureText;

     static  float StartRotation = 110.0f;
     static float StopRotetion = -203.0f;
     public float needleRotation;
     public float MaxPressure;
     public float CurrentPressure;
     

     // Use this for initialization
     void Start () {
          specData = GameObject.Find("SpecData").GetComponent<SpecData>();
          needle.transform.localRotation = Quaternion.Euler(0, 0, StartRotation);
          MaxPressure = specData.GetPumpMax();
         
     }
	
	// Update is called once per frame
	void Update () {

          CurrentPressure = specData.GetPumpPressure();
          needleRotation = -((StartRotation - StopRotetion) / MaxPressure ) * CurrentPressure + StartRotation;

          needle.transform.localRotation = Quaternion.Euler(0, 0, needleRotation);
          PressureText.text = CurrentPressure.ToString();



     }
}
