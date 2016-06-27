using UnityEngine;
using System.Collections;
using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class UsingButtonCOntroller : MonoBehaviour {
     public NoseCornFolder _noseCornFolder;
     public string noseCornFolderName ;
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
          noseCornFolderName = _noseCornFolder.name;

     }
	
	// Update is called once per frame
	void Update () {
	
	}

     public void UsingButtonChanged()
     {
          nowUsedNumber = _noseCornFolder.GetNowUsed();
          myNumber = gameObject.transform.parent.GetComponent<DialogOpener>().GetIdNumber();

         //Debug.Log(" nowUsed " + nowUsedNumber + " myNumber" + myNumber);

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

                    switch (parameterName) // ここに変えるパラメータを並べる
                    {
                         case "NoseCornCD":
                              specData.NoseCornCD = parameterValue;

                              break;

                        
                         case "InnerPressureMax":
                              specData.InnerPressureMax = parameterValue;

                              break;

                         case "FuelCapacity":
                              specData.FuelCapacity = parameterValue;

                              break;
                         case "Cd":
                              specData.Cd = parameterValue;

                              break;
                         case "FinCD":
                              specData.FinCD = parameterValue;

                              break;
                         case "Stability":
                              specData.Stability = parameterValue;

                              break;







                         default:
                              //Debug.Log(parameterName + "is Wrong");
                              break;

                    }



                    //Debug.Log("i= " + i + " j= " + j + " " + parameterName + "=" + parameterValue);

               }
          }

          switch (noseCornFolderName)
          {
               case "BodyFolder":
                    specData.RocketWeight = _noseCornFolder.GetWeight(i);
                    break;
               case "NoseCornFolder":
                    specData.NoseCornWeight = _noseCornFolder.GetWeight(i);
                    break;
               case "FinFolder":
                    specData.FinWeight = _noseCornFolder.GetWeight(i);
                    break;
               default:


                    break;
          }



     }
     

}
