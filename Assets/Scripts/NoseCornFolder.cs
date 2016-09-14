using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class NoseCornFolder : MonoBehaviour {
     public int NumberOfItem;
     public string[] ItemName;  
     public float[] Weight ;
     public float[] Price;
     public string[] Discription;
     public string[] Specs;
     public string[] DiscriptionLong;
     public Sprite[] Image;
     public int[] NumberOfHold;
     public int NowUsed;                     // 今使ってる種類

     public int NumberOfParameter;      // パラメータの数　 Max3
     public string[] ParameterName;
     public float[] ParameterValue1;
     public float[] ParameterValue2;
     public float[] ParameterValue3;

     void Start()
     {
          LoadData();
     }

    
	
	// Update is called once per frame
	void Update () {
	
	}

     public void SaveData( )
     {
          PlayerPrefs.SetInt("NowUsed_" + this.name, NowUsed);
          for (int i = 0; i < NumberOfItem; i++)

          {
               PlayerPrefs.SetInt("NumberOfHold_" + this.name + i, NumberOfHold[i]);
          }
          

          //PlayerPrefs.Flush();
     }

     void OnDestroy()
     {
          SaveData();
          //Debug.Log(this.name + "saved");
          PlayerPrefs.Flush();
     }

     public void LoadData()
     {
          NowUsed = PlayerPrefs.GetInt("NowUsed_" + this.name, 0);
          //Debug.Log("NowUsed_" + this.name + NowUsed);
          for (int i = 0; i < NumberOfItem; i++)
          {
               if (i == 0)
               {
                    NumberOfHold[i] = PlayerPrefs.GetInt("NumberOfHold_" + this.name + i, 1);
               }
               else
               {
                    NumberOfHold[i] = PlayerPrefs.GetInt("NumberOfHold_" + this.name + i, 0);
               }

               //Debug.Log(NumberOfHold[i]);
          }
     }

     public int GetNumberOfItem()
     {
          return NumberOfItem;
     }
     public string GetItemName(int i)
     {
          return ItemName[i];          
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
     public string GetImageName(int i)
     {
          if (Image[i] == null)
          {
               return null;
          }
          else
          {
               return Image[i].name;
          }
     }


     public int GetNumberOfHold(int i)
     {
          return NumberOfHold[i];
     }
     public string GetSpecs(int i)
     {
          return Specs[i];
     }
     public string GetDescriptionLong(int i)
     {
          return DiscriptionLong[i];
     }
     public int GetNowUsed()
     {
          return NowUsed;
     }
    public string GetParameterName(int j)
     {
          return ParameterName[j];
     }
     public float GetParameterValue1(int i)
     {
          return ParameterValue1[i];
     }
     public float GetParameterValue2(int i)
     {
          return ParameterValue2[i];
     }
     public float GetParameterValue3(int i)
     {
          return ParameterValue3[i];
     }
     public int GetNumberOfParameter()
     {
          return NumberOfParameter;
     }

     //public void OnApplicationQuit()
     //{
     //     SaveData();
     //     Debug.Log(this.name + "saved");
     //     PlayerPrefs.Flush();
     //}

}
