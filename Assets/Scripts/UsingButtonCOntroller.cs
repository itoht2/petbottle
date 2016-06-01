using UnityEngine;
using System.Collections;

public class UsingButtonCOntroller : MonoBehaviour {
     public NoseCornFolder _noseCornFolder;
     private bool nowUsed;
     private int myNumber;

	// Use this for initialization
	void Start () {

          _noseCornFolder = gameObject.transform.parent.GetComponent<DialogOpener>().GetNoseCornFolder();
          myNumber = gameObject.transform.parent.GetComponent<DialogOpener>().GetIdNumber();         

     }
	
	// Update is called once per frame
	void Update () {
	
	}

     public void UsingButtonChanged()
     {
          Debug.Log("changed" + myNumber);
     }
}
