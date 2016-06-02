using UnityEngine;
using System.Collections;

public class UsingButtonCOntroller : MonoBehaviour {
     public NoseCornFolder _noseCornFolder;
     public SpecData specData;
     public int nowUsedNumber;
     public int myNumber;
     public ContentsMaker contentMaker;


	// Use this for initialization
	void Start () {

          _noseCornFolder = gameObject.transform.parent.GetComponent<DialogOpener>().GetNoseCornFolder();
          specData = GameObject.Find("SpecData").GetComponent<SpecData>();
          myNumber = gameObject.transform.parent.GetComponent<DialogOpener>().GetIdNumber();
          //Debug.Log(_noseCornFolder.name);
          contentMaker = transform.GetComponentInParent<ContentsMaker>();
     }
	
	// Update is called once per frame
	void Update () {
	
	}

     public void UsingButtonChanged()
     {
          nowUsedNumber = _noseCornFolder.GetNowUsed();
          //Debug.Log("myNumber " + myNumber + " nowUsed " + nowUsedNumber );

          if (nowUsedNumber != myNumber)     // 使ってなかったら
          {
               _noseCornFolder.NowUsed = myNumber;
               nowUsedNumber = myNumber;
               contentMaker.ContentChanger();
               _noseCornFolder.SaveData();


          } else    // 既に使ってたら
          {

          }

     }
}
