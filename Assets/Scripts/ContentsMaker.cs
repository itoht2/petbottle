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
     private Button usingButton;
     private Text usingButtonText;
     
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
               Item.name = noseCornFolder.GetItemName(i);
               DiscText = Item.transform.Find("Description").GetComponent<Text>();
               DiscText.text = noseCornFolder.GetDiscription(i);
               PriceText = Item.transform.Find("Price").GetComponent<Text>();
               Price = noseCornFolder.GetPrice(i);
               PriceText.text = Price.ToString("#");
               IconImage = Item.transform.Find("ItemImage").GetComponent<Image>();
               IconImage.sprite = noseCornFolder.GetImage(i);
               usingButton = Item.transform.Find("UsingButton").GetComponent<Button>();
               usingButtonText = usingButton.transform.Find("Text").GetComponent<Text>();

               ButttonColorControll(i);      // ボタンの色替え

          }
     }
	
	// Update is called once per frame
	void Update () {
	
	}

     public void ButttonColorControll(int i)      // ボタンの色替え
     {
          if (noseCornFolder.GetNowUsed() == i) // 使用中のボタンの色と内容を変更
          {    // 使用中だったら
               BtnStateColorChange(usingButton, new Color32(255, 0, 0, 255), 0);     // nomal #FF0000FF
               BtnStateColorChange(usingButton, new Color32(255, 0, 0, 255), 1);     // Highlight #FF0000FF
               BtnStateColorChange(usingButton, new Color32(169, 9, 238, 255), 2);     // pressed #FF0000FF
               BtnStateColorChange(usingButton, new Color32(178, 178, 178, 255), 3);     // disablel #FF0000FF

               usingButtonText.text = "使用中";
               usingButton.interactable = true;
          }
          else if (noseCornFolder.GetNumberOfHold(i) > 0)
          {    // 持ってるけど使ってなかったら
               BtnStateColorChange(usingButton, new Color32(20, 105, 163, 255), 0);     // nomal #FF0000FF
               BtnStateColorChange(usingButton, new Color32(20, 105, 163, 255), 1);     // Highlight #FF0000FF
               BtnStateColorChange(usingButton, new Color32(169, 9, 238, 255), 2);     // pressed #FF0000FF
               BtnStateColorChange(usingButton, new Color32(178, 178, 178, 255), 3);     // disablel #FF0000FF

               usingButtonText.text = "所持";
               usingButton.interactable = true;
          }
          else
          {    // 持ってなかったら
               BtnStateColorChange(usingButton, new Color32(255, 0, 0, 255), 0);     // nomal #FF0000FF
               BtnStateColorChange(usingButton, new Color32(255, 0, 0, 255), 1);     // Highlight #FF0000FF
               BtnStateColorChange(usingButton, new Color32(169, 9, 238, 255), 2);     // pressed #FF0000FF
               BtnStateColorChange(usingButton, new Color32(178, 178, 178, 255), 3);     // disablel #FF0000FF

               usingButtonText.text = "非所持";
               usingButton.interactable = false;
          }
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
