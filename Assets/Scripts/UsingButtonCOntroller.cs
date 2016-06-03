using UnityEngine;
using System.Collections;
using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class UsingButtonCOntroller : MonoBehaviour {
     public NoseCornFolder _noseCornFolder;
     public SpecData specData;
     public int nowUsedNumber;
     public int myNumber;
     public ContentsMaker contentMaker;
     
     public string parameterName;
     public float parameterValue;


     // Use this for initialization
     void Start () {

          _noseCornFolder = gameObject.transform.parent.GetComponent<DialogOpener>().GetNoseCornFolder();
          specData = GameObject.Find("SpecData").GetComponent<SpecData>();
          myNumber = gameObject.transform.parent.GetComponent<DialogOpener>().GetIdNumber();
          //Debug.Log(_noseCornFolder.name);
          contentMaker = transform.GetComponentInParent<ContentsMaker>();
     }
	
	// Update is called once per frame
	void Update () {
	
	}

     public void UsingButtonChanged()
     {
          nowUsedNumber = _noseCornFolder.GetNowUsed();
          myNumber = gameObject.transform.parent.GetComponent<DialogOpener>().GetIdNumber();
          


          if (nowUsedNumber != myNumber)     // 使ってなかったら
          {
               _noseCornFolder.NowUsed = myNumber;
               nowUsedNumber = myNumber;
               contentMaker.ContentChanger();
               //_noseCornFolder.SaveData();

               SpecDataChanger(myNumber);
               

          } else    // 既に使ってたら
          {

          }

          PlayerPrefs.SetInt("NowUsed_" + _noseCornFolder.name, nowUsedNumber);
          //Debug.Log(_noseCornFolder.name + " nowUsed " + nowUsedNumber);
     }


     public void SpecDataChanger (int i) 
     {
          int numberOfParameter = _noseCornFolder.GetNumberOfParameter();
          if (numberOfParameter == 0)
          {
               return;
          } else { 

               for (int j = 0; j < numberOfParameter; j++)
               {
                    parameterName = _noseCornFolder.GetParameterName(j);
                    Debug.Log("i= "+ i + " j= "+ j + " " + parameterName + "=" + parameterValue);

                    switch (j)
                    {
                         case 0:
                              parameterValue = _noseCornFolder.GetParameterValue1(i);
                              break;
                         case 1:
                              parameterValue = _noseCornFolder.GetParameterValue2(i);
                              break;
                         case 2:
                              parameterValue = _noseCornFolder.GetParameterValue3(i);
                              break;
                         default:

                              break;                         
                    }

                    switch (parameterName)
                    {
                         case "NoseCornCD":
                              specData.NoseCornCD = parameterValue;

                              break;
                         case "Maxpressure":
                              specData.InnerPressureMax = parameterValue;
                              break;




                         default:
                              Debug.Log(parameterName + "is Wrong");
                              break;

                    }


               }
          }
     }
}
