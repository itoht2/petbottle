using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ContentsMaker : MonoBehaviour {
     public GameObject nodeFrefab;
     public NoseCornFolder noseCornFolder;
     public GameObject content;
     private int numberOfItem;
     private Text DiscText;
     private Text PriceText;
     private float Price;
     private Image IconImage;
     
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
               DiscText = Item.transform.Find("Description").GetComponent<Text>();
               DiscText.text = noseCornFolder.GetDiscription(i);
               PriceText = Item.transform.Find("Price").GetComponent<Text>();
               Price = noseCornFolder.GetPrice(i);
               PriceText.text = Price.ToString("#");
               IconImage = Item.transform.Find("ItemImage").GetComponent<Image>();
               IconImage.sprite = noseCornFolder.GetImage(i);



          }
     }
	
	// Update is called once per frame
	void Update () {
	
	}

     public NoseCornFolder GetNoseCornFolder()
     {
          return noseCornFolder;
     }
}
