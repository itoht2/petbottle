using UnityEngine;
using System.Collections;

public class BuyItemControll : MonoBehaviour {
     public SpecData specData;
     public ScoreData scoreData;
     private float ItemPrice;
     private NoseCornFolder _noseCornFolder;
     private GameObject MyNode;
     private int MyIDNumber;

	// Use this for initialization
	void Start () {
         

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

     public void BuyItemDo (GameObject ItemObject)
     {
          MyIDNumber = ItemObject.GetComponent<DialogOpener>().GetIdNumber();        
          string Itemname = ItemObject.name;
          //Debug.Log(MyIDNumber);
          _noseCornFolder = ItemObject.GetComponent<DialogOpener>().GetNoseCornFolder();
          ItemPrice = _noseCornFolder.GetPrice(MyIDNumber);

          Debug.Log(ItemPrice);
     }
}
