using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ContentsMaker : MonoBehaviour {
     public GameObject nodeFrefab;
     public NoseCornFolder noseCornFolder;
     public GameObject content;
     private int numberOfItem;
     private Text Disc;
     
     // Use this for initialization
     void Start()
     {

          numberOfItem = noseCornFolder.GetNumberOfItem();

          for (int i = 0; i < numberOfItem; i++)
          {
               //Debug.Log("i=" + i);
               GameObject Item = (GameObject)Instantiate(
                    nodeFrefab,
                    transform.position,
                    Quaternion.identity
                    );

               Item.transform.SetParent(content.transform);
               Item.transform.localScale = new Vector3(1, 1, 1);
               Item.name = "Item" + i;
               Disc = Item.transform.Find("Description").GetComponent<Text>();
               Disc.text = noseCornFolder.GetDiscription(i);

          }
     }
	
	// Update is called once per frame
	void Update () {
	
	}
}
