using UnityEngine;
using System.Collections;

public class NoseCornImageCahnger : MonoBehaviour {

     public SpecData specData;
     public Sprite NoseCornSprite;

	// Use this for initialization
	void Start () {
          specData = GameObject.Find("SpecData").GetComponent<SpecData>();
          GetComponent<SpriteRenderer>().sprite = specData.GetNoseCornImage();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
