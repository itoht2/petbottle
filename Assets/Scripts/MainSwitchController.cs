using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainSwitchController : MonoBehaviour {
     public bool MainSwitch;
     public Image buttonImage;
     public Sprite OnImage;
     public Sprite OffImage;

     public bool[] Ingflag;
     public GameObject[] Ing;

	// Use this for initialization
	void Start () {

          MainSwitch = false;
          buttonImage = GetComponent<Image>();
          buttonImage.sprite = OffImage;         

     }
	
	// Update is called once per frame
	void Update () {

       
	}

     public void ClickButton ()
     {
          //Debug.Log("Clicked.");
          if (!MainSwitch)
          {
               buttonImage.sprite = OnImage;
               StartCoroutine("StartUp");
          } else
          {
               buttonImage.sprite = OffImage;
               for (int i = 0; i < Ing.Length; i++)
               {
                    Ing[i].SetActive(false);
               }

          }
          MainSwitch = !MainSwitch;
     }

     public bool GetMainSwitch ()
     {
          return MainSwitch;
     }

     private IEnumerator StartUp()
     {
          yield return null;
          for (int i = 0; i < Ing.Length; i++)
          {
               Ing[i].SetActive(true);
          }

          yield return new WaitForSeconds(1.0f);

          for (int i = 0; i < Ing.Length; i++)
          {
               if (Ingflag[i] == false)
               {
                    Ing[i].SetActive(false);
               }
              
          }

     }
}
