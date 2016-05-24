using UnityEngine;
using System.Collections;

public class BuyItemControll : MonoBehaviour {
     public SpecData specData;
     public ScoreData scoreData;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

     public void BuyItemDo (GameObject ItemObject)
     {
          string Itemname = ItemObject.name;
          Debug.Log("BuyItemControll " + ItemObject.name);
     }
}
