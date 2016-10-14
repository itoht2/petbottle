using UnityEngine;
using System.Collections;

public class PumpChanger : MonoBehaviour {

     private SpriteRenderer PumpSprite;
     private Animator PumpAnime;
     public Sprite[] Pump;
     public RuntimeAnimatorController[] PumpAnimeController;
    

     public SpecData specData;
     private int ID;


     // Use this for initialization
     void Start () {
          specData = GameObject.Find("SpecData").GetComponent<SpecData>();

          PumpSprite = gameObject.GetComponent<SpriteRenderer>();
          ID = specData.GetPumpID();
          PumpSprite.sprite = Pump[ID];

          PumpAnime = gameObject.GetComponent<Animator>();
          PumpAnime.runtimeAnimatorController = PumpAnimeController[ID];
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
