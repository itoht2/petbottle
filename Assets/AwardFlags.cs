using UnityEngine;
using System.Collections;
using System;
using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class AwardFlags : MonoBehaviour {
     [Flags]
     public enum FlagOne // ここにフラグを用意する
     {
          NONE = 1 << 0, // 無効
          SOLDIER = 1 << 1, // 王国兵士
          SORCERER = 1 << 2, // 魔法使い
          HUNTER = 1 << 3, // 狩人
          MERCENARY = 1 << 4, // 傭兵
     }

     

     public int Flags_1;

     // Use this for initialization
     void Awake () {
          Flags_1 = PlayerPrefs.GetInt("Flags_1", 0);

          


     }
	
	// Update is called once per frame
	void Update () {
	
	}

     public bool GetFlagOne (int TempNumber, int BitNumber) // 最初の引数　保存してあった整数　次の引数　右からの桁数
     {
          bool FlagBool = false;
          string FlagString = Convert.ToString(TempNumber, 2);
          Debug.Log("Flagstring :" + FlagString);
          FlagBool = (FlagString.Substring(FlagString.Length - BitNumber , 1) == "1");
          //Debug.Log("FlagBool :" + FlagBool);



          return FlagBool;
     }
}
