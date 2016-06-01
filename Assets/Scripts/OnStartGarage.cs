using UnityEngine;
using System.Collections;
using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class OnStartGarage : MonoBehaviour {

     public NoseCornFolder noseCornFolder;
     public NoseCornFolder bodyFolder;
     public SpecData specData;
     

	// Use this for initialization
	void Start () {
          specData = GameObject.Find("SpecData").GetComponent<SpecData>();
          specData.NoseCornImage = noseCornFolder.GetImage(noseCornFolder.GetNowUsed());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
