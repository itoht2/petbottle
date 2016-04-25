using UnityEngine;
using System.Collections;

public class StarController : MonoBehaviour {

     public ScoreData scoreData;
     private const string EFFECT_PATH = "Prefabs/Effects/StarsParticle";
     private float RandomNumber;
     public RocketController Rocket;

     SpriteRenderer MainSpriteRenderer;
     SpriteRenderer ChildSpriteRenderer;

     // publicで宣言し、inspectorで設定可能にする
     public Sprite P01;
     public Sprite M01;
     public Sprite P02;
     public Sprite P10;
     private float AddNumber;
     private Sprite ChangeSprite;
     public AudioSource StarSound;

     private bool Launched;

     // Use this for initialization
     void Start () {
          // このobjectのSpriteRendererを取得
          MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
          ChildSpriteRenderer = gameObject.transform.FindChild("MapMarker").GetComponent<SpriteRenderer>();

          RandomNumber = Random.value;
          if (RandomNumber < 0.8f)
          { // +0.1の星
               AddNumber = 0.1f;
               ChangeSprite = P01;

          } else if(RandomNumber < 0.9f)
          { // -0.1の星
               AddNumber = -0.1f;
               ChangeSprite = M01;
          }
          else if (RandomNumber < 0.98f)
          { // +0.2の星
               AddNumber = 0.2f;
               ChangeSprite = P02;
          }
          else
          { // +1の星
               AddNumber = 1.0f;
               ChangeSprite = P10;
          }
          Launched = false;
          MainSpriteRenderer.sprite = ChangeSprite;
          ChildSpriteRenderer.sprite = ChangeSprite;
     }
	
	// Update is called once per frame
	void Update () {

          Launched = Rocket.GetLaunched() ;
          //Debug.Log("launched " + Launched);
	
	}
     
     void OnTriggerEnter2D(Collider2D collision) {

          if (Launched) {

               StarSound.PlayOneShot(StarSound.clip);
               //Debug.Log(Launched);

               //Debug.Log(collision.transform.name);

               GameObject effect = Instantiate(Resources.Load(EFFECT_PATH)) as GameObject;
               effect.transform.position = (Vector3)collision.transform.position;

               scoreData.AddScoreCoefficient(AddNumber);
               //Debug.Log(collision.transform.name);
          }

          //gameObject.GetComponent<SpriteRenderer>().enabled = false;
          gameObject.GetComponent<CircleCollider2D>().enabled = false;
          MainSpriteRenderer.enabled = false;
          ChildSpriteRenderer.enabled = false;

          //GameObject.Destroy(gameObject);
     }

    
}
