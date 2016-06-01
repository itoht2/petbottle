using UnityEngine;
using System.Collections;

public class BuyItemControll : MonoBehaviour {
     public SpecData specData;
     public ScoreData scoreData;
     private float ItemPrice;
     private NoseCornFolder _noseCornFolder;
     private GameObject MyNode;
     private int MyIDNumber;
     private float ItemWeight;
     private string [] ParameterName = new string [3];
     private float [] ParameterValue = new float [3];
     private float ParameterValue2;
     private float ParameterValue3;


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
          ItemWeight = _noseCornFolder.GetWeight(MyIDNumber);

          for (int j= 0; j < 2; j++)
          {
               ParameterName[j] = _noseCornFolder.GetParameterName(j);
          }
          ParameterValue[0] = _noseCornFolder.GetParameterValue1(MyIDNumber);
          ParameterValue[1] = _noseCornFolder.GetParameterValue2(MyIDNumber);
          ParameterValue[2] = _noseCornFolder.GetParameterValue3(MyIDNumber);
          
          Debug.Log(Itemname + " " + ItemPrice + " " +ItemWeight + " " +ParameterName[0] + " " + ParameterValue[0]);


          
     }
}
