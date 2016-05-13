using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NoseCornFolder : MonoBehaviour {
     public int NumberOfCorn;
     public float[] CD  ;
     public float[] Weight ;
     public float[] Price;
     public string[] Discription;
     public Sprite[] Image;
     public int[] NumberOfHold;
     public bool[] NowUsed;


	// Use this for initialization
	void Start () {
        
     }
	
	// Update is called once per frame
	void Update () {
	
	}

     public float GetCD( int i)
     {
          return CD[i];
     }


}
