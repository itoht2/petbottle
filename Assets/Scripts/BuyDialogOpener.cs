using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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


     // Use this for initialization
     void Start()
     {
          detailDialog = GameObject.Find("BuyDialog");
          scoreData = GameObject.Find("ScoreData").GetComponent<ScoreData>();
          garageController = GameObject.Find("GarageController").GetComponent<GarageController>();

          Content = this.transform.parent.gameObject;
          if (Content.name == "Content")
          {
               _noseCornFolder = Content.GetComponent<ContentsMaker>().GetNoseCornFolder();
          }


          _menuAnim = detailDialog.GetComponent<Animator>();

          int.TryParse(this.name.Substring(4, 1), out SelectedNumber);

          TotalPointText = GameObject.Find("TotalPoint").GetComponent<Text>();
          totalPoint = scoreData.GetTotalScore();

          //BuyOkButtom = GameObject.Find("OkButton").GetComponent<Button>();
          //Debug.Log(BuyOkButtom.name);
          //BuyOkButtom.onClick.AddListener(PushedOkButton);
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
          


     }
}
