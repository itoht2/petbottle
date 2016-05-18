using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NoseCornFolder : MonoBehaviour {
     public int NumberOfItem;
     public float[] CD  ;
     public float[] Weight ;
     public float[] Price;
     public string[] Discription;
     public Sprite[] Image;
     public int[] NumberOfHold;
     public int NowUsed;


	// Use this for initialization
	void Start () {
        
     }
	
	// Update is called once per frame
	void Update () {
	
	}

     public int GetNumberOfItem()
     {
          return NumberOfItem;
     }
     public float GetCD( int i)
     {
          return CD[i];
     }
     public float GetWeight(int i)
     {
          return  Weight[i];
     }
     public float GetPrice(int i)
     {
          return Price[i];
     }
     public string GetDiscription(int i)
     {
          return Discription[i];
     } 
     public Sprite GetImage(int i)
     {
          return Image[i];
     }
     public int GetNumberOfHold(int i)
     {
          return NumberOfHold[i];
     }
     public int GetNowUsed()
     {
          return NowUsed;
     }
   

}
