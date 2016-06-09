using UnityEngine;
using System.Collections;
using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class OnStartTitleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

          GameObject IsSpecData = GameObject.Find("SpecData");
          GameObject IsScoreData = GameObject.Find("ScoreData");

          if (IsSpecData == null)
          {
               //Debug.Log(IsSpecData.name);
               GameObject SpecDataprefab = (GameObject)Resources.Load("Prefabs/SpecData");
               IsSpecData = Instantiate(SpecDataprefab);
               IsSpecData.name = "SpecData";
               DontDestroyOnLoad(IsSpecData);
          }

          if(IsScoreData == null)
          {
               //Debug.Log(IsSpecData.name);
               GameObject SpecDataprefab = (GameObject)Resources.Load("Prefabs/ScoreData");
               IsScoreData = Instantiate(SpecDataprefab);
               IsScoreData.name = "ScoreData";
               DontDestroyOnLoad(IsScoreData);
          }

     }
	
	// Update is called once per frame
	void Update () {
	
	}

     public void OnApplicationQuit()
     {
          PlayerPrefs.Flush();
     }
}
