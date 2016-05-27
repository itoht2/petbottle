﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogOpener : MonoBehaviour {
     public Animator _menuAnim;
     public GameObject detailDialog;
     public NoseCornFolder _noseCornFolder;
     public GameObject Content;
     private Image image;
     private Text itemNameText;
     public int SelectedNumber;
     private Text priceText;
     private Text specText;


     // Use this for initialization
     void Start() {
          detailDialog = GameObject.Find("DetailDialog");

          Content = this.transform.parent.gameObject;
          if (Content.name == "Content") { 
          _noseCornFolder = Content.GetComponent<ContentsMaker>().GetNoseCornFolder();
          }
          
          //_noseCornFolder = GameObject.Find("NoseCornFolder").GetComponent<NoseCornFolder>(); 

          _menuAnim = detailDialog.GetComponent<Animator>();

          int.TryParse(this.name.Substring(4, 1), out SelectedNumber);
     }

	
	// Update is called once per frame
	void Update () {
	
	}

     public void ControlMenuAnimator()
     {
          _menuAnim.SetBool("UP", !_menuAnim.GetBool("UP"));

          if ( _menuAnim.GetBool("UP") )
          {
               //image = detailDialog.transform.FindChild("ItemImage").GetComponent<Image>();
               //image.sprite = _noseCornFolder.GetImage(1);

               //int.TryParse(this.name.Substring(4, 1), out SelectedNumber);

               image = detailDialog.transform.Find("ItemImage").GetComponent<Image>();
               image.sprite = _noseCornFolder.GetImage(SelectedNumber);

               itemNameText = detailDialog.transform.FindChild("ItemNameText").GetComponent<Text>();             
               itemNameText.text = _noseCornFolder.GetDiscription(SelectedNumber);

               priceText = detailDialog.transform.FindChild("PriceText").GetComponent<Text>();
               priceText.text = (int)_noseCornFolder.GetPrice(SelectedNumber) + " pt";

               specText = detailDialog.transform.FindChild("SpecText").GetComponent<Text>();              
               string TempText = _noseCornFolder.GetSpecs(SelectedNumber).Replace("/n", "\n");
               specText.text = TempText;

               specText = detailDialog.transform.FindChild("DetailText").GetComponent<Text>();              
               TempText = _noseCornFolder.GetDescriptionLong(SelectedNumber).Replace("/n", "\n");
               specText.text = TempText;

               specText = detailDialog.transform.FindChild("NumberOfHoldText").GetComponent<Text>();              
               TempText = "現在所持数:　" + _noseCornFolder.GetNumberOfHold(SelectedNumber) + "個";
               specText.text = TempText;

               int nowUsed = _noseCornFolder.GetNowUsed();
               Text NowUsingText = detailDialog.transform.FindChild("NowUsingText").GetComponent<Text>();
               if (nowUsed == SelectedNumber)
               {
                    NowUsingText.enabled = true;
               } else
               {
                    NowUsingText.enabled = false;
               }


          }

     }
     public NoseCornFolder GetNoseCornFolder ()
     {
          return _noseCornFolder;
     }

     public int GetIdNumber ()
     {
          return SelectedNumber;
     }
}
