using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class BuyItemControll : MonoBehaviour {
     public SpecData specData;
     public ScoreData scoreData;
     public float TotalPoint;
     public float ItemPrice;
     public NoseCornFolder _noseCornFolder;
     private GameObject MyNode;
     public int MyIDNumber;
     public float ItemWeight;
     public string [] ParameterName = new string [3];
     public float [] ParameterValue = new float [3];
     public float ParameterValue2;
     public float ParameterValue3;
     private GameObject SRBANumber;
    
     // Use this for initialization
     void Start () {

          specData = GameObject.Find("SpecData").GetComponent<SpecData>();
          scoreData = GameObject.Find("ScoreData").GetComponent<ScoreData>();
          SRBANumber = GameObject.Find("SRBAText_b");
          

     }
	
	// Update is called once per frame
	void Update () {

	
	}

     public void BuyItemDo (GameObject ItemObject)
     {
          MyIDNumber = ItemObject.GetComponent<DialogOpener>().GetIdNumber();        
          //string Itemname = ItemObject.name;
          //Debug.Log(MyIDNumber);
          _noseCornFolder = ItemObject.GetComponent<DialogOpener>().GetNoseCornFolder();
          ItemPrice = _noseCornFolder.GetPrice(MyIDNumber);
          ItemWeight = _noseCornFolder.GetWeight(MyIDNumber);
          TotalPoint = scoreData.GetTotalScore();

          if (_noseCornFolder.name.Substring(0, 4) == "SRBA")
          {
               SRBANumber.SetActive(true);
               Text SRBAText = SRBANumber.GetComponent<Text>();
               SRBAText.text = _noseCornFolder.GetParameterValue1(MyIDNumber) + "本";

          }
          else
          {
               SRBANumber.SetActive(false);
          }

          for (int j= 0; j < 2; j++)
          {
               ParameterName[j] = _noseCornFolder.GetParameterName(j);
          }
          ParameterValue[0] = _noseCornFolder.GetParameterValue1(MyIDNumber);
          ParameterValue[1] = _noseCornFolder.GetParameterValue2(MyIDNumber);
          ParameterValue[2] = _noseCornFolder.GetParameterValue3(MyIDNumber);
          
          //Debug.Log(Itemname + " " + ItemPrice + " " + ItemWeight + " " + ParameterName[0] + " " + ParameterValue[0]);
          //Debug.Log(Itemname + " " + ItemPrice + " " + ItemWeight + " " + ParameterName[1] + " " + ParameterValue[1]);
          //Debug.Log(Itemname + " " + ItemPrice + " " + ItemWeight + " " + ParameterName[2] + " " + ParameterValue[2]);
     }

     public void BuyItemOK()
     {
          //Debug.Log(_noseCornFolder.GetItemName(MyIDNumber));

     }


}
