using UnityEngine;
using System.Collections;
using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class OnStartTitleScript : MonoBehaviour {

	// Use this for initialization
	void Awake () {

          GameObject IsSpecData = GameObject.Find("SpecData");
          GameObject IsScoreData = GameObject.Find("ScoreData");
          GameObject IsBodyFolder = GameObject.Find("BodyFolder");
          GameObject IsNoseCornFolder = GameObject.Find("NoseCornFolder");

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

          if (IsBodyFolder == null)
          {
               //Debug.Log(IsSpecData.name);
               GameObject SpecDataprefab = (GameObject)Resources.Load("Prefabs/BodyFolder");
               IsBodyFolder = Instantiate(SpecDataprefab);
               IsBodyFolder.name = "BodyFolder";
               DontDestroyOnLoad(IsBodyFolder);
          }

          if (IsNoseCornFolder == null)
          {
               //Debug.Log(IsSpecData.name);
               GameObject SpecDataprefab = (GameObject)Resources.Load("Prefabs/NoseCornFolder");
               IsNoseCornFolder = Instantiate(SpecDataprefab);
               IsNoseCornFolder.name = "NoseCornFolder";
               DontDestroyOnLoad(IsNoseCornFolder);
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
