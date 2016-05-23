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

     ///【機能】 ボタン状態による色変更
     ///【第一引数】色を変更したいボタン
     ///【第二引数】変更したい色(new Color(float a,floar b,float c,float d))
     ///【第三引数】色を変更したい状態(0:normalColor 1:highlightedColor 2:pressedColor 3:disabledColor)
     public static void BtnStateColorChange(Button btn, Color color, int changeState)
     {
          ColorBlock cbBtn = btn.colors;
          switch (changeState)
          {
               case 0://normalColor
                    cbBtn.normalColor = color;
                    break;
               case 1://highlightedColor
                    cbBtn.highlightedColor = color;
                    break;
               case 2://pressedColor
                    cbBtn.pressedColor = color;
                    break;
               case 3://disabledColor
                    cbBtn.disabledColor = color;
                    break;
          }
          btn.colors = cbBtn;
     }
}
