using UnityEngine;
using System.Collections;
using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class OnStartGarage : MonoBehaviour {

     public NoseCornFolder noseCornFolder;
     public NoseCornFolder bodyFolder;
     public NoseCornFolder finFolder;
     public SpecData specData;
     

	// Use this for initialization
	void Start () {
          noseCornFolder = GameObject.Find("NoseCornFolder").GetComponent<NoseCornFolder>();
          bodyFolder = GameObject.Find("BodyFolder").GetComponent<NoseCornFolder>();
          finFolder = GameObject.Find("FinFolder").GetComponent<NoseCornFolder>();

          specData = GameObject.Find("SpecData").GetComponent<SpecData>();
          specData.NoseCornImage = noseCornFolder.GetImage(noseCornFolder.GetNowUsed());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
