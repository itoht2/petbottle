using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AddOnClick : MonoBehaviour {

     public Button BuyButton;
     public BuyItemControll _buyItemContrll;
     public GameObject BuyItem;
     public GameObject Node;


     // Use this for initialization
     void Start () {
          BuyItem = GameObject.Find("BuyItemControll");
          _buyItemContrll = BuyItem.transform.GetComponent<BuyItemControll>();

          
          BuyButton.onClick.AddListener(OnButtonClick);
     }
	
	// Update is called once per frame
	void Update () {
	
	}
     
     void OnButtonClick()
     {
          //Debug.Log("Start Button clicked");
          Node = this.gameObject.transform.parent.gameObject;
          _buyItemContrll.BuyItemDo(Node);

          
     }
}
