using UnityEngine;
using System.Collections;
using System;
using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class AwardFlags : MonoBehaviour {

     
     // Flags_1
     //  1:
     //  2:
     //  3:
     //  4:
     //  5:
     //  6:
     //  7:
     //  8:
     //  9:       
     // 10:
     // 11:
     // 12:
     // 13:
     // 14:
     // 15:
     // 16:
     // 17:
     // 18:
     // 19:
     // 20:
     // 21:
     // 22:
     // 23:
     // 24:
     // 25:
     // 26:
     // 27:
     // 28:
     // 29:
     // 30:
     // 31:
     // 32:


     

     public int Flags_1; //フラグをまとめた整数

     // Use this for initialization
     void Awake () {
          Flags_1 = PlayerPrefs.GetInt("Flags_1", 0);

          //OffFlagOne(5);  例）5桁目をon
          //OnFlagOne(5);   例）5桁目をoff
          //GetFlagOne(Flags_1 , 5);   例）フラグをチェック
     }
	
	// Update is called once per frame
	void Update () {
	
          
	}

     public void OnFlagOne(int BitNumber) // ビットナンバーの桁のフラグを立てる
     {
          //Debug.Log("mae" + Convert.ToString(Flags_1, 2));
          Flags_1 = Flags_1 | ( 1 << BitNumber -1 );
          //Debug.Log("ato" + Convert.ToString(Flags_1, 2));

          PlayerPrefs.SetInt("Flags_1", Flags_1);
     }

     public void OffFlagOne(int BitNumber) //ビットナンバーの桁のフラグを倒す
     {
          //Debug.Log("mae" + Convert.ToString(Flags_1, 2));
          Flags_1 = Flags_1 & ~(1 << BitNumber -1 );
          //Debug.Log("ato" + Convert.ToString(Flags_1, 2));

          PlayerPrefs.SetInt("Flags_1", Flags_1);
     }

     public bool GetFlagOne (int TempNumber, int BitNumber) // 最初の引数　保存してあった整数　次の引数　右からの桁数
     {
          bool FlagBool = false;
          
         

          FlagBool = ((TempNumber & (1 << BitNumber - 1)) == (1 << BitNumber - 1)); 
         
          //Debug.Log("FlagBool :" + FlagBool);

          return FlagBool;
     }
}
