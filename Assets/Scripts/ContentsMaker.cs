using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ContentsMaker : MonoBehaviour {
     public GameObject nodeFrefab;
     public NoseCornFolder noseCornFolder;
     public GameObject content;
     public ScoreData scoreData;
     private int numberOfItem;
     private Text DiscText;
     private Text PriceText;
     private float Price;
     private Text NumberOfHoldText;
     private int NumberOfHold;
     private Image IconImage;
     private Button usingButton;
     private Text usingButtonText;
     private Button buyButton;
     private float totalScore;
     private GameObject Item;

     // Use this for initialization
     void Start()
     {
          string FolderNameTemp = this.name + "Folder";
          noseCornFolder = GameObject.Find(FolderNameTemp).GetComponent<NoseCornFolder>();
          numberOfItem = noseCornFolder.GetNumberOfItem();
          this.name = noseCornFolder.name + "Content";

          ContentChanger();
         
     }
	
	// Update is called once per frame
	void Update () {
	
	}

     public void ContentChanger()
     {
          scoreData = GameObject.Find("ScoreData").GetComponent<ScoreData>();
          for (int i = 0; i < numberOfItem; i++)
          {
               //Debug.Log("i=" + i);               

               if (GameObject.Find(noseCornFolder.GetItemName(i)) == null) {

                Item = (GameObject)Instantiate(
                    nodeFrefab,
                    transform.position,
                    Quaternion.identity
                    );
                } else
               {
                     Item = GameObject.Find(noseCornFolder.GetItemName(i));
               }

               Item.transform.SetParent(content.transform);
               Item.transform.localScale = new Vector3(1, 1, 1);
               Item.name = noseCornFolder.GetItemName(i);
               DiscText = Item.transform.FindChild("Description").GetComponent<Text>();
               DiscText.text = noseCornFolder.GetDiscription(i);
               PriceText = Item.transform.FindChild("Price").GetComponent<Text>();
               Price = noseCornFolder.GetPrice(i);
               PriceText.text = Price.ToString("#");
               NumberOfHoldText = Item.transform.FindChild("NomberOfHoldText").GetComponent<Text>();
               NumberOfHold = noseCornFolder.GetNumberOfHold(i);
               NumberOfHoldText.text = NumberOfHold + " 個";

               IconImage = Item.transform.FindChild("ItemImage").GetComponent<Image>();
               IconImage.sprite = noseCornFolder.GetImage(i);
               usingButton = Item.transform.FindChild("UsingButton").GetComponent<Button>();
               usingButtonText = usingButton.transform.FindChild("Text").GetComponent<Text>();

               buyButton = Item.transform.FindChild("BuyButton").GetComponent<Button>();


               ButttonColorControll(i, usingButton);      // ボタンの色替え

               totalScore = scoreData.GetTotalScore();

               //Debug.Log(totalScore + " " + Price);
               if (Price > totalScore)
               {
                    buyButton.interactable = false;
               } else
               {
                    buyButton.interactable = true;
               }

          }
     }

     public void ButttonColorControll(int i, Button usingButton)      // ボタンの色替え
     {
          //Debug.Log(noseCornFolder.name + " " + noseCornFolder.GetNowUsed());

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

     public  int GetNumberOfItem()
     {
          return numberOfItem;
     }

}
