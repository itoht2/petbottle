using UnityEngine;
using System.Collections;

public class ContentsMaker : MonoBehaviour {
     public GameObject nodeFrefab;
     public NoseCornFolder noseCornFolder;
     private int numberOfItem;

	// Use this for initialization
	void Start () {

          numberOfItem = noseCornFolder.GetNumberOfItem();

          for (int i =0; i < numberOfItem; i++)
          {
               Debug.Log("i=" + i);
          }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
