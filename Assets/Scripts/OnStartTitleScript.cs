using UnityEngine;
using System.Collections;

public class OnStartTitleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

          GameObject IsSpecData = GameObject.Find("SpecData");

          if (IsSpecData == null)
          {
               //Debug.Log(IsSpecData.name);
               GameObject SpecDataprefab = (GameObject)Resources.Load("Prefabs/SpecData");
               IsSpecData = Instantiate(SpecDataprefab);
               IsSpecData.name = "SpecData";
               DontDestroyOnLoad(IsSpecData);

          }

     }
	
	// Update is called once per frame
	void Update () {
	
	}
}
