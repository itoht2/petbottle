using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SideThrustBarController : MonoBehaviour {
         
     private Vector2 sd;
     private float WidthMax;
     public SpecData specData;

     // Use this for initialization
     void Start () {
         
          Vector2 sd = GetComponent<RectTransform>().sizeDelta;
          WidthMax = sd.x;
          //Debug.Log("WithMax:" + WidthMax);
     }
	
	// Update is called once per frame
	void Update () {
          sd.x = WidthMax * specData.GetSideThrustRate();
          sd.y = 21.8f;
          GetComponent<RectTransform>().sizeDelta = sd;

     }
}
