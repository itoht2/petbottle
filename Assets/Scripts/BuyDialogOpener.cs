using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class BuyDialogOpener : MonoBehaviour {
     public Animator _menuAnim;
     public GameObject detailDialog;
     public NoseCornFolder _noseCornFolder;
     public GameObject Content;
     private Image image;
     private Text itemNameText;
     public int SelectedNumber;
     private Text priceText;
     private Text specText;
     public Button BuyOkButtom;
     public Text TotalPointText;
     public float totalPoint;
     public float itemPrice;
     public ScoreData scoreData;
     public GarageController garageController;
     public ContentsMaker contentsMaker;


     // Use this for initialization
     void Start()
     {
          detailDialog = GameObject.Find("BuyDialog");
          scoreData = GameObject.Find("ScoreData").GetComponent<ScoreData>();
          garageController = GameObject.Find("GarageController").GetComponent<GarageController>();

          Content = this.transform.parent.gameObject;

          //Debug.Log(Content.name.Substring(Content.name.Length - 7, 7));

          if (Content.name.Substring(Content.name.Length - 7 ,7 ) == "Content")
          {
               _noseCornFolder = Content.GetComponent<ContentsMaker>().GetNoseCornFolder();
          }


          _menuAnim = detailDialog.GetComponent<Animator>();

          //int.TryParse(this.name.Substring(this.name.Length -1, 1), out SelectedNumber);

          SelectedNumber = int.Parse(Regex.Replace(this.name, @"[^\d]", ""));

          //Debug.Log(this.name);
          //Debug.Log(this.name.Substring(4, 1));

          TotalPointText = GameObject.Find("TotalPoint").GetComponent<Text>();
          totalPoint = scoreData.GetTotalScore();
          
     }


     // Update is called once per frame
     void Update () {
	
	}
     public void ControlMenuAnimator()
     {
          _menuAnim.SetBool("UP", !_menuAnim.GetBool("UP"));

          if (_menuAnim.GetBool("UP"))
          {
               //image = detailDialog.transform.FindChild("ItemImage").GetComponent<Image>();
               //image.sprite = _noseCornFolder.GetImage(1);

               //int.TryParse(this.name.Substring(4, 1), out SelectedNumber);
               BuyOkButtom = GameObject.Find("OkButton").GetComponent<Button>();
               //Debug.Log(BuyOkButtom.name);
               BuyOkButtom.onClick.AddListener(PushedOkButton);

               itemPrice = _noseCornFolder.GetPrice(SelectedNumber);

               image = detailDialog.transform.Find("ItemImage").GetComponent<Image>();
               image.sprite = _noseCornFolder.GetImage(SelectedNumber);

               itemNameText = detailDialog.transform.FindChild("ItemNameText").GetComponent<Text>();
               itemNameText.text = _noseCornFolder.GetDiscription(SelectedNumber);      
                   
          }

     }
     public NoseCornFolder GetNoseCornFolder()
     {
          return _noseCornFolder;
     }

     public int GetIdNumber()
     {
          return SelectedNumber;
     }

     public void PushedOkButton ()
     {
          totalPoint = scoreData.GetTotalScore();
          //Debug.Log("OK!" + _noseCornFolder.name + SelectedNumber);
          _noseCornFolder.NumberOfHold[SelectedNumber] += 1;
          _noseCornFolder.SaveData();


          _menuAnim.SetBool("UP", !_menuAnim.GetBool("UP"));
          BuyOkButtom.onClick.RemoveListener(PushedOkButton);

          StartCoroutine(garageController.ScoreAnimation((int)totalPoint, (int)totalPoint - (int)itemPrice, 2));
          totalPoint = totalPoint - itemPrice;

          scoreData.TotalScore = totalPoint ;
          scoreData.SaveScore();

          contentsMaker = GameObject.Find(_noseCornFolder.name + "Content").GetComponent<ContentsMaker>();
          contentsMaker.ContentChanger();



     }
}
