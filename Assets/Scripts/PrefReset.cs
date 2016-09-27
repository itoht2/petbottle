using UnityEngine;
using System.Collections;
using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class PrefReset : MonoBehaviour {
     public SpecData specData;
     public ScoreData scoreData;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

#if UNITY_EDITOR //Unityエディタ上での稼働時のみ表示する
     void OnGUI()
     {
          specData = GameObject.Find("SpecData").GetComponent<SpecData>();
          scoreData = GameObject.Find("ScoreData").GetComponent<ScoreData>();
          if (GUI.Button(new Rect(0, 0, 150, 100), "reset"))
          {
               //デバッグ用。保存データ初期化
               PlayerPrefs.DeleteAll();
               Debug.Log("データ全消去したわよッ!!(・∀・)");
               specData.LoadData();
               scoreData.LoadScore();
               GameObject.Find("NoseCornFolder").GetComponent<NoseCornFolder>().LoadData();
               GameObject.Find("BodyFolder").GetComponent<NoseCornFolder>().LoadData();
               GameObject.Find("FinFolder").GetComponent<NoseCornFolder>().LoadData();
               GameObject.Find("CanSatFolder").GetComponent<NoseCornFolder>().LoadData();
               GameObject.Find("SRBAFolder").GetComponent<NoseCornFolder>().LoadData();
               GameObject.Find("PumpFolder").GetComponent<NoseCornFolder>().LoadData();
               GameObject.Find("MultiStageFolder").GetComponent<NoseCornFolder>().LoadData();


          }
     }
#endif
}
